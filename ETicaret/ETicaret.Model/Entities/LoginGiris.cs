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
    public class LoginGiris : CoreEntity
    {
        
        [Column(TypeName="Varchar(20)")]
        public string Kullanıcı {  get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string Sifre {  get; set; }

    }
}
