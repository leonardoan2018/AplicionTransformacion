using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IInterface;
using Presenter;

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
        public string NombreASubcategoria
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

        }

        protected void btnActualizarSubcategoria_Click(object sender, EventArgs e)
        {

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

        }

        protected void imgbttEliminarSubcategoria_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {

        }

        protected void btnActualizarCategoria_Click(object sender, EventArgs e)
        {

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

        }

        protected void imgbttEliminarCategoria_Click(object sender, EventArgs e)
        {

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
                presenter.CargarGrillaItemSubcategoria(subcategoria);
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

        }

        protected void lbtEditarItemSub_Click(object sender, EventArgs e)
        {

        }

        protected void lbtCancelarItemSub_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEditarItemSub_Click(object sender, EventArgs e)
        {

        }

        protected void imgbttEliminarItemSub_Click(object sender, EventArgs e)
        {

        }
    }
}