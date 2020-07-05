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

    public partial class Purchase
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Select Customer")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Select Product")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.PhoneNumber)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [DataType(DataType.PhoneNumber)]
        public int Quantity { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
