using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Presenter;
using IInterface;


namespace AplicacionTransformacion.Forms
{
    public partial class FrmAdministacion : System.Web.UI.Page, IAdministracion
    {

        #region Variables de la clase

        public PAdministracion presenter;
        public string mensajePopud = "";
        public int num1 = 0;
        public int num2 = 0;

        #endregion

        #region Pageload


        /// <summary>
        /// Método que se encarga de cargar la informacion inicial cuando se carga la pagina
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PAdministracion(this);
            if (!IsPostBack)
            {
                presenter.CargarInformacioninicial();
            }
        }

        #endregion

        #region Metodos Set - Get

        #region Grillas

        /// <summary>
        /// Set - Obtiene la informacion de las aplicaciones desde la interface IAdmininistracion
        /// </summary>
        public object GrillaAplicaciones
        {
            set
            {
                this.gvAplicaciones.DataSource = value;
                this.gvAplicaciones.DataBind();
                this.gvAplicaciones.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface IAdmininistracion
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
        #endregion

        #region Controles

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreAplicacion
        {
            get
            {
                return txtNombreAplicacion.Text;

            }
            set
            {
                txtNombreAplicacion.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el AW de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string AW
        {
            get
            {
                return txtAW.Text;

            }
            set
            {
                txtAW.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object AplicacionesTema
        {
            set
            {
                dpAplicacionesTema.DataSource = value;
                dpAplicacionesTema.DataValueField = "Id";
                dpAplicacionesTema.DataTextField = "Nombre";
                dpAplicacionesTema.DataBind();
            }
            get
            {
                return dpAplicacionesTema.SelectedValue;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del contenido y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreTema
        {
            get
            {
                return txtNombreTema.Text;

            }
            set
            {
                txtNombreTema.Text = value;
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


        protected void btnCrearAplicacion_Click(object sender, EventArgs e)
        {
            presenter.CrearAplicacion();
        }

        protected void btnActualizarAplicacion_Click(object sender, EventArgs e)
        {
            presenter.ActualizarAplicacion(Convert.ToInt32(Session["idAplicacion"]));
            btnCrearAplicacion.Visible = true;
            btnActualizarAplicacion.Visible = false;
        }

        protected void btnCancelarAplicacion_Click(object sender, EventArgs e)
        {

        }

      

        protected void imgbttEditarAplicacion_Click(object sender, EventArgs e)
        {
            btnCrearAplicacion.Visible = false;
            btnActualizarAplicacion.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idAplicacion"] = Convert.ToInt32(gvAplicaciones.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            presenter.CargarInfoAplicacion(Convert.ToInt32(Session["idAplicacion"]));
        }

        protected void imgbttEliminarAplicacion_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarAplicacion(Convert.ToInt32(gvAplicaciones.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }

        protected void dpAplicacionesTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CargarTemas();
        }

        protected void lbtCrearTema_Click(object sender, EventArgs e)
        {
            presenter.CrearTema();
        }

        protected void lbtEditarTema_Click(object sender, EventArgs e)
        {
            presenter.ActualizarTema(Convert.ToInt32(Session["idContenido"]));
            lbtCrearTema.Visible = true;
            lbtEditarTema.Visible = false;

        }

        protected void lbtCancelarTema_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEditarTema_Click(object sender, EventArgs e)
        {

            lbtCrearTema.Visible = false;
            lbtEditarTema.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idContenido"] = Convert.ToInt32(gvTemas.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            presenter.CargarInfoTema(Convert.ToInt32(Session["idContenido"]));
        }

        protected void imgbttEliminarTema_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarTema(Convert.ToInt32(gvTemas.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }



        #endregion


        /// <summary>
        /// Método que se ejecuta cuando se digita una palabra en el texbox producto detalle factura
        /// </summary>
    


        protected void imgbttTemas_Click(object sender, EventArgs e)
        {
           
        }

        protected void gvTemas_DataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal No = (Literal)e.Row.FindControl("ltralNo");
                    num1 += 1;
                    No.Text = num1.ToString() + ".";


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAplicaciones_DataBound(object sender, GridViewRowEventArgs e)
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

    
    }
}