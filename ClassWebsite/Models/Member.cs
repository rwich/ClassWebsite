using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClassWebsite.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="You must have a Username!")]
        [StringLength(20, MinimumLength =3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}