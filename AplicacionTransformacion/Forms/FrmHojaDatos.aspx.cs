using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IInterface;
using Presenter;
using Microsoft.Reporting.WebForms;

namespace AplicacionTransformacion.Forms
{
    public partial class FrmHojaDatos : System.Web.UI.Page, IHojaDatos
    {

        #region Variables de la clase

        public PHojaDatos presenter;
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
            presenter = new PHojaDatos(this);
            if (!IsPostBack)
            {
                rvReporteHojaDatos.Height = 1;
                presenter.CargarInformacioninicial();
            }
        }

        #endregion


        #region Metodos Set - Get

        #region Grillas

        /// <summary>
        /// Set - Obtiene la informacion de las aplicaciones desde la interface IAdmininistracion
        /// </summary>
        public object GrillaCategorias
        {
            set
            {
                this.gvCategoria.DataSource = value;
                this.gvCategoria.DataBind();
                this.gvCategoria.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface IAdmininistracion
        /// </summary>
        public object GrillaSubcategorias
        {
            set
            {
                this.gvSubcategoria.DataSource = value;
                this.gvSubcategoria.DataBind();
                this.gvSubcategoria.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Set - Obtiene la informacion de los contenidos desde la interface IAdmininistracion
        /// </summary>
        public object GrillaItemSubcategorias
        {
            set
            {
                this.gvItemSubcategoria.DataSource = value;
                this.gvItemSubcategoria.DataBind();
                this.gvItemSubcategoria.SelectedIndex = -1;
            }
        }
        #endregion

        #region Controles

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreCategoria
        {
            get
            {
                return txtNombreCategoria.Text;

            }
            set
            {
                txtNombreCategoria.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el AW de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreSubcategoria
        {
            get
            {
                return txtNombreSubcategoria.Text;

            }
            set
            {
                txtNombreSubcategoria.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object Categorias
        {
            set
            {
                dpCategoriaSubcategoria.DataSource = value;
                dpCategoriaSubcategoria.DataValueField = "Id";
                dpCategoriaSubcategoria.DataTextField = "Nombre";
                dpCategoriaSubcategoria.DataBind();
            }
            get
            {
                return dpCategoriaSubcategoria.SelectedValue;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object Proyectos
        {
            set
            {
                dpProyectos.DataSource = value;
                dpProyectos.DataValueField = "Id";
                dpProyectos.DataTextField = "Nombre";
                dpProyectos.DataBind();
            }
            get
            {
                return dpProyectos.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object Iniciativas
        {
            set
            {
                dpIniciativa.DataSource = value;
                dpIniciativa.DataValueField = "Id";
                dpIniciativa.DataTextField = "Nombre";
                dpIniciativa.DataBind();
            }
            get
            {
                return dpIniciativa.SelectedValue;
            }

        }
        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object Ambientes
        {
            set
            {
                dpAmbientes.DataSource = value;
                dpAmbientes.DataValueField = "Id";
                dpAmbientes.DataTextField = "Nombre";
                dpAmbientes.DataBind();
            }
            get
            {
                return dpAmbientes.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el AW de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string NombreItem
        {
            get
            {
                return txtNombreItem.Text;

            }
            set
            {
                txtNombreItem.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets -  Obtiene y asigna el AW de la aplicacion y lo envia hacia la interface IAdmininistracion
        /// </summary>
        public string DescripcionItem
        {
            get
            {
                return txtDescripcionItem.Text;

            }
            set
            {
                txtDescripcionItem.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object CategoriasReporte
        {
            set
            {
                dpCategoriaReporte.DataSource = value;
                dpCategoriaReporte.DataValueField = "Id";
                dpCategoriaReporte.DataTextField = "Nombre";
                dpCategoriaReporte.DataBind();
            }
            get
            {
                return dpCategoriaReporte.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object SubcategoriasReporte
        {
            set
            {
                dpSubcategoriaReporte.DataSource = value;
                dpSubcategoriaReporte.DataValueField = "Id";
                dpSubcategoriaReporte.DataTextField = "Nombre";
                dpSubcategoriaReporte.DataBind();
            }
            get
            {
                return dpSubcategoriaReporte.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets -  Obtiene y asigna el nombre del formato y lo envia hacia la interface IConsultaHallazgos
        /// </summary>
        public object AmbientesReporte
        {
            set
            {
                dpAmbienteReporte.DataSource = value;
                dpAmbienteReporte.DataValueField = "Id";
                dpAmbienteReporte.DataTextField = "Nombre";
                dpAmbienteReporte.DataBind();
            }
            get
            {
                return dpAmbienteReporte.SelectedValue;
            }
        }

        /// <summary>
        /// Método que se encarga de retornar y de asignar el origen de datos del rvDepartamentalAnual.
        /// </summary>
        public object ReporteHojaDatos
        {
            get
            {
                //Retorna el origen de datos del rvDepartamentalAnual.
                return rvReporteHojaDatos.LocalReport.DataSources.ElementAt(0).Value;
            }

            set
            {
                // Asigna el origen de datos al rvDepartamentalAnual.
                rvReporteHojaDatos.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("dsReporteHojaDatos", value);
                rvReporteHojaDatos.LocalReport.DataSources.Add(datasource);

                rvReporteHojaDatos.LocalReport.Refresh();
                rvReporteHojaDatos.DataBind();
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





        protected void btnCrearSubcategoria_Click(object sender, EventArgs e)
        {
            presenter.CrearSubCategoria();
        }

        protected void btnActualizarSubcategoria_Click(object sender, EventArgs e)
        {
            btnCrearSubcategoria.Visible = true;
            btnActualizarSubcategoria.Visible = false;
            presenter.ActualizarInfoSubCategoria(Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void btnCancelarSubcategoria_Click(object sender, EventArgs e)
        {

        }

        protected void gvSubcategoria_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void imgbttEditarSubcategoria_Click(object sender, EventArgs e)
        {
            btnCrearSubcategoria.Visible = false;
            btnActualizarSubcategoria.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idSubcategoria"] = Convert.ToInt32(gvSubcategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            dpCategoriaSubcategoria.SelectedValue = presenter.CargarInfoSubCategoria(Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void imgbttEliminarSubcategoria_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarSubCategoria(Convert.ToInt32(gvSubcategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }

        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            presenter.CrearCategoria();
        }

        protected void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            btnCrearCategoria.Visible = true;
            btnActualizarCategoria.Visible = false;
            presenter.ActualizarInfoCategoria(Convert.ToInt32(Session["idCategoria"]));
        }

        protected void btnCancelarCategoria_Click(object sender, EventArgs e)
        {

        }

        protected void gvCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void imgbttEditarCategoria_Click(object sender, EventArgs e)
        {
            btnCrearCategoria.Visible = false;
            btnActualizarCategoria.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idCategoria"] = Convert.ToInt32(gvCategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            presenter.CargarInforCategoria(Convert.ToInt32(Session["idCategoria"]));
        }

        protected void imgbttEliminarCategoria_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarCategoria(Convert.ToInt32(gvCategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString()));
        }

        protected void imgbDetalleSubcategoria_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSubcategoria.Visible = false;
                pnlDetalleSubcategoria.Visible = true;
                LinkButton lbttSeleccionar = (LinkButton)sender;
                TableCell celda = (TableCell)lbttSeleccionar.Parent;
                GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
                int subcategoria = Convert.ToInt32(gvSubcategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
                Session["idSubcategoria"] = subcategoria;
                presenter.CargarAmbientes();
                lblDetalleSubcategoria.Text= "Detalle Subcategoria " + presenter.CargarGrillaItemSubcategoria(subcategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        protected void dpAmbientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CargarGrillaItemSubcategoria(Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void lbtVolverSubcategorias_Click(object sender, EventArgs e)
        {
            pnlDetalleSubcategoria.Visible = false;
            pnlSubcategoria.Visible = true;
          
        }

        protected void lbtCrearItemSub_Click(object sender, EventArgs e)
        {
            presenter.CrearItemSubcategoria(Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void lbtEditarItemSub_Click(object sender, EventArgs e)
        {
            lbtCrearItemSub.Visible = true;
            lbtEditarItemSub.Visible = false;
            presenter.ActualizarInfoItemSubategoria(Convert.ToInt32(Session["idItemCategoria"]), Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void lbtCancelarItemSub_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEditarItemSub_Click(object sender, EventArgs e)
        {
            lbtCrearItemSub.Visible = false;
            lbtEditarItemSub.Visible = true;
            LinkButton lbttEditar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEditar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            Session["idItemCategoria"] = Convert.ToInt32(gvItemSubcategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString());
            dpAmbientes.SelectedValue= presenter.CargarInfoItemSubCategoria(Convert.ToInt32(Session["idItemCategoria"]));
        }

        protected void imgbttEliminarItemSub_Click(object sender, EventArgs e)
        {
            LinkButton lbttEliminar = (LinkButton)sender;
            TableCell celda = (TableCell)lbttEliminar.Parent;
            GridViewRow filaSeleccionar = (GridViewRow)celda.Parent;
            presenter.EliminarItemSubCategoria(Convert.ToInt32(gvItemSubcategoria.DataKeys[filaSeleccionar.RowIndex].Value.ToString()), Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void dpProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //presenter.CargarGrillaItemSubcategoria(Convert.ToInt32(Session["idSubcategoria"]));
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            lblSubtituloReporte.Visible = true;
            pnlHojaDatos.Height = 800;
            rvReporteHojaDatos.Height = 780;
            presenter.CargarReporte();
        }

        protected void dpCategoriaReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CargarSubCategoriasReporte();
        }

        /// <summary>
        /// Método que se ejecuta cuando se digita una palabra en el texbox producto detalle factura
        /// </summary>
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            try
            {
                PConsultas presenter;
                presenter = new PConsultas();
                List<string> lista = new List<string>();
                lista = presenter.BuscarProducto(prefixText);

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}