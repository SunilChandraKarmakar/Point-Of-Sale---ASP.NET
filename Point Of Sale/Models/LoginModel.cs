using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Point_Of_Sale.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "Email")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display (Name = "Password")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Display (Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}