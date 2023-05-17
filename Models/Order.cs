using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string OrderName { get; set; }
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNotes { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
    }
}