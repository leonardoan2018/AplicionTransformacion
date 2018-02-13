using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterface;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.Objects;
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
                        interfacePasosAmbientes.MensajePopup = valor;
                        break;
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
                CargarAplicaciones();
                CargaUsuarios();
                CargarGrillaInfoPasos();
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
                object ambiente = contexto.tbAmbiente.Select(x => new { x.Nombre, x.Id }).ToList();

                //var consulta = (from a in contexto.tbAmbiente select new {a.Id, a.Nombre }).ToList();
                interfacePasosAmbientes.Ambientes = ambiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarAplicaciones()
        {
            try
            {

                var aplicacion = (from a in contexto.tbAplicacion select new { a.Id, a.Nombre, a.AW }).ToList();
                //object aplicacion = contexto.tbAplicacion.Select(x => new { x.Id, x.Nombre, x.AW }).ToList();
                interfacePasosAmbientes.Aplicaciones = aplicacion;
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
                var usuario = (from a in contexto.tbUsuario select new { a.Id, a.NombreCompleto }).ToList();
                interfacePasosAmbientes.Persona = usuario;
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
                                    join c in contexto.tbAplicacion on a.IdAplicacion equals c.Id
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

        public void BuscarInfoPasos()
        {
            try
            {
                var infoPasos = (from a in contexto.tbPasoAmbiente
                                 join b in contexto.tbAmbiente on a.IdAmbiente equals b.Id
                                 join c in contexto.tbAplicacion on a.IdAplicacion equals c.Id
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


                if (interfacePasosAmbientes.NroHarvest != "")
                {
                    infoPasos = infoPasos.Where(x => x.Harvest == interfacePasosAmbientes.NroHarvest).ToList();
                }

                if (interfacePasosAmbientes.NroOC != "")
                {
                    infoPasos = infoPasos.Where(x => x.NumeroOC == interfacePasosAmbientes.NroOC).ToList();
                }

                interfacePasosAmbientes.GrillaInfoPasos = infoPasos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarPasoAmbiente()
        {
            try
            {
                tbPasoAmbiente pasoAmbiente = new tbPasoAmbiente();
                pasoAmbiente.IdAplicacion = Convert.ToInt32(interfacePasosAmbientes.Aplicaciones);
                pasoAmbiente.IdUsuario = Convert.ToInt32(interfacePasosAmbientes.Persona);
                pasoAmbiente.IdAmbiente = Convert.ToInt32(interfacePasosAmbientes.Ambientes);
                pasoAmbiente.NumeroOC = interfacePasosAmbientes.NroOC;
                pasoAmbiente.Resultado = interfacePasosAmbientes.Resultado;
                pasoAmbiente.Harvest = interfacePasosAmbientes.NroHarvest;
                pasoAmbiente.Fecha = Convert.ToDateTime(interfacePasosAmbientes.FechaInstalacion);
                pasoAmbiente.Descripcion = interfacePasosAmbientes.Descripcion;
                contexto.tbPasoAmbiente.Add(pasoAmbiente);
                contexto.SaveChanges();
                CargarGrillaInfoPasos();
                PopupMensajes("Registro Guardado");
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

                return infoPaso.IdAplicacion.ToString();

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
            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == id).First();
            contexto.tbPasoAmbiente.Remove(infoPaso);
            contexto.SaveChanges();
            CargarGrillaInfoPasos();
            PopupMensajes("Registro Eliminado");
        }

        public void GuardarEdicionPaso(int idPaso)
        {
            var infoPaso = contexto.tbPasoAmbiente.Where(x => x.Id == idPaso).First();
            infoPaso.IdAplicacion = Convert.ToInt32(interfacePasosAmbientes.Aplicaciones);
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

        public void Limpiar()
        {
            try
            {

                interfacePasosAmbientes.FechaInstalacion = "";
                interfacePasosAmbientes.NroOC = "";
                interfacePasosAmbientes.NroHarvest = "";
                interfacePasosAmbientes.Descripcion = "";
                interfacePasosAmbientes.Resultado = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
