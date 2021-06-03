using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;

namespace CarritoWeb
{
    public partial class SiteMaster : MasterPage
    {
        public static int contador = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void contarProductos(int cantidad)
        {

            contador = cantidad;
        }

        protected void btnVerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}