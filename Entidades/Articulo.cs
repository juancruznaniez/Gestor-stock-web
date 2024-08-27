using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Entidades
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Int32 IdMarca { get; set; }
        public Int32 IdCategoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }
    }
}
