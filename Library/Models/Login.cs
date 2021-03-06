//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Login
    {

        
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]

        public String ConfirmPassword { get; set; }

        //public string ConfirmPassword { get; set; }

        public int Epic { get; set; }
    }
}
