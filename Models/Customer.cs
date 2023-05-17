using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string AddressID { get; set; }
    }
}