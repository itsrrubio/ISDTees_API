using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISDTees_API.Models
{
    public class Style
    {
        [Key]
        public int Id { get; set; }
        public int StyleID { get; set; }
        public string PartNumber { get; set; }
        public string BrandName { get; set; }
        public string StyleName { get; set; }
        public string UniquestyleName { get; set; }
        public string Title { get; set; }
        public string BaseCategory { get; set; }
        public int ComparableGroup { get; set; }
        public int CompanionGroup { get; set; }
    }
}