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
    public class PAdministracion
    {
        #region variables de la clase

        //Variable interfaceProducto para enviar la informacion al formulario por medio de la interface a la tablas de la base de datos 
        public IAdministracion interfaceAdministacion;

        //Variable contexto para acceder a las tablas de la base de datos
        BDInfoTransformacionEntities contexto = new BDInfoTransformacionEntities();

             

        /// <summary>
        //Metodo Constuctor
        /// <summary>
        public PAdministracion(IAdministracion vista)
        {
            interfaceAdministacion = vista;
        }
        #endregion

        #region Cargue Inicial
        /// <summary>
        /// Método para cargar la grilla categorias
        /// </summary>
        public void CargarInformacioninicial()
        {
            try
            {
                CargarAplicaciones();
                CargarTemas();
                               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Aplicaciones

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarAplicaciones()
        {
            try
            {
                var aplicaciones = contexto.tbAplicacion.ToList();
                interfaceAdministacion.GrillaAplicaciones = aplicaciones;
                interfaceAdministacion.AplicacionesTema = aplicaciones;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearAplicacion()
        {
            try
            {
                var existe = contexto.tbAplicacion.Where(x => x.Nombre == interfaceAdministacion.NombreAplicacion).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("La aplicación ya existe");
                }
                else
                {
                    tbAplicacion aplicacion = new tbAplicacion();
                    aplicacion.Nombre = interfaceAdministacion.NombreAplicacion;
                    aplicacion.AW = interfaceAdministacion.AW;
                    contexto.tbAplicacion.Add(aplicacion);
                    contexto.SaveChanges();
                    CargarAplicaciones();
                    interfaceAdministacion.NombreAplicacion = "";
                    interfaceAdministacion.AW = "";
                    EnviarMensajeUsuario("Registro creado satisfactoriamente");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para editar un registro de la grilla categoria Aplicaciones
        /// </summary>
        public void ActualizarAplicacion(int idAplicacion)
        {
            try
            {
                var aplicacion = contexto.tbAplicacion.Where(x => x.Id == idAplicacion).First();

                aplicacion.Nombre = interfaceAdministacion.NombreAplicacion;
                aplicacion.AW = interfaceAdministacion.AW;
                contexto.SaveChanges();
                interfaceAdministacion.NombreAplicacion = "";
                interfaceAdministacion.AW = "";
                CargarAplicaciones();
                EnviarMensajeUsuario("Registro actualizado satisfactoriamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para editar un registro de la grilla categoria Aplicaciones
        /// </summary>
        public void CargarInfoAplicacion(int idAplicacion)
        {
            try
            {
                var aplicacion = contexto.tbAplicacion.Where(x => x.Id == idAplicacion).First();

                interfaceAdministacion.NombreAplicacion = aplicacion.Nombre;
                interfaceAdministacion.AW = aplicacion.AW;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para eliminar un registro de la grilla Aplicaciones
        /// </summary>
        public void EliminarAplicacion(int idAplicacion)
        {
            try
            {
                tbAplicacion aplicacion = contexto.tbAplicacion.Where(x => x.Id == idAplicacion).First();
                contexto.tbAplicacion.Remove(aplicacion);
                contexto.SaveChanges();
                CargarAplicaciones();
                EnviarMensajeUsuario("Registro eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                EnviarMensajeUsuario("No se puede eliminar el registro debido a que se encuentran contenidos asociados a la aplicación");
            }
        }
    
        #endregion

        #region Contenidos

        /// <summary>
        /// Método para cargar la grilla Contenidos
        /// </summary>
        public void CargarTemas()
        {
            try
            {
                int idAplicacion = Convert.ToInt32(interfaceAdministacion.AplicacionesTema);
                var temas = contexto.tbTema.Where(x=> x.IdAplicacion==idAplicacion).ToList();
                interfaceAdministacion.GrillaTemas = temas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearTema()
        {
            try
            {
                int idAplicacion = Convert.ToInt32(interfaceAdministacion.AplicacionesTema);
                var existe = contexto.tbTema.Where(x => x.Nombre == interfaceAdministacion.NombreTema && x.IdAplicacion== idAplicacion).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("El tema ya existe");
                }
                else
                {
                    tbTema tema = new tbTema();
                    tema.IdAplicacion = idAplicacion;
                    tema.Nombre = interfaceAdministacion.NombreTema;
                    contexto.tbTema.Add(tema);
                    contexto.SaveChanges();
                    CargarTemas();
                    interfaceAdministacion.NombreTema = "";
                    EnviarMensajeUsuario("Registro creado satisfactoriamente");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para editar un registro de la grilla categoria Aplicaciones
        /// </summary>
        public void ActualizarTema(int idTema)
        {
            try
            {
                var tema = contexto.tbTema.Where(x => x.Id == idTema).First();

                tema.Nombre = interfaceAdministacion.NombreTema;
                contexto.SaveChanges();
                interfaceAdministacion.NombreTema = "";
                int idAplicacion = Convert.ToInt32(tema.IdAplicacion);
                var temas = contexto.tbTema.Where(x => x.IdAplicacion == idAplicacion).ToList();
                interfaceAdministacion.GrillaTemas = temas;
                EnviarMensajeUsuario("Registro actualizado satisfactoriamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para editar un registro de la grilla categoria Aplicaciones
        /// </summary>
        public void CargarInfoTema(int idTema)
        {
            try
            {
                var tema = contexto.tbTema.Where(x => x.Id == idTema).First();

                interfaceAdministacion.NombreTema = tema.Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para eliminar un registro de la grilla Aplicaciones
        /// </summary>
        public void EliminarTema(int idTema)
        {
            try
            {
                tbTema tema = contexto.tbTema.Where(x => x.Id == idTema).First();
                contexto.tbTema.Remove(tema);
                contexto.SaveChanges();
                int idAplicacion = Convert.ToInt32(interfaceAdministacion.AplicacionesTema);
                var temas = contexto.tbTema.Where(x => x.IdAplicacion == idAplicacion).ToList();
                interfaceAdministacion.GrillaTemas = temas;
                EnviarMensajeUsuario("Registro eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                EnviarMensajeUsuario("No se puede eliminar el registro debido a que se encuentran temas asociados al contenido");
            }
        }

        #endregion

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

                this.interfaceAdministacion.MensajePopud = mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
