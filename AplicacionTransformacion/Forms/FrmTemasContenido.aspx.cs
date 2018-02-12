using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter;
using IInterface;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Services;

namespace AplicacionTransformacion.Forms
{
    public partial class FrmTemasContenido : System.Web.UI.Page, ITemaContenido
    {
        #region Variables de la clase

        public PTemaContenido presenter;
        public string mensajePopud = "";
        int num = 0;
        int num2 = 0;
        int num3 = 0;

        #endregion

        #region Pageload


        /// <summary>
        /// Método que se encarga de cargar la informacion inicial cuando se carga la pagina
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PTemaContenido(this);
            if (!IsPostBack)
            {
                presenter.CargarInformacionInicial();
            }
        }

        #endregion

        #region Metodos Set - Get

        #region Grillas

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface ITemacontenido
        /// </summary>
        public object GrillaContenidos
        {
            set
            {
                this.gvContenidos.DataSource = value;
                this.gvContenidos.DataBind();
                this.gvContenidos.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface ITemacontenido
        /// </summary>
        public object GrillaTemas
        {
            set
            {
                this.gvTemas.DataSource = value;
                this.gvTemas.DataBind();
                this.gvTemas.SelectedIndex = -1;
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
        #endregion

        #region Controles

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del contenido y lo envia hacia la interface ITemacontenido
        /// </summary>
        public object AplicacionesTema
        {
            set
            {
                dpAplicaciones.DataSource = value;
                dpAplicaciones.DataValueField = "Id";
                dpAplicaciones.DataTextField = "Nombre";
                dpAplicaciones.DataBind();
            }
            get
            {
                return dpAplicaciones.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna la descripción del contenido y lo envia hacia la interface ITemacontenido
        /// </summary>
        public string NombreContenido
        {
            get
            {
                return txtNombreContenido.Text;

            }
            set
            {
                txtNombreContenido.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna la descripción del contenido y lo envia hacia la interface ITemacontenido
        /// </summary>
        public string DescripcionContenido
        {
            get
            {
                return txtDescripcionContenido.Text;

            }
            set
            {
                txtDescripcionContenido.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna la descripción del contenido y lo envia hacia la interface ITemacontenido
        /// </summary>
        public string DetalleNombreContenido
        {
            get
            {
                return txtDetalleNombreContenido.Text;

            }
            set
            {
                txtDetalleNombreContenido.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna la descripción del contenido y lo envia hacia la interface ITemacontenido
        /// </summary>
        public string DetalleDescripcionContenido
        {
            get
            {
                return txtDetalleDescripcionContenido.Text;

            }
            set
            {
                txtDetalleDescripcionContenido.Text = value;
            }
        }
        #endregion

        #region Mensajes

        public string MensajePopud
        {
            set
            {
                mensajePopud = value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KeyToIdentifythisScript", "MostarMensaje('" + mensajePopud + "');", true);
            }
        }

        #endregion

        #endregion

        #region Eventos

        protected void dpAplicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void lbtPrueba_Click(object sender, EventArgs e)
        {
            
        }

        protected void imgbtItemsTemas_Click(object sender, EventArgs e)
        {

        }

        protected void imgbAdjuntos_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbttSeleccionar = (LinkButton)sender;
                TableCell celda = (TableCell)lbttSeleccionar.Parent;
                GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;

                //business.CargarGrillaAdjuntos(Convert.ToInt32(gvRespuestas.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KeyToIdentifythisScript", "abrirModalAdjuntar();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void imgbttEliminarItemTema_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEditarItemTema_Click(object sender, EventArgs e)
        {

        }

        protected void lbtCrearContenido_Click(object sender, EventArgs e)
        {

        }

        protected void lbtCancelarContenido_Click(object sender, EventArgs e)
        {

        }

        protected void imgbContenidos_Click(object sender, EventArgs e)
        {
            pnlTemas.Visible = false;
            pnlContenidos.Visible = true;
            LinkButton lbttSeleccionar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttSeleccionar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            lblTituloContenido.Text = "Contenido " + Server.HtmlDecode(gvTemas.Rows[filaSeleccionar.RowIndex].Cells[4].Text.ToString());
            int idTema = Convert.ToInt32(gvTemas.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            Literal lit = (Literal)gvTemas.Rows[filaSeleccionar.RowIndex].FindControl("ltralIdAplicacion");
            int idAplicacion = Convert.ToInt32(lit.Text);
            Session["idAplicacion"] = idAplicacion;
            Session["idTema"] = idTema;
            presenter.CargarGrillaContenidos(idTema, idAplicacion);

        }

        #endregion

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            try
            {

                List<string> lista = new List<string>();


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lbtEliminarAdjunto_Click(object sender, EventArgs e)
        {
            string ruta = "../Adjuntos/";
            string sourcePath = Server.MapPath(ruta);
            string sourceFile = System.IO.Path.Combine(sourcePath, lbxArchivosAdjuntos.SelectedItem.Text.ToString());
            File.Delete(sourceFile);
            lbxArchivosAdjuntos.Items.Remove(lbxArchivosAdjuntos.SelectedItem);
        }

        protected void gvTemas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal No = (Literal)e.Row.FindControl("ltralNo");
                    num += 1;
                    No.Text = num.ToString() + ".";


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvContenidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal No = (Literal)e.Row.FindControl("ltralNo");
                    num2 += 1;
                    No.Text = num2.ToString() + ".";


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lbtBuscarCriterio_Click(object sender, EventArgs e)
        {

            presenter.CargarGrillaContenidosBusqueda(Convert.ToInt32(Session["idTema"]), Convert.ToInt32(Session["idAplicacion"]), dpCriterioBusqueda.SelectedValue, txtNombreCriterioBusqueda.Text);
            
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

   


        protected void imgbDetalleContenido_Click(object sender, EventArgs e)
        {
            pnlContenidos.Visible = false;
            pnlDetalleContenido.Visible = true;
            pnlAdjuntos.Visible = true;
            LinkButton lbttSeleccionar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttSeleccionar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            int contenido = Convert.ToInt32(gvContenidos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            Session["idContenido"] = contenido;
            presenter.CargarDetalleContenido(contenido);
        }

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
            presenter.EliminarAdjunto(Convert.ToInt32(gvAdjuntos.Rows[filaSeleccionar.RowIndex].Cells[0].Text.ToString()), Convert.ToInt32(Session["idContenido"]));
            
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
                string ruta = "~/Adjuntos/"+item;
                presenter.CrearAdjunto(Convert.ToInt32(Session["idContenido"]), item.ToString(), ruta);
            }

            lbxArchivosAdjuntos.Items.Clear();
            MensajePopud ="Archivos cargados satisfactoriamente";
           
        }

        protected void btnvolverTemas_Click(object sender, EventArgs e)
        {
            pnlTemas.Visible = true;
            pnlContenidos.Visible = false;
            pnlDetalleContenido.Visible = false;
            pnlAdjuntos.Visible = false;
           
        }

        protected void lbtVolverContenidos_Click(object sender, EventArgs e)
        {
            pnlTemas.Visible = false;
            pnlContenidos.Visible = true;
            pnlDetalleContenido.Visible = false;
            pnlAdjuntos.Visible = false;
            
        }

        protected void imgbttEliminarItemContenido_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEditarItemContenido_Click(object sender, EventArgs e)
        {
            lbtCrearContenido.Visible = false;
            lbtEditarContenido.Visible = true;
            LinkButton lbttSeleccionar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttSeleccionar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            int contenido = Convert.ToInt32(gvContenidos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            Session["idContenido"] = contenido;
            presenter.CargarInfoContenido(contenido);
        }


        protected void lbtEditarContenido_Click(object sender, EventArgs e)
        {
            presenter.ActualizarInfoContenido(Convert.ToInt32(Session["idContenido"]), Convert.ToInt32(Session["idAplicacion"]));
            lbtCrearContenido.Visible = true;
            lbtEditarContenido.Visible = false;
        }

    }
}