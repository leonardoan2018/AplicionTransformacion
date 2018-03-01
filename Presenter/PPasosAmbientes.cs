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
    public class PPasosAmbientes
    {
        #region VARIABLES GLOBALES Y CONSTRUCTOR

        public IPasosAmbientes interfacePasosAmbientes;

        BDInfoTransformacionEntities contexto = new BDInfoTransformacionEntities();

        public PPasosAmbientes(IPasosAmbientes vista)
        {
            interfacePasosAmbientes = vista;
        }

        #endregion

        #region METODOS

        public void PopupMensajes(string valor)
        {
            try
            {
                switch (valor)
                {
                    case "Registro Guardado":
                        {
                            interfacePasosAmbientes.MensajePopup = valor;
                            break;
                        }

                    case "Registro Editado":
                        {
                            interfacePasosAmbientes.MensajePopup = valor;
                            break;
                        }
                    case "Registro Eliminado":
                        {
                            interfacePasosAmbientes.MensajePopup = valor;
                            break;
                        }

                    case "Apoyo guardado":
                        {
                            interfacePasosAmbientes.MensajePopup = valor;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargaInicial()
        {
            try
            {
                CargaAmbientes();
                CargarIniciativas();
                CargaUsuarios();
                CargarGrillaInfoPasos();
                CargarAreaApoyoPasos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargaAmbientes()
        {
            try
            {
                List<tbAmbiente> listaAmbiente = new List<tbAmbiente>();

                tbAmbiente amb = new tbAmbiente();
                amb.Id = 0;
                amb.Nombre = "Seleccione un valor...";
                listaAmbiente.Add(amb);

                var ambiente = contexto.tbAmbiente.Select(x => new { x.Nombre, x.Id }).OrderBy(x => x.Nombre).ToList();

                foreach (var item in ambiente)
                {
                    tbAmbiente amb2 = new tbAmbiente();
                    amb2.Id = item.Id;
                    amb2.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Nombre);
                    listaAmbiente.Add(amb2);
                }

                //var consulta = (from a in contexto.tbAmbiente select new {a.Id, a.Nombre }).ToList();
                interfacePasosAmbientes.Ambientes = listaAmbiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarIniciativas()
        {
            try
            {
                List<tbIniciativa> listaIniciativas = new List<tbIniciativa>();

                tbIniciativa ini = new tbIniciativa();
                ini.Id = 0;
                ini.Nombre = "Seleccione un valor...";
                listaIniciativas.Add(ini);

                var aplicacion = contexto.tbIniciativa.Select(x => new { x.Nombre, x.Id }).OrderBy(x => x.Nombre).ToList();

                //var aplicacion = (from a in contexto.tbAplicacion select new { a.Id, a.Nombre, a.AW }).ToList();

                foreach (var item in aplicacion)
                {
                    tbIniciativa apl2 = new tbIniciativa();
                    apl2.Id = item.Id;
                    apl2.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Nombre);
                    listaIniciativas.Add(apl2);
                }

                //var aplicacion = (from a in contexto.tbAplicacion select new { a.Id, a.Nombre, a.AW }).ToList();
                //object aplicacion = contexto.tbAplicacion.Select(x => new { x.Id, x.Nombre, x.AW }).ToList();
                interfacePasosAmbientes.Aplicaciones = listaIniciativas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargaUsuarios()
        {
            try
            {

                List<tbUsuario> listaUsuario = new List<tbUsuario>();

                tbUsuario usu = new tbUsuario();
                usu.Id = 0;
                usu.NombreCompleto = "Seleccione un valor...";
                listaUsuario.Add(usu);

                var usuario = contexto.tbUsuario.Select(x => new { x.NombreCompleto, x.Id }).OrderBy(x => x.NombreCompleto).ToList();

                foreach (var item in usuario)
                {
                    tbUsuario usu2 = new tbUsuario();
                    usu2.Id = item.Id;
                    usu2.NombreCompleto = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.NombreCompleto);
                    listaUsuario.Add(usu2);
                }

                //var usuario = (from a in contexto.tbUsuario select new { a.Id, a.NombreCompleto }).ToList();
                interfacePasosAmbientes.Persona = listaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarGrillaInfoPasos()
        {
            try
            {
                object infoPasos = (from a in contexto.tbPasoAmbiente
                                    join b in contexto.tbAmbiente on a.IdAmbiente equals b.Id
                                    join c in contexto.tbIniciativa on a.IdIniciativa equals c.Id
                                    join d in contexto.tbUsuario on a.IdUsuario equals d.Id
                                    select new
                                    {
                                        a.Id,
                                        NombreAmbiente = b.Nombre,
                                        NombreAplicacion = c.Nombre,
                                        NombreUsuario = d.NombreCompleto,
                                        FechaInstalacion = a.Fecha,
                                        a.NumeroOC,
                                        a.Resultado,
                                        a.Harvest,
                                        a.Descripcion
                                    }).ToList();

                interfacePasosAmbientes.GrillaInfoPasos = infoPasos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarGrillaInfoApoyo(int idPasoAmbiente)
        {
            object infoApoyo = (from a in contexto.tbPasoAmbiente
                                join b in contexto.tbApoyoPasoAmbiente on a.Id equals b.IdPasoAmbiente
                                join c in contexto.tbAreaApoyo on b.IdArea equals c.Id
                                where a.Id == idPasoAmbiente
                                select new
                                {
                                    a.Id,
                                    b.IdArea,
                                    c.NombreArea,
                                    b.PersonaApoyo,
                                    b.TelefonoContacto
                                }).ToList();

            interfacePasosAmbientes.GrillaApoyoPasos = infoApoyo;

        }

        public void BuscarInfoPasos()
        {
            try
            {
                var infoPasos = (from a in contexto.tbPasoAmbiente
                                 join b in contexto.tbAmbiente on a.IdAmbiente equals b.Id
                                 join c in contexto.tbIniciativa on a.IdIniciativa equals c.Id
                                 join d in contexto.tbUsuario on a.IdUsuario equals d.Id
                                 select new
                                 {
                                     a.Id,
                                     idAmbiente = b.Id,
                                     NombreAmbiente = b.Nombre,
                                     NombreAplicacion = c.Nombre,
                                     idAplicacion = c.Id,
                                     NombreUsuario = d.NombreCompleto,
                                     idUsuario = d.Id,
                                     FechaInstalacion = a.Fecha,
                                     a.NumeroOC,
                                     a.Resultado,
                                     a.Harvest,
                                     a.Descripcion
                                 }).ToList();


                if (interfacePasosAmbientes.NroHarvest != "")
                {
                    infoPasos = infoPasos.Where(x => x.Harvest == interfacePasosAmbientes.NroHarvest).ToList();
                }

                if (interfacePasosAmbientes.NroOC != "")
                {
                    infoPasos = infoPasos.Where(x => x.NumeroOC == interfacePasosAmbientes.NroOC).ToList();
                }

                if (Convert.ToString(interfacePasosAmbientes.Ambientes) != "0")
                {
                    infoPasos = infoPasos.Where(x => x.idAmbiente == Convert.ToInt32(interfacePasosAmbientes.Ambientes)).ToList();
                }

                if (Convert.ToString(interfacePasosAmbientes.Aplicaciones) != "0")
                {
                    infoPasos = infoPasos.Where(x => x.idAplicacion == Convert.ToInt32(interfacePasosAmbientes.Aplicaciones)).ToList();
                }

                if (Convert.ToString(interfacePasosAmbientes.Persona) != "0")
                {
                    infoPasos = infoPasos.Where(x => x.idUsuario == Convert.ToInt32(interfacePasosAmbientes.Persona)).ToList();
                }

                if (Convert.ToString(interfacePasosAmbientes.Resultado) != "Seleccione un valor...")
                {
                    infoPasos = infoPasos.Where(x => Convert.ToString(x.Resultado) == Convert.ToString(interfacePasosAmbientes.Resultado)).ToList();
                }

                interfacePasosAmbientes.GrillaInfoPasos = infoPasos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GuardarPasoAmbiente()
        {
            try
            {
                tbPasoAmbiente pasoAmbiente = new tbPasoAmbiente();
                pasoAmbiente.IdIniciativa = Convert.ToInt32(interfacePasosAmbientes.Aplicaciones);
                pasoAmbiente.IdUsuario = Convert.ToInt32(interfacePasosAmbientes.Persona);
                pasoAmbiente.IdAmbiente = Convert.ToInt32(interfacePasosAmbientes.Ambientes);
                pasoAmbiente.NumeroOC = interfacePasosAmbientes.NroOC;
                pasoAmbiente.Resultado = interfacePasosAmbientes.Resultado;
                pasoAmbiente.Harvest = interfacePasosAmbientes.NroHarvest;
                pasoAmbiente.Fecha = Convert.ToDateTime(interfacePasosAmbientes.FechaInstalacion);
                pasoAmbiente.Descripcion = interfacePasosAmbientes.Descripcion;
                contexto.tbPasoAmbiente.Add(pasoAmbiente);
                contexto.SaveChanges();
                int scope_pasoAmbiente_id = pasoAmbiente.Id;
                CargarGrillaInfoPasos();
                PopupMensajes("Registro Guardado");

                return scope_pasoAmbiente_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CargarInfoPaso(int id)
        {
            try
            {
                var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == id).First();
                interfacePasosAmbientes.NroOC = infoPaso.NumeroOC;
                interfacePasosAmbientes.NroHarvest = infoPaso.Harvest;
                interfacePasosAmbientes.Resultado = infoPaso.Resultado;
                interfacePasosAmbientes.Descripcion = infoPaso.Descripcion;
                interfacePasosAmbientes.FechaInstalacion = Convert.ToString(infoPaso.Fecha);

                return infoPaso.IdIniciativa.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string CargarInfoPasoAmbiente(int id)
        {
            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == id).First();

            return infoPaso.IdAmbiente.ToString();
        }

        public string CargarInfoPasoUsuarios(int id)
        {
            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == id).First();

            return infoPaso.IdUsuario.ToString();
        }

        public void EliminarInfoPaso(int id)
        {
            var apoyoPasos = contexto.tbApoyoPasoAmbiente.Where(x => x.IdPasoAmbiente == id).ToList();

            foreach (var item in apoyoPasos)
            {
                var apoyoPaso = contexto.tbApoyoPasoAmbiente.Where(x => x.Id == item.Id).First();
                contexto.tbApoyoPasoAmbiente.Remove(apoyoPaso);
            }

            contexto.SaveChanges();

            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == id).First();
            contexto.tbPasoAmbiente.Remove(infoPaso);
            contexto.SaveChanges();
            CargarGrillaInfoPasos();
            PopupMensajes("Registro Eliminado");
        }

        public void GuardarEdicionPaso(int idPaso)
        {
            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == idPaso).First();
            infoPaso.IdIniciativa = Convert.ToInt32(interfacePasosAmbientes.Aplicaciones);
            infoPaso.IdUsuario = Convert.ToInt32(interfacePasosAmbientes.Persona);
            infoPaso.IdAmbiente = Convert.ToInt32(interfacePasosAmbientes.Ambientes);
            infoPaso.Fecha = Convert.ToDateTime(interfacePasosAmbientes.FechaInstalacion);
            infoPaso.NumeroOC = interfacePasosAmbientes.NroOC;
            infoPaso.Harvest = interfacePasosAmbientes.NroHarvest;
            infoPaso.Resultado = interfacePasosAmbientes.Resultado;
            infoPaso.Descripcion = interfacePasosAmbientes.Descripcion;
            contexto.SaveChanges();
            CargarGrillaInfoPasos();
            PopupMensajes("Registro Editado");
        }

        public void GuardarApoyoPasos(int idPasoAmbiente)
        {
            try
            {
                tbApoyoPasoAmbiente apoyoPaso = new tbApoyoPasoAmbiente();
                apoyoPaso.IdPasoAmbiente = Convert.ToInt32(idPasoAmbiente);
                apoyoPaso.IdArea = Convert.ToInt32(interfacePasosAmbientes.GrupoApoyo);
                apoyoPaso.PersonaApoyo = interfacePasosAmbientes.PersonaApoyo;
                apoyoPaso.TelefonoContacto = interfacePasosAmbientes.TelPersonaApoyo;
                contexto.tbApoyoPasoAmbiente.Add(apoyoPaso);
                contexto.SaveChanges();
                PopupMensajes("Apoyo guardado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarAreaApoyoPasos()
        {
            try
            {
                object apoyoPasos = contexto.tbAreaApoyo.Select(x => new { x.NombreArea, x.Id }).ToList();

                //var consulta = (from a in contexto.tbAmbiente select new {a.Id, a.Nombre }).ToList();
                interfacePasosAmbientes.GrupoApoyo = apoyoPasos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Adjuntos

        /// <summary>
        /// Método para cargar la grilla Aplicaciones
        /// </summary>
        public void CargarGrillaAdjuntosDetalle(int idPasoAmbiente)
        {
            try
            {
                var adjuntos = contexto.tbAdjuntoPasoAmbiente.Where(x => x.IdPaso == idPasoAmbiente).ToList();
                interfacePasosAmbientes.GrillaAdjuntos = adjuntos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Método para cargar la lista de los estados
        /// </summary>
        public void CrearAdjunto(int idPasoAmbiente, string nombreArchivo, string rutaAdjunto)
        {
            try
            {
                tbAdjuntoPasoAmbiente adjunto = new tbAdjuntoPasoAmbiente();
                adjunto.IdPaso = idPasoAmbiente;
                adjunto.NombreArchivo = nombreArchivo;
                adjunto.Ruta = rutaAdjunto;
                contexto.tbAdjuntoPasoAmbiente.Add(adjunto);
                contexto.SaveChanges();
                CargarGrillaAdjuntosDetalle(idPasoAmbiente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Método para cargar la lista de los estados
        /// </summary>
        public void EliminarAdjunto(int idAdjunto, int idDetallePaso)
        {
            try
            {
                tbAdjuntoPasoAmbiente adjunto = contexto.tbAdjuntoPasoAmbiente.Where(x => x.Id == idAdjunto).First();
                contexto.tbAdjuntoPasoAmbiente.Remove(adjunto);
                contexto.SaveChanges();
                CargarGrillaAdjuntosDetalle(idDetallePaso);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
