using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using Entidades;
using Presentacion;

namespace Presentacion
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["trainee"])) //Si no es admin.
            {
                Session.Add("Error", " se requieren permisos de admin para ingresar en esta pantalla.");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("ArticulosLista", negocio.listarconSP()); // Para que cuando lea en el filtro text changed, capture la lista
                dgvArticulos.DataSource = Session["ArticulosLista"];
                dgvArticulos.DataBind();
            }
        }

        protected void btnAgregarrr_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx");
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["ArticulosLista"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper())); //ToUpper es para poder escribir en Maýús y min a la hora de filtrar. 
            dgvArticulos.DataSource= listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltrar.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                ddlCriterio.Items.Add("Contiene: ");
                ddlCriterio.Items.Add("Comienza con: ");
                ddlCriterio.Items.Add("Termina con: ");
            }
            else if(ddlCampo.SelectedItem.ToString() == "Marca")
            {
                ddlCriterio.Items.Add("Contiene: ");
                ddlCriterio.Items.Add("Comienza con: ");
                ddlCriterio.Items.Add("Termina con: ");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene: ");
                ddlCriterio.Items.Add("Comienza con: ");
                ddlCriterio.Items.Add("Termina con: ");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtfiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}