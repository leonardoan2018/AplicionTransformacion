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
    public class PTemaContenido
    {
        #region variables de la clase

        //Variable interfaceProducto para enviar la informacion al formulario por medio de la interface a la tablas de la base de datos 
        public ITemaContenido interfaceItemContenido;

        //Variable contexto para acceder a las tablas de la base de datos
        BDInfoTransformacionEntities contexto = new BDInfoTransformacionEntities();



        /// <summary>
        //Metodo Constuctor
        /// <summary>
        public PTemaContenido(ITemaContenido vista)
        {
            interfaceItemContenido = vista;
        }
        #endregion

        #region Informacion Inicial

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarInformacionInicial()
        {
            try
            {
                CargarAplicaciones();
                CargarGrillaTemas();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarAplicaciones()
        {
            try
            {
                var aplicaciones = contexto.tbIniciativa.ToList();
                interfaceItemContenido.AplicacionesTema = aplicaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaTemas()
        {
            try
            {
                int idAplicacion = Convert.ToInt32(interfaceItemContenido.AplicacionesTema);
                var temas = contexto.tbTema.Where(x=>x.IdIniciativa==idAplicacion).ToList();
                interfaceItemContenido.GrillaTemas = temas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaContenidos(int idTema, int idAplicacion)
        {
            try
            {
                var contenidos = contexto.tbContenido.Where(x => x.Id == idAplicacion && x.IdTema==idTema).ToList();
                interfaceItemContenido.GrillaContenidos = contenidos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarInfoContenido(int idContenido)
        {
            try
            {
                var contenido = contexto.tbContenido.Where(x => x.Id == idContenido).First();
                interfaceItemContenido.NombreContenido = contenido.Nombre;
                interfaceItemContenido.DescripcionContenido = contenido.Descripcion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void ActualizarInfoContenido(int idContenido, int idAplicacion)
        {
            try
            {
                //var contenido = contexto.tbContenido.Where(x => x.Id == idContenido).First();
                //contenido.Nombre= interfaceItemContenido.NombreContenido;
                //contenido.Descripcion= interfaceItemContenido.DescripcionContenido;
                //contexto.SaveChanges();
                //interfaceItemContenido.NombreContenido = "";
                //interfaceItemContenido.DescripcionContenido = "";
                //CargarGrillaContenidos(Convert.ToInt32(contenido.IdTema), Convert.ToInt32(contenido.IdAplicacion));
                //EnviarMensajeUsuario("Registro actualizado Satisfactoriamente");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaContenidosBusqueda(int idTema, int idAplicacion, string criterio, string palabra)
        {
            try
            {
                //var contenidos = contexto.tbContenido.Where(x => x.IdAplicacion == idAplicacion && x.IdTema == idTema).ToList();

                //if (criterio == "Todo")
                //{
                //    contenidos = contexto.tbContenido.Where(x => x.Nombre.Contains(palabra) || x.Descripcion.Contains(palabra)).ToList();

                //}
                //else if (criterio == "Nombre")
                //{
                //    contenidos = contenidos.Where(x => x.Nombre.Contains(palabra)).ToList();
                //}
                //else
                //{
                //    contenidos = contenidos.Where(x => x.Descripcion.Contains(palabra)).ToList();
                //}


                //interfaceItemContenido.GrillaContenidos = contenidos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaAdjuntosDetalle(int idContenido)
        {
            try
            {
                var adjuntos = contexto.tbAdjunto.Where(x => x.IdContenido==idContenido).ToList();
                interfaceItemContenido.GrillaAdjuntos = adjuntos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarDetalleContenido(int idContenido)
        {
            try
            {
                var contenido = contexto.tbContenido.Where(x => x.Id == idContenido).First();
                interfaceItemContenido.DetalleNombreContenido = contenido.Nombre;
                interfaceItemContenido.DetalleDescripcionContenido = contenido.Descripcion;
                CargarGrillaAdjuntosDetalle(idContenido);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Método para cargar la lista de los estados
        /// </summary>
        public void CrearAdjunto(int idContenido, string nombreArchivo, string rutaAdjunto)
        {
            try
            {
                tbAdjunto adjunto = new tbAdjunto();
                adjunto.IdContenido = idContenido;
                adjunto.Nombre = nombreArchivo;
                adjunto.RutaAdjunto=rutaAdjunto;
                contexto.tbAdjunto.Add(adjunto);
                contexto.SaveChanges();
                CargarGrillaAdjuntosDetalle(idContenido);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Método para cargar la lista de los estados
        /// </summary>
        public void EliminarAdjunto(int idAdjunto, int idContenido)
        {
            try
            {
                tbAdjunto adjunto = contexto.tbAdjunto.Where(x => x.Id == idAdjunto).First();
                contexto.tbAdjunto.Remove(adjunto);
                contexto.SaveChanges();
                CargarGrillaAdjuntosDetalle(idContenido);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Metodos


        #region Mensajes

        /// <summary>
        /// Método que se encarga de enviar un mensaje al usuario junto con un icono que muestra la gravedad del mensaje.
        /// </summary>
        /// <param name="mensaje">Parámero que se encarga de traer el valor del mesaje que será mostrado al usuario.</param>
        /// <param name="tipoMensaje">Parámtero que se encarga de traer el tipo de mensaje que será mostrado al usuario.</param>
        public void EnviarMensajeUsuario(string mensaje)
        {
            // Se capturan los errores que se puedan presentar en la ejecución de las instrucciones del método.
            try
            {

                this.interfaceItemContenido.MensajePopud = mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
