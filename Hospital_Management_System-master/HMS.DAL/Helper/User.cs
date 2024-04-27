

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HMS.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserRoles
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }
        public string? JsonData { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, string jsonData) : base(roleName)
        {
            base.Name = roleName;

            this.JsonData = jsonData;
        }

        [Display(Name = "JsonData")]
        public string? JsonData { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public ApplicationUser(string userName) : base(userName) { }
        public ApplicationUser(string userId, string firstName, string lastName, string userName, string Email, string PhoneNumber, DateTime dateCreated, DateTime dateModified, string imageName) : base(userName)
        {
            this.Id = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            base.UserName = userName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.ImageName = imageName;
        }
        [Required, MaxLength(80)]
        public string FirstName { get; set; }

        [Required, MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }
        public string ImageName { get; set; }

    }
}
