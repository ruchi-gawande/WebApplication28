//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication28.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class joinnow
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date Of Birth is required.")]
        [Display(Name = "Date Of Birth")]
        public string DOB { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City Name is required.")]
        [Display(Name = "City ")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "State Name is required.")]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country Name is required.")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact detail is required.")]
        [Display(Name = "Phone number")]
        public Nullable<long> Contact { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is required.")]
        [Display(Name = "Email Id")]
        public string Email_Id { get; set; }
    }
}
