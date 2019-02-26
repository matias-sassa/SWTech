using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_Challenge.Models
{
    public class SWSearchModel
    {
        //TODO: CREATE IENUMERATOR
        #region Shared
        public string Barrio { get; set; }
        public string CodigoPostalArgentino { get; set; }
        #endregion

        #region ATM
        public string Banco { get; set; }
        public string Red { get; set; }
        public string Ubicacion { get; set; }
        public string Localidad { get; set; }
        public int? Terminales { get; set; }
        public bool? NoVidente { get; set; }
        public bool? Dolares { get; set; }
        #endregion

        #region FARMACIA
        public string Telefono { get; set; }
        public string CalleNombre { get; set; }
        public double? CalleAltura { get; set; }
        public string CalleCruce { get; set; }
        #endregion

        #region BIBLIOTECA
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Calle2 { get; set; }
        public string Piso { get; set; }
        public string Observaciones { get; set; }
        public string DireccionNormalizada { get; set; }
        #endregion
    }
}
