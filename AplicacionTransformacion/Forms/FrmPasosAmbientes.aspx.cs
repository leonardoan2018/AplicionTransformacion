using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter;
using IInterface;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Entity;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace AplicacionTransformacion.Forms
{
    public partial class FrmPasosAmbientes : System.Web.UI.Page, IPasosAmbientes
    {

        #region VARIABLES GLOBALES
        PPasosAmbientes presenterPasosAmbientes;

        int numero = 0;
        int num3 = 0;

        string mensajePopup = " ";
        #endregion

        #region METODOS SET Y GET

        public object GrupoApoyo
        {
            get
            {
                return ddlGrupoApoyo.SelectedValue;
            }

            set
            {

                ddlGrupoApoyo.DataSource = value;
                ddlGrupoApoyo.DataValueField = "Id";
                ddlGrupoApoyo.DataTextField = "NombreArea";
                ddlGrupoApoyo.DataBind();
            }
        }
        public object Ambientes
        {
            get
            {
                return ddlAmbiente.SelectedValue;
            }

            set
            {
                ddlAmbiente.DataSource = value;
                ddlAmbiente.DataValueField = "Id";
                ddlAmbiente.DataTextField = "Nombre";
                ddlAmbiente.DataBind();
            }
        }

        public object Aplicaciones
        {

            get
            {
                return ddlNomAplicacion.SelectedValue;
            }

            set
            {
                ddlNomAplicacion.DataSource = value;
                ddlNomAplicacion.DataValueField = "Id";
                ddlNomAplicacion.DataTextField = "Nombre";
                ddlNomAplicacion.DataBind();
            }
        }

        public object Persona
        {
            set
            {
                ddlUsuarios.DataSource = value;
                ddlUsuarios.DataValueField = "Id";
                ddlUsuarios.DataTextField = "NombreCompleto";
                ddlUsuarios.DataBind();
            }
            get
            {
                return ddlUsuarios.SelectedValue;
            }
        }

        public string NroOC
        {
            set
            {
                txtNroOC.Text = value;
            }
            get
            {
                return txtNroOC.Text;
            }
        }

        public string Resultado
        {
            get
            {
                return ddlResultado.SelectedValue;
            }
            set
            {
                ddlResultado.Text = value;
            }
        }

        public string NroHarvest
        {
            set
            {
                txtNumHarvest.Text = value;
            }
            get
            {
                return txtNumHarvest.Text;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface ITemacontenido
        /// </summary>
        public object GrillaAdjuntos
        {
            set
            {
                this.gvAdjuntos.DataSource = value;
                this.gvAdjuntos.DataBind();
                this.gvAdjuntos.SelectedIndex = -1;
            }
        }


        public object GrillaInfoPasos
        {
            set
            {
                this.gvInfoPasos.DataSource = value;
                this.gvInfoPasos.DataBind();
                this.gvInfoPasos.SelectedIndex = -1;
            }
        }

        public object GrillaApoyoPasos
        {
            set
            {
                this.gvApoyoPasos.DataSource = value;
                this.gvApoyoPasos.DataBind();
                this.gvApoyoPasos.SelectedIndex = -1;
            }
        }

        public string FechaInstalacion
        {
            set
            {
                txtFechaPaso.Text = value;
            }
            get
            {
                return txtFechaPaso.Text;
            }
        }

        public string Descripcion
        {
            set
            {
                txtDescripcionPaso.Text = value;
            }
            get
            {
                return txtDescripcionPaso.Text;
            }

        }

        public string PersonaApoyo
        {
            get
            {
                return txtNomPersonaApoyo.Text;
            }
            set
            {
                txtNomPersonaApoyo.Text = value;
            }
        }

        public string TelPersonaApoyo
        {
            get
            {
                return txtTelPersonaApoyo.Text;
            }
            set
            {
                txtTelPersonaApoyo.Text = value;
            }
        }


        #endregion}
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                presenterPasosAmbientes = new PPasosAmbientes(this);

                if (!IsPostBack)
                {
                    presenterPasosAmbientes.CargaInicial();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvInfoPasos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal No = (Literal)e.Row.FindControl("ltralNo");
                    numero += 1;
                    No.Text = numero.ToString() + ".";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region MENSAJES
        public string MensajePopup
        {
            set
            {
                mensajePopup = value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KeyToIdentifythisScript", "MostrarMensaje('" + mensajePopup + "');", true);
            }
        }
        #endregion


        protected void btnGuardarInfoPaso_Click(object sender, EventArgs e)
        {
            Session["idPasoAmbiente"] = presenterPasosAmbientes.GuardarPasoAmbiente();
            pnlInfoPasos2.Visible = false;
            pnlApoyoPasos.Visible = true;

        }

        protected void imgCalendario_Click(object sender, EventArgs e)
        {
            //clrFechaPaso.Visible = true;
        }

        protected void clrFechaPaso_SelectionChanged(object sender, EventArgs e)
        {
            //txtFechaPaso.Text = Convert.ToString(txtFechaPaso.SelectedDate);
            //clrFechaPaso.Visible = false;
            //txtFechaPaso.Visible = true;
        }

        protected void imgbttEditarInfoPaso_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtnEditarInfoPaso = (LinkButton)sender;
                TableCell celda = (TableCell)lbtnEditarInfoPaso.Parent;
                GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
                int id = Convert.ToInt32(gvInfoPasos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
                Session["idPaso"] = id;
                int idPaso = Convert.ToInt32(Session["idPaso"]);

                ddlNomAplicacion.SelectedValue = presenterPasosAmbientes.CargarInfoPaso(id);
                ddlUsuarios.SelectedValue = presenterPasosAmbientes.CargarInfoPasoUsuarios(id);
                ddlAmbiente.SelectedValue = presenterPasosAmbientes.CargarInfoPasoAmbiente(id);

                txtFechaPaso.Visible = true;

                btnGuardarInfoPaso.Visible = false;
                btnGuardarEdicionPaso.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbttEliminarInfoPaso_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton lbtnEliminarInfoPaso = (LinkButton)sender;
                TableCell celda = (TableCell)lbtnEliminarInfoPaso.Parent;
                GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
                int id = Convert.ToInt32(gvInfoPasos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
                presenterPasosAmbientes.EliminarInfoPaso(id);//Se actualiza la grilla de datos luego de eliminado el registro
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarEdicionPaso_Click(object sender, EventArgs e)
        {
            int idPaso = Convert.ToInt32(Session["idPaso"]);
            presenterPasosAmbientes.GuardarEdicionPaso(idPaso);
            btnGuardarEdicionPaso.Visible = false;
            btnGuardarInfoPaso.Visible = true;
        }

        protected void btnConsultarInfoPasos_Click(object sender, EventArgs e)
        {
            presenterPasosAmbientes.BuscarInfoPasos();
        }

        protected void imgbttDetalleInfoPaso_Click(object sender, EventArgs e)
        {
            try
            {
                btnvolverInfoPasos.Visible = true;
                pnlInfoPasos1.Visible = true;
                pnlInfoPasos2.Visible = false;
                pnlApoyoPasos.Visible = true;
                pnlAdjuntos.Visible = true;


                btnConsultarInfoPasos.Visible = false;
                btnGuardarEdicionPaso.Visible = false;
                btnGuardarInfoPaso.Visible = false;
                btnAdjuntarArchivosPaso.Visible = true;
                btnLimpiar.Visible = false;
                lbtGruposApoyo.Visible = false;

                LinkButton lbtnApoyoPaso = (LinkButton)sender;
                TableCell celda = (TableCell)lbtnApoyoPaso.Parent;
                GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
                int id = Convert.ToInt32(gvInfoPasos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
                Session["idDetallePaso"] = id;
                int idDetallePaso = Convert.ToInt32(Session["idDetallePaso"]);

                ddlNomAplicacion.SelectedValue = presenterPasosAmbientes.CargarInfoPaso(id);
                ddlAmbiente.SelectedValue = presenterPasosAmbientes.CargarInfoPasoAmbiente(id);
                ddlUsuarios.SelectedValue = presenterPasosAmbientes.CargarInfoPasoUsuarios(id);
                presenterPasosAmbientes.CargarGrillaInfoApoyo(id);
                presenterPasosAmbientes.CargarGrillaAdjuntosDetalle(id);

                txtFechaPaso.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnvolverInfoPasos_Click(object sender, EventArgs e)
        {
            try
            {
                btnvolverInfoPasos.Visible = false;
                txtFechaPaso.Visible = true;
                pnlInfoPasos2.Visible = true;
                pnlApoyoPasos.Visible = false;
                pnlAdjuntos.Visible = false;
                btnConsultarInfoPasos.Visible = true;
                btnGuardarInfoPaso.Visible = true;
                btnLimpiar.Visible = true;
                btnAdjuntarArchivosPaso.Visible = false;
                Limpiar();
                lbtGruposApoyo.Visible = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Limpiar()
        {
            txtFechaPaso.Text = "";
            txtNroOC.Text = "";
            txtNumHarvest.Text = "";
            txtDescripcionPaso.Text = "";
            ddlResultado.ClearSelection();
            ddlNomAplicacion.ClearSelection();
            ddlUsuarios.ClearSelection();
            ddlAmbiente.ClearSelection();
            presenterPasosAmbientes.CargarGrillaInfoPasos();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnAdjuntarArchivosPaso_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarApoyoPaso_Click(object sender, EventArgs e)
        {
            int idPasoAmbiente = Convert.ToInt32(Session["idPasoAmbiente"]);
            presenterPasosAmbientes.GuardarApoyoPasos(idPasoAmbiente);
            presenterPasosAmbientes.CargarGrillaInfoApoyo(idPasoAmbiente);
            pnlApoyoPasos.Visible = true;

        }

        protected void lbtGruposApoyo_Click(object sender, EventArgs e)
        {
            pnlApoyoPasos.Visible = true;
            presenterPasosAmbientes.CargarGrillaInfoApoyo(Convert.ToInt32(Session["idPasoAmbiente"]));
        }

        #region Adjuntos

        //protected void imgbAdjuntos_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton lbttSeleccionar = (LinkButton)sender;
        //        TableCell celda = (TableCell)lbttSeleccionar.Parent;
        //        GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;

        //        //business.CargarGrillaAdjuntos(Convert.ToInt32(gvRespuestas.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KeyToIdentifythisScript", "abrirModalAdjuntar();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        protected void imgbttDescargar_Click(object sender, EventArgs e)
        {
            LinkButton lbttSeleccionar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttSeleccionar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            string nombreArchivo = gvAdjuntos.Rows[filaSeleccionar.RowIndex].Cells[2].Text.ToString();
            string ruta = gvAdjuntos.DataKeys[filaSeleccionar.RowIndex].Value.ToString();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "attachment;filename=" + Server.HtmlDecode(nombreArchivo));
            Response.TransmitFile(ruta);
            Response.End();
        }

        protected void imgbttEliminarAdjuntoDetalle_Click(object sender, EventArgs e)
        {
            LinkButton lbttSeleccionar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttSeleccionar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            string ruta = "../Adjuntos/";
            string sourcePath = Server.MapPath(ruta);
            string sourceFile = System.IO.Path.Combine(sourcePath, Server.HtmlDecode(gvAdjuntos.Rows[filaSeleccionar.RowIndex].Cells[2].Text.ToString()));
            File.Delete(sourceFile);
            presenterPasosAmbientes.EliminarAdjunto(Convert.ToInt32(gvAdjuntos.Rows[filaSeleccionar.RowIndex].Cells[0].Text.ToString()), Convert.ToInt32(Session["idDetallePaso"]));

        }

        protected void lbtCargarArchivos_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                foreach (HttpPostedFile files in fileUpload.PostedFiles)
                {
                    string ruta = "../Adjuntos/";
                    string path = Server.MapPath(ruta);
                    if (Directory.Exists(path))
                    {
                        string[] extension = files.FileName.Split('.');
                        fileUpload.SaveAs(Server.MapPath(ruta + "/" + extension[0].Trim() + "." + extension[1]));
                        lbxArchivosAdjuntos.Items.Add(extension[0].Trim() + "." + extension[1]);
                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                        string[] extension = files.FileName.Split('.');
                        fileUpload.SaveAs(Server.MapPath(ruta + extension[0].Trim() + "." + extension[1]));
                        lbxArchivosAdjuntos.Items.Add(extension[0].Trim() + "." + extension[1]);
                    }

                }

            }
        }


        protected void lnkbAdjuntar_Click(object sender, EventArgs e)
        {
            foreach (var item in lbxArchivosAdjuntos.Items)
            {
                string ruta = "~/Adjuntos/" + item;
                presenterPasosAmbientes.CrearAdjunto(Convert.ToInt32(Session["idDetallePaso"]), item.ToString(), ruta);
            }

            lbxArchivosAdjuntos.Items.Clear();
            MensajePopup = "Archivos cargados satisfactoriamente";

        }

        protected void lbtEliminarAdjunto_Click(object sender, EventArgs e)
        {
            string ruta = "../Adjuntos/";
            string sourcePath = Server.MapPath(ruta);
            string sourceFile = System.IO.Path.Combine(sourcePath, lbxArchivosAdjuntos.SelectedItem.Text.ToString());
            File.Delete(sourceFile);
            lbxArchivosAdjuntos.Items.Remove(lbxArchivosAdjuntos.SelectedItem);
        }

        protected void gvAdjuntos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal No = (Literal)e.Row.FindControl("ltralNo");
                    num3 += 1;
                    No.Text = num3.ToString() + ".";


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

