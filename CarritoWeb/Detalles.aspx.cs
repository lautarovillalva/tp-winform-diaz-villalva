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
    public partial class Detalles : System.Web.UI.Page
    {
        public Articulo ArticuloDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulos_neg articulos_Neg = new Articulos_neg();
            List<Articulo> listado;
            try
            {
                listado = articulos_Neg.listaArticulos();
                int id = int.Parse(Request.QueryString["Id"]);
                
                ArticuloDetalle = listado.Find(x => x.Id == id);

            }
            catch (Exception ex)
            {
                //reponse error.aspx
                throw ex;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}