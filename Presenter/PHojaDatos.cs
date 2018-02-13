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
    public class PHojaDatos
    {
        #region variables de la clase

        //Variable interfaceProducto para enviar la informacion al formulario por medio de la interface a la tablas de la base de datos 
        public IHojaDatos interfaceHojaDatos;

        //Variable contexto para acceder a las tablas de la base de datos
        BDInfoTransformacionEntities contexto = new BDInfoTransformacionEntities();


        /// <summary>
        //Metodo Constuctor
        /// <summary>
        public PHojaDatos(IHojaDatos vista)
        {
            interfaceHojaDatos = vista;
        }


        #endregion

        #region Catgoria

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarInformacioninicial()
        {
            try
            {
                CargarAplicaciones();
                CargarGrillaCategorias();
                CargarGrillaSubcateogorias();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaCategorias()
        {
            try
            {
                var categorias = contexto.tbCategoriaHD.ToList();
                interfaceHojaDatos.GrillaCategorias = categorias;
                interfaceHojaDatos.Categorias = categorias;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaItem(int idSubcategoria)
        {
            try
            {
                var itemsSubcategoria = contexto.tbItemSubcategoria.Where(x => x.IdSubcategoria == idSubcategoria).ToList();
                interfaceHojaDatos.GrillaItemSubcategorias = itemsSubcategoria;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarAmbientes()
        {
            try
            {
                var ambientes = contexto.tbAmbiente.ToList();
                interfaceHojaDatos.Ambientes = ambientes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaSubcateogorias()
        {
            try
            {
                var subcategorias = (from c in contexto.tbCategoriaHD
                                     join s in contexto.tbSubCategoriaHD on c.Id equals s.IdCategoria

                                     select new
                                     {
                                         s.Id,
                                         s.IdCategoria,
                                         NombreCategoria = c.Nombre,
                                         NombreSubcategoria = s.Nombre

                                     }
                                  ).ToList();

                interfaceHojaDatos.GrillaSubcategorias = subcategorias;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaItemSubcategoria(int idSubcategoria)
        {
            try
            {

                int ambiente = Convert.ToInt32(interfaceHojaDatos.Ambientes);
                var itemSubcategorias = (from i in contexto.tbItemSubcategoria
                                         join a in contexto.tbAmbiente on i.IdAmbiente equals a.Id
                                         where i.IdAmbiente == ambiente
                                         select new
                                         {
                                             i.Id,
                                             Ambiente = a.Nombre,
                                             NombreItem = i.Nombre,
                                             i.Descripcion


                                         }
                                  ).ToList();

                interfaceHojaDatos.GrillaItemSubcategorias = itemSubcategorias;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearCategoria()
        {
            try
            {
                var existe = contexto.tbCategoriaHD.Where(x => x.Nombre == interfaceHojaDatos.NombreCategoria).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("La aplicación ya existe");
                }
                else
                {
                    int idAplicacion = Convert.ToInt32(interfaceHojaDatos.Aplicaciones);
                    tbCategoriaHD categoria = new tbCategoriaHD();
                    categoria.IdAplicacion = idAplicacion;
                    categoria.Nombre = interfaceHojaDatos.NombreCategoria;
                    contexto.tbCategoriaHD.Add(categoria);
                    contexto.SaveChanges();
                    interfaceHojaDatos.NombreCategoria = "";
                    CargarGrillaCategorias();
                    EnviarMensajeUsuario("Registro creado satisfactoriamente");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void EliminarCategoria(int idCategoria)
        {
            try
            {
                //tbCategoriaHD categoria = contexto.tbCategoriaHD.Where(x => x.Id == idCategoria).First();
                //contexto.tbCategoriaHD.Remove(ca

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarAplicaciones()
        {
            try
            {
                var aplicaciones = contexto.tbAplicacion.ToList();
                interfaceHojaDatos.Aplicaciones = aplicaciones;

            }
            catch (Exception ex)
            {
                throw ex;
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

                this.interfaceHojaDatos.MensajePopud = mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
