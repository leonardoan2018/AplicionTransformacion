using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IInterface
{
    public interface IAdministracion
    {
        #region Grillas

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaAplicaciones { set; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaTemas { set; }

        #endregion

        #region Controles

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreAplicacion { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string AW { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreTema { set; get; }

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object AplicacionesTema { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string MensajePopud { set; }

        #endregion


    }
}
