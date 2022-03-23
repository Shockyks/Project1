using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace models
{
    public class Let
    {
        [Key]
        public int ID { get; set; }
        [JsonIgnore]
        public Aerodrom Aerodrom { get; set; }
        [Range(0, 200)]
        public int BrojMesta { get; set; }
        [JsonIgnore]
        public Klasa Klasa { get; set; }
        public string DatumLeta { get; set; }
        public string VremePolaska { get; set; }
        public string VremeDolaska { get; set; }

    }
}