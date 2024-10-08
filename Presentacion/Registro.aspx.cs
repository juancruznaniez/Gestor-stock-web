using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;
using Entidades;

namespace Presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = traineeNegocio.insertarNuevo(user);
                Session.Add("trainee", user); // Con esto nos queda la sesión abierta.

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}