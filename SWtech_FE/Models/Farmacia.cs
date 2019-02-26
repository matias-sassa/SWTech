using System;
using System.Collections.Generic;

namespace Tech_Challenge.Models
{
    public partial class Farmacia
    {
        public double Long { get; set; }
        public double Lat { get; set; }
        public string Telefono { get; set; }
        public string Objeto { get; set; }
        public string CalleNombre { get; set; }
        public double? CalleAltura { get; set; }
        public string CalleCruce { get; set; }
        public string Barrio { get; set; }
        public string Comuna { get; set; }
        public int? CodigoPostal { get; set; }
        public string CodigoPostalArgentino { get; set; }
        public int FarmaciaId { get; set; }
    }
}
