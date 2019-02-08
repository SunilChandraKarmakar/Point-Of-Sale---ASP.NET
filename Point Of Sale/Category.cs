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

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Category1 = new HashSet<Category>();
            this.Products = new HashSet<Product>();
        }
    
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 2)]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string CategoryDescription { get; set; }

        [Display(Name = "Parent Category")]
        public Nullable<int> CategoryID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category1 { get; set; }
        public virtual Category Category2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
