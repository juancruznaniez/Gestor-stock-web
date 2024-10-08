using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MenuLogin1Ejemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null) // Esto es para validad que haya alguien logueado a la hora de entrar a la página.
            {
                Session.Add("Error", "debes loguearte para ingresar.");
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnPagina1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina1Login.aspx");
        }

        protected void btnPagina2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx");
        }
        
    }
}