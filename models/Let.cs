using System;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Let
    {
        [Key]
        public int ID { get; set; }
        public Aerodrom Aerodrom1 { get; set; }
        public Aerodrom Aerodrom2 { get; set; }
        public int Cena { get; set; }
        public int BrojMesta { get; set; }
        public int BrojPutnika { get; set; }
        public Klasa Klasa { get; set; }
        public DateTime DatumLeta { get; set; }
        public TimeSpan VremePolaska { get; set; }
        public TimeSpan VremeDolaska { get; set; }

    }
}