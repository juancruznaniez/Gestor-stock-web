using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;
using Entidades;
using System.Security.Cryptography;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel.Design.Serialization;

namespace Presentacion
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                // Configuración inicial de la pantalla
                if (!IsPostBack)
                {
                // Explicación:
                   // articulos.Select(a => a.Marca).Distinct().ToList();: Esto selecciona solo las marcas de los artículos y elimina duplicados usando Distinct().
                    // DataTextField = "Descripcion": Especifica que la propiedad Descripcion de la marca se mostrará en el DropDownList.
                    // DataValueField = "Id": Especifica que el valor del DropDownList será el ID de la marca.

                    // Obtener la lista de artículos
                    var articulos = articuloNegocio.listarconSP();

                    // Cargar marcas
                    ddlMarca.DataSource = articulos
                                          .Select(a => a.Marca)
                                          .Distinct()
                                          .ToList();
                    ddlMarca.DataTextField = "Descripcion";  // La descripción de la marca
                    ddlMarca.DataValueField = "Id";          // El ID de la marca
                    ddlMarca.DataBind();
                    // Agregar un valor vacío
                    ddlMarca.Items.Insert(0, new ListItem("-- Selecciona una marca --", ""));




                    // Cargar categorías
                    ddlCategoria.DataSource = articulos
                                              .Select(a => a.Categoria)
                                              .Distinct()
                                              .ToList();
                    ddlCategoria.DataTextField = "Descripcion";  // La descripción de la categoría
                    ddlCategoria.DataValueField = "Id";          // El ID de la categoría
                    ddlCategoria.DataBind();
                    // Agregar un valor vacío
                    ddlCategoria.Items.Insert(0, new ListItem("-- Selecciona una categoría --", ""));
                    //                Explicación:
                    //                    Items.Insert(0, new ListItem("-- Selecciona una marca --", ""));: Inserta un nuevo ListItem en la posición 0 del DropDownList con el texto-- Selecciona una marca-- y un valor vacío("").
                    //Lo mismo se aplica para las categorías.
                }

                //Configuración si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : ""; // Hago referencia al id del redirect del dgv articulos selected index changed. Si ingresa un id deja de ser nulo, entonces si ingresa un id seleccionado es porque es para modificar.
                if (id != "" && !IsPostBack) 
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    //List<Articulo> lista = negocio.listar(id);
                    //Articulo seleccionado = lista[0];
                    Articulo seleccionado = (negocio.listar(id))[0]; // De la lista que devuelve este metodo, el primer elemento[0]. Son los dos pasos de arriba resumidos.

                    //Pre cargar todos los campos.
                    txtId.Text = id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtImagenUrl_TextChanged(sender, e); // Para que cargue la imagen.
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //Articulo nuevo = new Articulo();
            //ArticuloNegocio negocio = new ArticuloNegocio();
            //nuevo.Id = int.Parse(txtId.Text);
            //nuevo.Codigo = txtCodigo.Text;
            //nuevo.Nombre = txtNombre.Text;
            //nuevo.Descripcion = txtDescripcion.Text;
            //nuevo.Precio = int.Parse(txtPrecio.Text);
            //nuevo.ImagenUrl = txtImagenUrl.Text;

            //nuevo.Marca = new Marca();
            //nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            //nuevo.Categoria = new Categoria();
            //nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

            //    if (Request.QueryString["id"] != null)
            //    {
            //        negocio.modificarConSP(nuevo);
            //    }
            //    else
            //    {
            //        negocio.agregar(nuevo);
            //    }
            //Response.Redirect("ArticulosLista.aspx", false);
            //}
            //catch (Exception ex)
            //{
            //    Session.Add("error", ex);
            //    throw;
            //}
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                // Validar y asignar el ID
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    nuevo.Id = int.Parse(txtId.Text);
                }

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                // Validar el precio
                decimal precio;
                if (decimal.TryParse(txtPrecio.Text, out precio))
                {
                    nuevo.Precio = precio;
                }
                else
                {
                    // Manejar el caso de error, por ejemplo:
                    // lblError.Text = "Formato de precio incorrecto.";
                    return;
                }

                nuevo.ImagenUrl = txtImagenUrl.Text;

                // Validar Marca y Categoria
                int marcaId, categoriaId;
                if (int.TryParse(ddlMarca.SelectedValue, out marcaId))
                {
                    nuevo.Marca = new Marca { Id = marcaId };
                }
                else
                {
                    // Manejar error en marca
                    return;
                }

                if (int.TryParse(ddlCategoria.SelectedValue, out categoriaId))
                {
                    nuevo.Categoria = new Categoria { Id = categoriaId };
                }
                else
                {
                    // Manejar error en categoría
                    return;
                }

                // Modificar o agregar según corresponda
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                Response.Redirect("ArticulosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkconfirmarEliminacion.Checked) 
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("ArticulosLista.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = (new ArticuloNegocio());
                negocio.eliminarLogico(int.Parse(txtId.Text));
                Response.Redirect("ArticulosLista.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}