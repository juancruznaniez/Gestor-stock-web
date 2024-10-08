﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }


            //if (!Seguridad.sesionActiva(Session["trainee"])) // Si NO hay una sesión activa, te redirijo al Login.
            //{
            //    Response.Redirect("Login.aspx", false);
            //}
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    Page.Validate();
            //    if (!Page.IsValid)
            //        return;

            //    TraineeNegocio negocio = new TraineeNegocio();
            //    Trainee user = (Trainee)Session["trainee"];
            //    //Escribir img si se cargó algo.
            //    if (txtImagen.PostedFile.FileName != "")
            //    {
            //        string ruta = Server.MapPath("./Images/");
            //        txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
            //        user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
            //    }

            //    user.Nombre = txtNombre.Text;
            //    user.Apellido = txtApellido.Text;
            //    user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

            //    //guardar datos perfil
            //    negocio.actualizar(user);

            //    //leer img
            //    Image img = (Image)Master.FindControl("imgAvatar");
            //    img.ImageUrl = "~/Images/" + user.ImagenPerfil;

            //}
            //catch (Exception ex)
            //{
            //    Session.Add("error", ex.ToString());
            //}



            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];
                //Escribir img si se cargó algo.
                if (txtImagen.PostedFile.FileName != "") // Si la imagen es distinto de vacio.
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                // Actualizar datos de perfil.
                negocio.actualizar(user);

                //Leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil; // La ~ nos lleva como al home web.
                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}