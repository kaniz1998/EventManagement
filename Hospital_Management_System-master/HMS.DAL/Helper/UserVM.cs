using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HMS.Models.ViewModels
{
    public class UserVM
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string UserName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        public string ImageName { get; set; }
        public bool IsChecked { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class LoginVM
    {
        [Required]

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsChecked { get; set; }

        [Required, MaxLength(80)]
        public string FirstName { get; set; }

        [Required, MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
        public string ImageName { get; set; }

        public string Token { get; set; }
    }
    public class UserRolesVM
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }
        public string? JsonData { get; set; }
        public bool Selected { get; set; }
        public List<string> Users { get; set; }
    }
    public class ManageUserRolesVM
    {
        public string UserId { get; set; }
        public IList<UserRolesVM> UserRoles { get; set; }
    }
    //Something is missing Recall tutorial
    
    public class UserWiseRoleVM
    {
        [Display(Name = "User  Id")]
        [Key]
        public int uwrId { get; set; }

        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Image")]
        public string ImageName { get; set; }

        [Display(Name = "User Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
    public class UserRolesResponseModel
    {
        public string UserId { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
