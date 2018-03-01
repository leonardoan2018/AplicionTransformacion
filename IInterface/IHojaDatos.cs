using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IInterface
{
    public interface IHojaDatos
    {
        #region Grillas

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaCategorias { set; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaSubcategorias { set; }


        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaItemSubcategorias { set; }

        #endregion

        #region Controles

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreCategoria { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreSubcategoria { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object Categorias { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object Ambientes { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object Proyectos { set; get; }


        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object Iniciativas { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreItem { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string DescripcionItem { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object AmbientesReporte { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object CategoriasReporte { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object SubcategoriasReporte { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object ReporteHojaDatos { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string MensajePopud { set; }

        #endregion
    }
}
