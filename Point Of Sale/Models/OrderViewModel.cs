using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Point_Of_Sale.Models
{
    public class OrderViewModel
    {
        public DateTime Date { get; set; }
        public List<ListItems> Items { get; set; }
    }

    public class ListItems
    {
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}