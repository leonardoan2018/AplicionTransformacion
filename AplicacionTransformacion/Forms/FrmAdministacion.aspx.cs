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
        public int num3 = 0;

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
        public object GrillaProyectos
        {
            set
            {
                this.gvProyectos.DataSource = value;
                this.gvProyectos.DataBind();
                this.gvProyectos.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface IAdmininistracion
        /// </summary>
        public object GrillaIniciativas
        {
            set
            {
                this.gvIniciativa.DataSource = value;
                this.gvIniciativa.DataBind();
                this.gvIniciativa.SelectedIndex = -1;
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
        public string NombreProyecto
        {
            get
            {
                return txtNombreProyecto.Text;

            }
            set
            {
                txtNombreProyecto.Text = value;
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
        public object ProyectosIniciativas
        {
            set
            {
                dpProyectosIniciativas.DataSource = value;
                dpProyectosIniciativas.DataValueField = "Id";
                dpProyectosIniciativas.DataTextField = "Nombre";
                dpProyectosIniciativas.DataBind();
            }
            get
            {
                return dpProyectosIniciativas.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del contenido y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreIniciativa
        {
            get
            {
                return txtNombreIniciativa.Text;

            }
            set
            {
                txtNombreIniciativa.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del contenido y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string PMOIniciativa
        {
            get
            {
                return txtPMO.Text;

            }
            set
            {
                txtPMO.Text = value;
            }
        }

       

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object IniciativasTema
        {
            set
            {
                dpIniciativasTema.DataSource = value;
                dpIniciativasTema.DataValueField = "Id";
                dpIniciativasTema.DataTextField = "Nombre";
                dpIniciativasTema.DataBind();
            }
            get
            {
                return dpIniciativasTema.SelectedValue;
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

        #region Proyecto

        protected void btnCrearProyecto_Click(object sender, EventArgs e)
        {
            presenter.CrearProtecto();
        }

        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {
            presenter.ActualizarProyecto(Convert.ToInt32(Session["idProyecto"]));
            btnCrearProyecto.Visible = true;
            btnActualizarProyecto.Visible = false;
        }

        protected void btnCancelarProyecto_Click(object sender, EventArgs e)
        {
            txtNombreProyecto.Text = "";
            txtAW.Text = "";
        }

        protected void imgbttEditarProyecto_Click(object sender, EventArgs e)
        {
            btnCrearProyecto.Visible = false;
            btnActualizarProyecto.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idProyecto"] = Convert.ToInt32(gvProyectos.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            presenter.CargarInfoProyecto(Convert.ToInt32(Session["idProyecto"]));
        }

        protected void imgbttEliminarProyecto_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarProyecto(Convert.ToInt32(gvProyectos.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }

        protected void gvProyectos_RowDataBound(object sender, GridViewRowEventArgs e)
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
        #endregion

        #region Iniciativa
        protected void lbtCrearIniciativa_Click(object sender, EventArgs e)
        {
            presenter.CrearIniciativa();
        }

        protected void lbtEditarIniciativa_Click(object sender, EventArgs e)
        {
            presenter.ActualizarIniciativa(Convert.ToInt32(Session["idIniciativa"]));
            lbtCrearIniciativa.Visible = true;
            lbtEditarIniciativa.Visible = false;
        }

        protected void lbtCancelarIniciativa_Click(object sender, EventArgs e)
        {

        }



        protected void imgbttEditarIniciativa_Click(object sender, EventArgs e)
        {
            lbtCrearIniciativa.Visible = false;
            lbtEditarIniciativa.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idIniciativa"] = Convert.ToInt32(gvIniciativa.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            presenter.CargarInfoIniativa(Convert.ToInt32(Session["idIniciativa"]));
        }

        protected void imgbttEliminarIniciativa_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarIniciativa(Convert.ToInt32(gvIniciativa.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }

        protected void gvIniciativa_RowDataBound(object sender, GridViewRowEventArgs e)
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