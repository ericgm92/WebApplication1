using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Gestores_Bd
    {
        [Key]
        public int id { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }
        public int poblacion { get; set; }
    }
}
