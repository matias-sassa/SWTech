using System;
using System.Collections.Generic;

namespace Tech_Challenge.Models
{
    public partial class Biblioteca
    {
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Calle2 { get; set; }
        public string Piso { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
        public string DireccionNormalizada { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string Barrio { get; set; }
        public string Comuna { get; set; }
        public int? CodigoPostal { get; set; }
        public string CodigoPostalArgentino { get; set; }
        public int BibliotecaId { get; set; }
    }
}
