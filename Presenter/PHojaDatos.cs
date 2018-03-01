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

        #region Cargue Inicial

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarInformacioninicial()
        {
            try
            {
                CargarProyectos();
                CargarIniciativas();
                CargarGrillaCategorias();
                CargarGrillaSubcategorias();
                CargarCategoriasReporte();
                CargarSubCategoriasReporte();
                CargarAmbientesReporte();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ItemSubcategoria

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
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearItemSubcategoria(int idSubcategoria)
        {
            try
            {
                int idAmbiente = Convert.ToInt32(interfaceHojaDatos.Ambientes);
                var existe = contexto.tbItemSubcategoria.Where(x => x.Nombre == interfaceHojaDatos.NombreItem && x.IdSubcategoria == idSubcategoria && x.Descripcion==interfaceHojaDatos.DescripcionItem).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("El registro ya exsite");
                }
                else
                {
                    tbItemSubcategoria itemSubcategoria = new tbItemSubcategoria();
                    itemSubcategoria.IdAmbiente = Convert.ToInt32(interfaceHojaDatos.Ambientes);
                    itemSubcategoria.IdSubcategoria = idSubcategoria;
                    itemSubcategoria.Nombre = interfaceHojaDatos.NombreItem;
                    itemSubcategoria.Descripcion = interfaceHojaDatos.DescripcionItem;
                    contexto.tbItemSubcategoria.Add(itemSubcategoria);
                    contexto.SaveChanges();
                    interfaceHojaDatos.NombreItem = "";
                    interfaceHojaDatos.DescripcionItem = "";
                    CargarGrillaItemSubcategoria(idSubcategoria);
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
        public void EliminarItemSubCategoria(int idItemSubCategoria, int idSubcategoria)
        {
            try
            {
                tbItemSubcategoria itemsubcategoria = contexto.tbItemSubcategoria.Where(x => x.Id == idItemSubCategoria).First();
                contexto.tbItemSubcategoria.Remove(itemsubcategoria);
                contexto.SaveChanges();
                CargarGrillaItemSubcategoria(idSubcategoria);
                EnviarMensajeUsuario("Registro eliminado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public string CargarInfoItemSubCategoria(int idItemSubcategoria)
        {
            try
            {
                var itemSubcategoria = contexto.tbItemSubcategoria.Where(x => x.Id == idItemSubcategoria).First();
                interfaceHojaDatos.NombreItem = itemSubcategoria.Nombre;
                interfaceHojaDatos.DescripcionItem = itemSubcategoria.Descripcion;


                return itemSubcategoria.IdAmbiente.ToString();
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void ActualizarInfoItemSubategoria(int idItemSubc, int idSubcategoria)
        {
            try
            {
                int idAmbiente = Convert.ToInt32(interfaceHojaDatos.Ambientes);
                var itemSubcategoria = contexto.tbItemSubcategoria.Where(x => x.Id == idItemSubc).First();
                itemSubcategoria.IdSubcategoria = idSubcategoria;
                itemSubcategoria.IdAmbiente = idAmbiente;
                itemSubcategoria.Nombre = interfaceHojaDatos.NombreItem;
                itemSubcategoria.Descripcion = interfaceHojaDatos.DescripcionItem;
                contexto.SaveChanges();
                CargarGrillaItemSubcategoria(idSubcategoria);
                interfaceHojaDatos.NombreItem="";
                interfaceHojaDatos.DescripcionItem = "";
                EnviarMensajeUsuario("Registro actualizado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
        #endregion

        #region Cargar información grillas

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
        public void CargarGrillaSubcategorias()
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
        public string CargarGrillaItemSubcategoria(int idSubcategoria)
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

                string nombreSub = contexto.tbSubCategoriaHD.Where(x => x.Id == idSubcategoria).Select(x => x.Nombre).First();

                interfaceHojaDatos.GrillaItemSubcategorias = itemSubcategorias;

                return nombreSub;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Categoria

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
                    EnviarMensajeUsuario("La categoria ya existe");
                }
                else
                {
                    int idIniciativa = Convert.ToInt32(interfaceHojaDatos.Iniciativas);
                    tbCategoriaHD categoria = new tbCategoriaHD();
                    categoria.IdIniciativa = idIniciativa;
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
                tbCategoriaHD categoria = contexto.tbCategoriaHD.Where(x => x.Id == idCategoria).First();
                contexto.tbCategoriaHD.Remove(categoria);
                contexto.SaveChanges();
                CargarGrillaCategorias();
                EnviarMensajeUsuario("Registro eliminado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarInforCategoria(int idCategoria)
        {
            try
            {
                var categoria = contexto.tbCategoriaHD.Where(x => x.Id == idCategoria).First();
                interfaceHojaDatos.NombreCategoria = categoria.Nombre;

            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void ActualizarInfoCategoria(int idCategoria)
        {
            try
            {
                int idIniciativa = Convert.ToInt32(interfaceHojaDatos.Iniciativas);
                var categoria = contexto.tbCategoriaHD.Where(x => x.Id == idCategoria).First();
                categoria.Nombre = interfaceHojaDatos.NombreCategoria;
                categoria.IdIniciativa = idIniciativa;
                contexto.SaveChanges();
                CargarGrillaCategorias();
                interfaceHojaDatos.NombreCategoria = "";
                EnviarMensajeUsuario("Registro actualizado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

    

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarProyectos()
        {
            try
            {
                var proyectos = contexto.tbProyecto.ToList();
                interfaceHojaDatos.Proyectos = proyectos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarIniciativas()
        {
            try
            {
                int idProyecto = Convert.ToInt32(interfaceHojaDatos.Proyectos);
                var iniciativas = contexto.tbIniciativa.Where(x=>x.IdProyecto==idProyecto).ToList();
                interfaceHojaDatos.Iniciativas = iniciativas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Subcategoria

        /// <summary>
        /// Método para crear un Aplicación
        /// </summary>
        public void CrearSubCategoria()
        {
            try
            {
                int categoria = Convert.ToInt32(interfaceHojaDatos.Categorias);
                var existe = contexto.tbSubCategoriaHD.Where(x => x.Nombre == interfaceHojaDatos.NombreSubcategoria && x.IdCategoria == categoria).ToList();
                if (existe.Count > 0)
                {
                    EnviarMensajeUsuario("La subcategoria ya exsite");
                }
                else
                {
                    tbSubCategoriaHD subcategoria = new tbSubCategoriaHD();
                    subcategoria.IdCategoria = Convert.ToInt32(interfaceHojaDatos.Categorias);
                    subcategoria.Nombre = interfaceHojaDatos.NombreSubcategoria;
                    contexto.tbSubCategoriaHD.Add(subcategoria);
                    contexto.SaveChanges();
                    interfaceHojaDatos.NombreSubcategoria = "";
                    CargarGrillaSubcategorias();
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
        public void EliminarSubCategoria(int idSubCategoria)
        {
            try
            {
                tbSubCategoriaHD subcategoria = contexto.tbSubCategoriaHD.Where(x => x.Id == idSubCategoria).First();
                contexto.tbSubCategoriaHD.Remove(subcategoria);
                contexto.SaveChanges();
                CargarGrillaSubcategorias();
                EnviarMensajeUsuario("Registro eliminado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public string CargarInfoSubCategoria(int idSubcategoria)
        {
            try
            {
                var subCategoria = contexto.tbSubCategoriaHD.Where(x => x.Id == idSubcategoria).First();
                interfaceHojaDatos.NombreSubcategoria = subCategoria.Nombre;

                return subCategoria.IdCategoria.ToString();
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void ActualizarInfoSubCategoria(int idSubcategoria)
        {
            try
            {
                int idCategoria = Convert.ToInt32(interfaceHojaDatos.Categorias);
                var subcategoria = contexto.tbSubCategoriaHD.Where(x => x.Id == idSubcategoria).First();
                subcategoria.IdCategoria = idCategoria;
                subcategoria.Nombre = interfaceHojaDatos.NombreSubcategoria;
                contexto.SaveChanges();
                CargarGrillaSubcategorias();
                interfaceHojaDatos.NombreSubcategoria = "";
                EnviarMensajeUsuario("Registro actualizado satisfacotriamente");

            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
        #endregion


        #region Hoja datos


        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarReporte()
        {
            try
            {
                var consulta = (from c in contexto.tbCategoriaHD
                                join s in contexto.tbSubCategoriaHD on c.Id equals s.IdCategoria
                                join i in contexto.tbItemSubcategoria on s.Id equals i.IdSubcategoria
                                join a in contexto.tbAmbiente on i.IdAmbiente equals a.Id
                                join ini in contexto.tbIniciativa on c.IdIniciativa equals ini.Id
                                join py in contexto.tbProyecto on ini.IdProyecto equals py.Id
                                select new
                                {
                                    NombreCategoria = c.Nombre,
                                    NombreSubcategoria = s.Nombre,
                                    Ambiente = a.Nombre,
                                    ItemNombre = i.Nombre,
                                    ItemDescripcion = i.Descripcion,
                                    Proyecto = py.Nombre,
                                    IdCategoria=c.Id,
                                    IdSubcategoria=i.IdSubcategoria,
                                    IdAmbiente=i.IdAmbiente
                             }
                                    ).ToList();

                if(interfaceHojaDatos.CategoriasReporte.ToString()!="0")
                {
                    int idCategoria = Convert.ToInt32(interfaceHojaDatos.CategoriasReporte);
                    consulta = consulta.Where(x => x.IdCategoria == idCategoria).ToList();
                }

                if (interfaceHojaDatos.SubcategoriasReporte.ToString() != "0")
                {
                    int idSubCategoria = Convert.ToInt32(interfaceHojaDatos.SubcategoriasReporte);
                    consulta = consulta.Where(x => x.IdSubcategoria == idSubCategoria).ToList();
                }

                if (interfaceHojaDatos.AmbientesReporte.ToString() != "0")
                {
                    int idAmbiente = Convert.ToInt32(interfaceHojaDatos.AmbientesReporte);
                    consulta = consulta.Where(x => x.IdAmbiente == idAmbiente).ToList();
                }


                interfaceHojaDatos.ReporteHojaDatos = consulta;
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        /// <summary>
        /// Método que carga la informacion de los laboratorios
        /// </summary>
        public void CargarCategoriasReporte()
        {
            try
            {
                List<tbCategoriaHD> listaCategoria= new List<tbCategoriaHD>();

                tbCategoriaHD cat = new tbCategoriaHD();
                cat.Id = 0;
                cat.Nombre = "Seleccionar";
                listaCategoria.Add(cat);

                int idIniciativas = Convert.ToInt32(interfaceHojaDatos.Iniciativas);
                var categorias = contexto.tbCategoriaHD.Where(x=>x.IdIniciativa== idIniciativas).OrderBy(x => x.Nombre).ToList();

                foreach (var item in categorias)
                {
                    tbCategoriaHD cat2 = new tbCategoriaHD();
                    cat2.Id = item.Id;
                    cat2.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Nombre);
                    listaCategoria.Add(cat2);
                }

                interfaceHojaDatos.CategoriasReporte = listaCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que carga la informacion de los laboratorios
        /// </summary>
        public void CargarSubCategoriasReporte()
        {
            try
            {
                List<tbSubCategoriaHD> listaCategoria = new List<tbSubCategoriaHD>();

                tbSubCategoriaHD cat = new tbSubCategoriaHD();
                cat.Id = 0;
                cat.Nombre = "Seleccionar";
                listaCategoria.Add(cat);

              
                if (interfaceHojaDatos.CategoriasReporte.ToString() != "0")
                {
                    int idCategoria = Convert.ToInt32(interfaceHojaDatos.CategoriasReporte);

                    var subcategorias = contexto.tbSubCategoriaHD.Where(x => x.IdCategoria == idCategoria).OrderBy(x => x.Nombre).ToList();

                    foreach (var item in subcategorias)
                    {
                        tbSubCategoriaHD cat2 = new tbSubCategoriaHD();
                        cat2.Id = item.Id;
                        cat2.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Nombre);
                        listaCategoria.Add(cat2);
                    }
                }

                interfaceHojaDatos.SubcategoriasReporte = listaCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que carga la informacion de los laboratorios
        /// </summary>
        public void CargarAmbientesReporte()
        {
            try
            {
                List<tbAmbiente> listaAmbientes = new List<tbAmbiente>();

                tbAmbiente amb = new tbAmbiente();
                amb.Id = 0;
                amb.Nombre = "Seleccionar";
                listaAmbientes.Add(amb);

                var ambientes = contexto.tbAmbiente.OrderBy(x => x.Nombre).ToList();

                foreach (var item in ambientes)
                {
                    tbAmbiente amb2 = new tbAmbiente();
                    amb2.Id = item.Id;
                    amb2.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Nombre);
                    listaAmbientes.Add(amb2);
                }

                interfaceHojaDatos.AmbientesReporte = listaAmbientes;
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
