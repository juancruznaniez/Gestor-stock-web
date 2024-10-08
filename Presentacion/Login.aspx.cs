using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();
            try
            {
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;
                if (negocio.Login(trainee)) // Si la persona esta logueada, con esto la guardamos en sesion.
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrecta.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }



            //Usuario usuario;
            //UsuarioNegocio negocio = new UsuarioNegocio();
            //try
            //{
            //    usuario = new Usuario(txtEmail.Text, txtPassword.Text, false);
            //    if (negocio.Loguear(usuario))
            //    {
            //        Session.Add("usuario", usuario);
            //        Response.Redirect("~/MenuLogin1Ejemplo.aspx", false);
            //    }
            //    else
            //    {
            //        Session.Add("error", "user o pass incorrecta.");
            //        Response.Redirect("~/Error.aspx", false);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    Session.Add("error", ex.ToString());
            //    Response.Redirect("~/Error.aspx");
            //}
        }
    }
}