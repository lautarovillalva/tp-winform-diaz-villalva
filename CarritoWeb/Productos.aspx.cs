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

        public List<Articulo> carrito = new List<Articulo>();
        public static int contador;
        public string articulo = "No hay Porducto seleccionado";

       
        public int getContador()
        {
            return contador;
        }
        
        protected void Page_Load(object cender, EventArgs e)
        {

            if (Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Articulo>;
            }

        }

      

        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            
            Articulos_neg neg = new Articulos_neg();
            List<Articulo> lista = neg.listaArticulos();

            SiteMaster master = new SiteMaster();

            if (e.CommandName == "eventoAgregar")
            {
                contador++;

                foreach (Articulo item in lista)
                {
                    if(item.Id.ToString() == e.CommandArgument.ToString())
                    {

                        
                        this.carrito.Add(item);
                      
                    }
                }

                master.contarProductos();


                Session["lista"] = this.carrito;
            }

        }
    }
}