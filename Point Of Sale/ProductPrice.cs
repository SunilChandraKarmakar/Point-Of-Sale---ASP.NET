//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Point_Of_Sale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ProductPrice
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Select Product")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "OrigPricein")]
        [DataType(DataType.PhoneNumber)]
        public double ProductPrice1 { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
