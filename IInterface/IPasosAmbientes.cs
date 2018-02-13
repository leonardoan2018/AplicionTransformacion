using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IInterface
{
    public interface IPasosAmbientes
    {
        object Ambientes { get; set; }
        object Aplicaciones { get; set; }
        object Persona { get; set; }
        string NroOC { get; set; }
        string Resultado { set; get; }
        string NroHarvest { get; set; }
        object GrillaInfoPasos { set; }
        string FechaInstalacion { get; set; }
        string Descripcion { get; set; }
        string MensajePopup { set; }
    }
}
