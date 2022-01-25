using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.Models
{
    public class Login
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50, MinimumLength = 3)]

        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       // [Required(ErrorMessage = "Email Required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]

        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password Required")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public int Epic { get; set; }

        //[Display(Name = "Full Name")]
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}