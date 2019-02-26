using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_Challenge.Models
{
    public class SWBusinessLogic : DbContext
    {
        private readonly SW_TechContext _context;
        public SWBusinessLogic(SW_TechContext context)
        {
            _context = context;
        }

        public IQueryable<Atm> GetFilteredATM(SWSearchModel searchModel)
        {
            //TODO: CREATE STORED PROCEDURE TO FETCH FILTERED DATA
            var result = _context.Atm.AsQueryable();

            if (searchModel != null)
            {
                //TODO: CREATE FOREACH STATEMENT
                if (!string.IsNullOrEmpty(searchModel.Barrio))
                    result = result.Where(x => x.Barrio.Contains(searchModel.Barrio));
                if (!string.IsNullOrEmpty(searchModel.CodigoPostalArgentino))
                    result = result.Where(x => x.CodigoPostalArgentino.Contains(searchModel.CodigoPostalArgentino));
                if (!string.IsNullOrEmpty(searchModel.Banco))
                    result = result.Where(x => x.Banco.Contains(searchModel.Banco));
                if (!string.IsNullOrEmpty(searchModel.Red))
                    result = result.Where(x => x.Red.Contains(searchModel.Red));
                if (!string.IsNullOrEmpty(searchModel.Ubicacion))
                    result = result.Where(x => x.Ubicacion.Contains(searchModel.Ubicacion));
                if (!string.IsNullOrEmpty(searchModel.Localidad))
                    result = result.Where(x => x.Localidad.Contains(searchModel.Localidad));
                if (searchModel.Terminales.HasValue)
                    result = result.Where(x => x.Terminales == searchModel.Terminales);
                if (searchModel.NoVidente.HasValue)
                    result = result.Where(x => x.NoVidente == searchModel.NoVidente);
                if (searchModel.Dolares.HasValue)
                    result = result.Where(x => x.Dolares == searchModel.Dolares);

            }
            return result;
        }


        public IQueryable<Biblioteca> GetFilteredLibraries(SWSearchModel searchModel)
        {
            var result = _context.Biblioteca.AsQueryable();

            if (searchModel != null)
            {
                //TODO: CREATE FOREACH STATEMENT
                if (!string.IsNullOrEmpty(searchModel.Barrio))
                    result = result.Where(x => x.Barrio.Contains(searchModel.Barrio));
                if (!string.IsNullOrEmpty(searchModel.CodigoPostalArgentino))
                    result = result.Where(x => x.CodigoPostalArgentino.Contains(searchModel.CodigoPostalArgentino));
                if (!string.IsNullOrEmpty(searchModel.Nombre))
                    result = result.Where(x => x.Nombre.Contains(searchModel.Nombre));
                if (!string.IsNullOrEmpty(searchModel.Telefono))
                    result = result.Where(x => x.Telefono.Contains(searchModel.Telefono));
                if (!string.IsNullOrEmpty(searchModel.Observaciones))
                    result = result.Where(x => x.Observaciones.Contains(searchModel.Observaciones));
                if (!string.IsNullOrEmpty(searchModel.DireccionNormalizada))
                    result = result.Where(x => x.DireccionNormalizada.Contains(searchModel.DireccionNormalizada));
                if (!string.IsNullOrEmpty(searchModel.Piso))
                    result = result.Where(x => x.Piso.Contains(searchModel.Piso));
                if (!string.IsNullOrEmpty(searchModel.Piso))
                    result = result.Where(x => x.Piso.Contains(searchModel.Piso));
                if (!string.IsNullOrEmpty(searchModel.Piso))
                    result = result.Where(x => x.Piso.Contains(searchModel.Piso));
            }
            return result;
        }

        public IQueryable<Farmacia> GetFilteredFarmacies(SWSearchModel searchModel)
        {
            var result = _context.Farmacia.AsQueryable();

            if (searchModel != null)
            {
                //TODO: CREATE FOREACH STATEMENT
                if (!string.IsNullOrEmpty(searchModel.Barrio))
                    result = result.Where(x => x.Barrio.Contains(searchModel.Barrio));
                if (!string.IsNullOrEmpty(searchModel.CodigoPostalArgentino))
                    result = result.Where(x => x.CodigoPostalArgentino.Contains(searchModel.CodigoPostalArgentino));
                if (!string.IsNullOrEmpty(searchModel.Telefono))
                    result = result.Where(x => x.Telefono.Contains(searchModel.Telefono));
                if (!string.IsNullOrEmpty(searchModel.CalleNombre))
                    result = result.Where(x => x.CalleNombre.Contains(searchModel.CalleNombre));
                if (searchModel.CalleAltura.HasValue)
                    result = result.Where(x => x.CalleAltura == searchModel.CalleAltura);
                if (!string.IsNullOrEmpty(searchModel.CalleCruce))
                    result = result.Where(x => x.CalleCruce.Contains(searchModel.CalleCruce));
                if (!string.IsNullOrEmpty(searchModel.Barrio))
                    result = result.Where(x => x.Barrio.Contains(searchModel.Barrio));
            }
            return result;
        }

        //TODO: IMPLEMENT DISPOSE METHOD.
    }
}
