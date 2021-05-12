using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apka_NET.Models
{
    public class Address
    {
        [Key]
        public int Id{ get; set; }
        public int Number { get; set; }
        public string Napis { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe!")]
        [MaxLength(10)]
        public string NumberString { get; set; }
        public DateTime SystemTime { get; set; }
    }
}
