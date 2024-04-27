using HMS.DAL.Helper;
using HMS.DAL.Seeds;
using HMS.Models;
using HMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginVM> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly JWTConfig _jWTConfig;

        public UsersController(IOptions<JWTConfig> jwtConfig, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<LoginVM> logger, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment iWebHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _jWTConfig = jwtConfig.Value;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<object> RegisterUser([FromForm] UserVM objModel)
        {
            try
            {
                string uniqueImageName = "";
                if (objModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/user_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    objModel.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    objModel.ImageName = uniqueImageName;
                }
                var user = new ApplicationUser
                {
                    FirstName = objModel.FirstName,
                    LastName = objModel.LastName,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserName = objModel.UserName,
                    PhoneNumber = objModel.Phone,
                    Email = objModel.Email,
                    ImageName = objModel.ImageName,
                };
                var result = await _userManager.CreateAsync(user, objModel.Password);
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "User has been Registered", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "", result.Errors.Select(x => x.Description).ToArray()));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<object> SignIn([FromBody] User model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.IsChecked, false);
                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.FindByNameAsync(model.UserName);
                        var roles = (await _userManager.GetRolesAsync(appUser)).ToList();
                        var user = new LoginVM
                        {
                            FirstName = appUser.FirstName,
                            LastName = appUser.LastName,
                            DateCreated = DateTime.UtcNow,
                            DateModified = DateTime.UtcNow,
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            ImageName = appUser.ImageName,
                        };
                        user.Token = GenerateToken(appUser, roles);

                        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", user));

                    }
                }

                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "invalid Email or password", null));

            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpGet("GetAllUser")]
        public async Task<object> GetAllUser()
        {
            try
            {
                List<ApplicationUser> allUserDTO = new List<ApplicationUser>();
                var users = _userManager.Users.ToList();
                foreach (var user in users)
                {
                    allUserDTO.Add(new ApplicationUser(
                        user.Id,
                        user.FirstName,
                        user.LastName,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                        user.DateCreated,
                        user.DateModified,
                        user.ImageName
                        ));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", allUserDTO));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpDelete("DeleteUser")]
        public async Task<object> DeleteUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.UserName == "admin")
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Admin Can Not be Deleted", null));
                }
                //if (user.ImageName != null)
                //{
                //    string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/user_images");
                //    DeleteExistingImage(Path.Combine(uploadFolder, user.ImageName));
                //}
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Users Deleted succfully", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something went wrong please try again later", null));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("GetRoles")]
        public async Task<object> GetRoles()
        {
            try
            {
                var roles = _roleManager.Roles.ToList();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", roles));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpPost("AddRole")]
        public async Task<object> AddRole([FromForm] UserRolesVM model)
        {
            try
            {
                if (model.RoleName == null || model.RoleName == "")
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Parameters are missing", null));

                }
                if (await _roleManager.RoleExistsAsync(model.RoleName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Role already exist", null));

                }
                var result = await _roleManager.CreateAsync(new ApplicationRole(model.RoleName.Trim()));
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Role added successfully", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "something went wrong please try again later", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }
        [HttpPut("EditRole")]
        public async Task<object> EditRole([FromForm] UserRolesVM model)
        {
            try
            {
                //if (roleId != model.Id)
                //{
                //    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Role Id Mismatch!", null));
                //}
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if (role == null)
                {
                    return NotFound();
                }
                if (role.Name == "Admin")
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Admin Role can not be updated!", null));
                }
                if (await _roleManager.RoleExistsAsync(model.RoleName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Role already exist", null));

                }
                role.Name = model.RoleName;
                role.JsonData = role.JsonData;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Role updated succfully!", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something went wrong please try again later", null));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpDelete("DeleteRole")]
        public async Task<object> DeleteRole([FromForm] UserRolesVM model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if (role == null)
                {
                    return NotFound();
                }

                if (role.Name == "Admin")
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Admin Role can not be deleted!", null));
                }
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Role deleted succfully!", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something went wrong please try again later", null));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        //[HttpGet("UserRoles")]
        //public async Task<object> UserRoles(string id)
        //{
        //    try
        //    {
        //        var viewModel = new List<UserRolesVM>();
        //        var user = await _userManager.FindByIdAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        foreach (var role in _roleManager.Roles)
        //        {
        //            var userRolesViewModel = new UserRolesVM
        //            {
        //                RoleName = role.Name
        //            };
        //            if (await _userManager.IsInRoleAsync(user, role.Name))
        //            {
        //                userRolesViewModel.Selected = true;
        //            }
        //            else
        //            {
        //                userRolesViewModel.Selected = false;
        //            }
        //            viewModel.Add(userRolesViewModel);
        //        }
        //        var model = new ManageUserRolesVM()
        //        {
        //            UserId = id,
        //            UserRoles = viewModel
        //        };
        //        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", model));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
        //    }

        //}
        //Zinish
        [HttpGet("UserRoles")]
        public async Task<IActionResult> UserRoles(string id)
        {
            try
            {
                var viewModel = new List<UserRolesVM>();
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in _roleManager.Roles)
                {
                    var userRolesViewModel = new UserRolesVM
                    {
                        RoleName = role.Name,
                        Selected = userRoles.Contains(role.Name) // Check if the user is in the role
                    };
                    viewModel.Add(userRolesViewModel);
                }

                var model = new ManageUserRolesVM()
                {
                    UserId = id,
                    UserRoles = viewModel
                };

                return Ok(new ResponseModel(ResponseCode.OK, "User roles retrieved successfully", model));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Zinish

        [HttpGet("SpecificUserRoles")]
        public async Task<IActionResult> SpecificUserRoles(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                var model = new UserRolesResponseModel
                {
                    UserId = userId,
                    UserRoles = userRoles.ToList()
                };

                return Ok(new ResponseModel(ResponseCode.OK, "User roles retrieved successfully", model));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user roles");
            }
        }

        //[HttpPut("UpdateUserRoles")]
        //public async Task<object> UpdateUserRoles(string userId, ManageUserRolesVM model)
        //{
        //    try
        //    {
        //        var user = await _userManager.FindByIdAsync(userId);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        var roles = await _userManager.GetRolesAsync(user);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        var result = await _userManager.RemoveFromRolesAsync(user, roles);
        //        if (result.Succeeded)
        //        {
        //            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
        //            var currentUser = await _userManager.GetUserAsync(User);
        //            await _signInManager.RefreshSignInAsync(currentUser);
        //            UserAndRoleDataInitializer.SeedData(_userManager, _roleManager);
        //            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Users roles updated succfully", null));
        //        }
        //        return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something went wrong please try again later", null));

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
        //    }
        //}

        //
        //Zinish
        [HttpPut("UpdateUserRoles")]
        public async Task<IActionResult> UpdateUserRoles(string userId, ManageUserRolesVM model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Remove all existing roles
                var rolesToRemove = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

                if (!removeResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to remove user roles");
                }

                // Add the selected roles
                var selectedRoles = model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName);
                var addResult = await _userManager.AddToRolesAsync(user, selectedRoles);

                if (addResult.Succeeded)
                {
                    // Refresh the user's authentication token
                    await _signInManager.RefreshSignInAsync(user);

                    // Optionally, reseed data if needed
                    UserAndRoleDataInitializer.SeedData(_userManager, _roleManager);

                    return Ok(new ResponseModel(ResponseCode.OK, "User roles updated successfully", null));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add user roles");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user roles");
            }
        }
        //private string GenerateToken(ApplicationUser user, List<string> roles)
        //{
        //    var claims = new List<Claim>(){
        //       new Claim(JwtRegisteredClaimNames.NameId,user.Id),
        //       new Claim(JwtRegisteredClaimNames.Email,user.Email),
        //       new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //   };
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    var jwtTokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jWTConfig.Key);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddHours(12),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //        Audience = _jWTConfig.Audience,
        //        Issuer = _jWTConfig.Issuer
        //    };
        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        //    return jwtTokenHandler.WriteToken(token);
        //}

        private string GenerateToken(ApplicationUser user, List<string> roles)
        {
            var claims = new List<Claim>(){
               new Claim(JwtRegisteredClaimNames.NameId,user.Id),
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }

}
