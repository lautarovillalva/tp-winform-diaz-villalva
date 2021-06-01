using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using DOMINIO;

namespace CarritoWeb
{
    public partial class Productos : System.Web.UI.Page
    {

        public List<Articulo> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulos_neg neg = new Articulos_neg();
            this.lista = neg.listaArticulos();

        }
    }
}