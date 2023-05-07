using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string sku { get; set; }
        public string skuID_Master { get; set; }
        public string styleID { get; set; }
        public string brandName { get; set; }
        public string styleName { get; set; }
        public string colorName { get; set; }
        public string colorCode { get; set; }
    }
}