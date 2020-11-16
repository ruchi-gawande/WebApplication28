using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication28.Models
{
    public class LoginModel
    {
       

        [Required(ErrorMessage = "User Name is required for login.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Email id is required for login.")]
        public string email { get; set; }
    }
}