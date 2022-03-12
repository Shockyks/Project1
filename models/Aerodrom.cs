using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Aerodrom
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Naziv { get; set; }
        [MaxLength(50)]
        public string Grad { get; set; }
        public List<Let> Letovi { get; set; }
    }
}