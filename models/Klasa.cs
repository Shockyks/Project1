using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Klasa
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Naziv { get; set; }
        public int Dodatak { get; set; }
        
    }
}