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

namespace AplicacionTransformacion.Forms
{
    public partial class FrmPasosAmbientes : System.Web.UI.Page, IPasosAmbientes
    {

        #region VARIABLES GLOBALES
        PPasosAmbientes presenterPasosAmbientes;

        int numero = 0;

        string mensajePopup = " ";
        #endregion

        #region METODOS SET Y GET
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
            presenterPasosAmbientes.GuardarPasoAmbiente();
        }

        protected void imgCalendario_Click(object sender, EventArgs e)
        {
            clrFechaPaso.Visible = true;
        }

        protected void clrFechaPaso_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaPaso.Text = Convert.ToString(clrFechaPaso.SelectedDate);
            clrFechaPaso.Visible = false;
            txtFechaPaso.Visible = true;
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
                pnlInfoPasos1.Visible = true;
                pnlInfoPasos2.Visible = false;
                pnlApoyoPasos.Visible = true;

                btnConsultarInfoPasos.Visible = false;
                btnGuardarEdicionPaso.Visible = false;
                btnGuardarInfoPaso.Visible = false;

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
                txtFechaPaso.Visible = false;
                pnlInfoPasos2.Visible = true;
                pnlApoyoPasos.Visible = false;
                btnConsultarInfoPasos.Visible = true;
                btnGuardarInfoPaso.Visible = true;
                Limpiar();

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
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}

