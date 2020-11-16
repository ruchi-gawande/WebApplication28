using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication28.Models
{
    public class UserModel
    {
        public int userid { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="User Name is required.")]
        [Display(Name ="User Name")]
        public string username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is required.")]
        [Display(Name = "Age")]
        public int age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Name is required.")]
        [Display(Name = "Email Id")]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string state{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required.")]
        [Display(Name = "Country")]
        public string country{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact is required.")]
        [Display(Name = "Contact")]
        public int contact { get; set; }

        public string Success { get; set; }


    }
}