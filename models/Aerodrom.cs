using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Aerodrom
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Naziv { get; set; }
        [MaxLength(50)]
        [Required]
        public string Grad { get; set; }
        [MaxLength(50)]
        public string Drzava { get; set; }
    }
}