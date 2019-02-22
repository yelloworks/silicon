using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace siliconTestMVC5.Models.Entities
{
    public class Product
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public byte[] Image { get; set; }

        public string CurrentCategoryName { get; set; }
        public Category CurrentCategory { get; set; }
    }
}