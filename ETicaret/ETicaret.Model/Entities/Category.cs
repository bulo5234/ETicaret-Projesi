using ETicaret.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entities
{
    public class Category: CoreEntity
    {
        
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        [ForeignKey("CategoryID")] 
        public ICollection<Category> Categories { get; set;} 
    }
}
