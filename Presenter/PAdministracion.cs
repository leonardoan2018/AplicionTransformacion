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
                CargarProyectos();
                CargarIniciativas();
                CargarTemas();
                               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Proyectos

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarProyectos()
        {
            try
            {
                var proyectos = contexto.tbProyecto.ToList();
                interfaceAdministacion.GrillaProyectos = proyectos;
                interfaceAdministacion.ProyectosIniciativas = proyectos;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearProtecto()
        {
            try
            {
                var existe = contexto.tbProyecto.Where(x => x.Nombre == interfaceAdministacion.NombreProyecto).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("La aplicación ya existe");
                }
                else
                {
                    tbProyecto aplicacion = new tbProyecto();
                    aplicacion.Nombre = interfaceAdministacion.NombreProyecto;
                    aplicacion.AW = interfaceAdministacion.AW;
                    contexto.tbProyecto.Add(aplicacion);
                    contexto.SaveChanges();
                    CargarProyectos();
                    interfaceAdministacion.NombreProyecto = "";
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
        public void ActualizarProyecto(int idProyecto)
        {
            try
            {
                var aplicacion = contexto.tbProyecto.Where(x => x.Id == idProyecto).First();

                aplicacion.Nombre = interfaceAdministacion.NombreProyecto;
                aplicacion.AW = interfaceAdministacion.AW;
                contexto.SaveChanges();
                interfaceAdministacion.NombreProyecto = "";
                interfaceAdministacion.AW = "";
                CargarProyectos();
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
        public void CargarInfoProyecto(int idProyecto)
        {
            try
            {
                var proyecto = contexto.tbProyecto.Where(x => x.Id == idProyecto).First();

                interfaceAdministacion.NombreProyecto = proyecto.Nombre;
                interfaceAdministacion.AW = proyecto.AW;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para eliminar un registro de la grilla Aplicaciones
        /// </summary>
        public void EliminarProyecto(int idProyecto)
        {
            try
            {
                tbProyecto aplicacion = contexto.tbProyecto.Where(x => x.Id == idProyecto).First();
                contexto.tbProyecto.Remove(aplicacion);
                contexto.SaveChanges();
                CargarProyectos();
                EnviarMensajeUsuario("Registro eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                EnviarMensajeUsuario("No se puede eliminar el registro debido a que se encuentran contenidos asociados a la Iniciativa");
            }
        }

        #endregion

        #region Iniciativas

        /// <summary>
        /// Método para cargar la grilla Iniciativas
        /// </summary>
        public void CargarIniciativas()
        {
            try
            {
                int idProyecto = Convert.ToInt32(interfaceAdministacion.ProyectosIniciativas);
                var iniciativas = contexto.tbIniciativa.Where(x=>x.IdProyecto==idProyecto).ToList();
                interfaceAdministacion.GrillaIniciativas = iniciativas;
                interfaceAdministacion.IniciativasTema = iniciativas;
      

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearIniciativa()
        {
            try
            {
                var existe = contexto.tbIniciativa.Where(x => x.Nombre == interfaceAdministacion.NombreIniciativa).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("La iniciativa ya existe");
                }
                else
                {

                    int idProyecto = Convert.ToInt32(interfaceAdministacion.ProyectosIniciativas);
                    tbIniciativa iniciativa = new tbIniciativa();
                    iniciativa.IdProyecto= idProyecto;
                    iniciativa.Nombre = interfaceAdministacion.NombreIniciativa;
                    iniciativa.PMO = interfaceAdministacion.PMOIniciativa;
                    contexto.tbIniciativa.Add(iniciativa);
                    contexto.SaveChanges();
                    CargarIniciativas();
                    interfaceAdministacion.NombreIniciativa = "";
                    interfaceAdministacion.PMOIniciativa = "";
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
        public void ActualizarIniciativa(int idIniciativa)
        {
            try
            {
                var iniciativa = contexto.tbIniciativa.Where(x => x.Id == idIniciativa).First();
                iniciativa.IdProyecto = Convert.ToInt32(interfaceAdministacion.ProyectosIniciativas);
                iniciativa.Nombre = interfaceAdministacion.NombreProyecto;
                iniciativa.PMO = interfaceAdministacion.PMOIniciativa;
                contexto.SaveChanges();
                interfaceAdministacion.NombreIniciativa = "";
                interfaceAdministacion.PMOIniciativa = "";
                CargarIniciativas();
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
        public void CargarInfoIniativa(int idIniciativa)
        {
            try
            {
                var iniciativa = contexto.tbIniciativa.Where(x => x.Id == idIniciativa).First();
                interfaceAdministacion.NombreIniciativa = iniciativa.Nombre;
                interfaceAdministacion.PMOIniciativa = iniciativa.PMO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para eliminar un registro de la grilla Aplicaciones
        /// </summary>
        public void EliminarIniciativa(int idIniciativa)
        {
            try
            {
                tbIniciativa iniciativa = contexto.tbIniciativa.Where(x => x.Id == idIniciativa).First();
                contexto.tbIniciativa.Remove(iniciativa);
                contexto.SaveChanges();
                CargarIniciativas();
                EnviarMensajeUsuario("Registro eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                EnviarMensajeUsuario("No se puede eliminar el registro debido a que se encuentran contenidos asociados a la Iniciativa");
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
                int idIniciativa = Convert.ToInt32(interfaceAdministacion.IniciativasTema);
                var temas = contexto.tbTema.Where(x=> x.IdIniciativa== idIniciativa).ToList();
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
                int idIniciativa = Convert.ToInt32(interfaceAdministacion.IniciativasTema);
                var existe = contexto.tbTema.Where(x => x.Nombre == interfaceAdministacion.NombreTema && x.IdIniciativa== idIniciativa).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("El tema ya existe");
                }
                else
                {
                    tbTema tema = new tbTema();
                    tema.IdIniciativa = idIniciativa;
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
                int idIniciativa = Convert.ToInt32(tema.IdIniciativa);
                var temas = contexto.tbTema.Where(x => x.IdIniciativa == idIniciativa).ToList();
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
                int idIniciativa = Convert.ToInt32(interfaceAdministacion.IniciativasTema);
                var temas = contexto.tbTema.Where(x => x.IdIniciativa == idIniciativa).ToList();
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
