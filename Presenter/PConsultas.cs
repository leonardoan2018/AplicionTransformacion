using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Objects.SqlClient;
using System.Data.Objects.ELinq;
using System.Data.Objects.Internal;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using System.Data.Entity.Validation;
using IInterface;
using Data;

namespace Presenter
{
    public class PConsultas
    {
        BDInfoTransformacionEntities contexto = new BDInfoTransformacionEntities();



        /// <summary>
        /// Método que crea una categoria
        /// </summary>
        public List<string> BuscarProducto(string prefijo)
        {
            try
            {
                var itemSubcategoria = contexto.tbItemSubcategoria
                               .Where(x => x.Nombre.Contains(prefijo)).Select(x => x.Nombre).ToList();

                return itemSubcategoria;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
