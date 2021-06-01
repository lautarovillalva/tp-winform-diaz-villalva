using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using NEGOCIO;

namespace CarritoWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            List<Articulo> articulos = (List<Articulo>)Session["listaArt"];

            Articulo seleccionado = articulos.Find(x=> x.Id==id);

            lblSeleccionado.Text=seleccionado.Nombre;

        }
    }
}