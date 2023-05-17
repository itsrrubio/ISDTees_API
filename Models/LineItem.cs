using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class LineItem
    {
        [Key]
        public int Id { get; set; }
        public string LineItemID { get; set; }
        public string ProductID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}