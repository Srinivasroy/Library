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


    public partial class Online_Book_Orders
    {
      
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_Name { get; set; }
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Area is Required")]
        public string Area { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code is Required")]
        public string Postal_Code { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone_Number { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }


    }
}
