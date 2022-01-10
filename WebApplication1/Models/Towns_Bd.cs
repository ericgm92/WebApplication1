using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Towns_Bd
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }
}
