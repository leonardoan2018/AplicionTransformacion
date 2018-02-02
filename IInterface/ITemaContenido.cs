using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IInterface
{
    public interface ITemaContenido
    {
        #region Grillas

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaContenidos { set; }
        
        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaTemas { set; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        object GrillaAdjuntos { set; }

        #endregion

        #region Controles

        /// <summary>
        /// Clase de tipo Interface que proporciona campos para comunicar la Vista y el Presentador PAdminEntidades
        /// </summary>
        object AplicacionesTema { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string NombreContenido { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string DescripcionContenido { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string DetalleNombreContenido { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string DetalleDescripcionContenido { set; get; }

        /// <summary>
        /// Clase de tipo Interface para comunicar la Vista y el Presentador 
        /// </summary>
        string MensajePopud { set; }

        #endregion
    }
}
