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
    
    public partial class IssuedBooks
    {
        public int SNO { get; set; }
        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
        public string category { get; set; }
        public string UserEmail { get; set; }
        public System.DateTime IssuedON { get; set; }
        public System.DateTime ReturnON { get; set; }
        public Nullable<int> Fine { get; set; }
    }
}
