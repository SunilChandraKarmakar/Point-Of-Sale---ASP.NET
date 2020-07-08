using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Point_Of_Sale.Models
{
    public class CustomerAndPurchaseViewModel
    {
        public string CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
        public List<PurchaseItem> Items { get; set; }
    }

    public class PurchaseItem
    {                              
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}