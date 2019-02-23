using siliconTestMVC5.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siliconTestMVC5.Models
{
    public class ViewCategoriesModel
    {
        public int ChildredCount { get; set; }
        public Category Item { get; set; }
    }
}