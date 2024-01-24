using ETicaret.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entities
{
    public class Product : CoreEntity
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageName { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
