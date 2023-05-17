using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class Spec
    {
        [Key]
        public int Id { get; set; }
        public int SpecID { get; set; }
        public string SizeName { get; set; }
        public string SizeOrder { get; set; }
        public string SpecName { get; set; }
        public string Value { get; set; }
    }
}