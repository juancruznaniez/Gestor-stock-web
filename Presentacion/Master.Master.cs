using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using Datos;

namespace Presentacion
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgAvatar.ImageUrl = "https://i.pinimg.com/736x/bd/1c/c7/bd1cc751865c67de695216da045579d5.jpg";
            if (!(Page is Login || Page is Registro || Page is Default))
            {
                if (!Seguridad.sesionActiva(Session["trainee"])) // Si NO hay una sesión activa, te redirijo al Login.
                {
                    Response.Redirect("Login.aspx", false);
                }
                //else
                //{
                //    Trainee user = (Trainee)Session["trainee"];
                //    lblUser.Text = user.Email;
                //    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                //    {
                //        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                //    }
                //}
            }

            if (Seguridad.sesionActiva(Session["trainee"]))
                imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
            else
                imgAvatar.ImageUrl = "https://i.pinimg.com/736x/bd/1c/c7/bd1cc751865c67de695216da045579d5.jpg";
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}