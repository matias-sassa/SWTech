using System;
using System.Collections.Generic;

namespace Tech_Challenge.Models
{
    public partial class Atm
    {
        public int Id { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string Banco { get; set; }
        public string Red { get; set; }
        public string Ubicacion { get; set; }
        public string Localidad { get; set; }
        public int Terminales { get; set; }
        public bool NoVidente { get; set; }
        public bool Dolares { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Calle2 { get; set; }
        public string Barrio { get; set; }
        public string Comuna { get; set; }
        public int? CodigoPostal { get; set; }
        public string CodigoPostalArgentino { get; set; }
    }
}
