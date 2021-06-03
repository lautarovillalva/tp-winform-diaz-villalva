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
        public List<Carro> carrito = new List<Carro>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = int.Parse(Request.QueryString["id"]);
            //List<Articulo> articulos = (List<Articulo>)Session["listaArt"];

            //Articulo seleccionado = articulos.Find(x=> x.Id==id);

            //lblSeleccionado.Text=seleccionado.Nombre;

            if(Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Carro>;
                lblTotal.Text = "TOTAL: $" + calcularTotal().ToString();
            }


        }
        private double calcularTotal()
        {
            double total = 0;
            for (int i = 0; i < carrito.Count; i++)
            {
                total+= carrito[i].Subtotal;

            }
            return total;
        }

        protected void btnRestar_Command(object sender, CommandEventArgs e)
        {
            for (int i = 0; i < carrito.Count; i++)
            {
                if (e.CommandArgument.ToString() == carrito[i].Articulo.Id.ToString())
                {
                    carrito.Remove(carrito[i]);

                    Session["lista"] = this.carrito;
                }
            }

        }

        protected void btnSumar_Command(object sender, CommandEventArgs e)
        {
            for (int i = 0; i < carrito.Count; i++)
            {
                if (e.CommandArgument.ToString() == carrito[i].Articulo.Id.ToString())
                {
                    carrito[i].Cantidad++;
                    carrito[i].Subtotal = carrito[i].Subtotal + carrito[i].Articulo.Precio;


                    Session["lista"] = this.carrito;
                }
            }

        }

        protected void btnVaciar_Command(object sender, CommandEventArgs e)
        {
            carrito.Clear();
            Session["lista"] = this.carrito;
            Response.Redirect("Productos.aspx");
        }
    }
}