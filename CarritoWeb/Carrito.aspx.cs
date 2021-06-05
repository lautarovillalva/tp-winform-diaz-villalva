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
        SiteMaster master = new SiteMaster();

        public List<Carro> carrito = new List<Carro>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Carro>;
                lblTotal.Text = "TOTAL: $" + calcularTotal().ToString();
            }

            int cantidad = 0;
            foreach (Carro item in carrito)
            {
                cantidad += item.Cantidad;

            }
            master.setContador(cantidad);
            repetidor.DataSource = carrito;
            repetidor.DataBind();


        }
        private double calcularTotal()
        {
            double total = 0;
            for (int i = 0; i < carrito.Count; i++)
            {
                total += carrito[i].Subtotal;

            }
            return total;
        }

        protected void btnRestar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoRestar")
            {
            int cantidad = 0;
                for (int i = 0; i < carrito.Count; i++)
                {
                    if (e.CommandArgument.ToString() == carrito[i].Articulo.Id.ToString())
                    {
                        carrito[i].Cantidad--;
                        carrito[i].Subtotal = carrito[i].Subtotal - carrito[i].Articulo.Precio;


                        Session["lista"] = this.carrito;
                    }
                    cantidad += carrito[i].Cantidad;
                    master.setContador(cantidad);
                }

            }

        }

        protected void btnSumar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSumar")
            {
                int cantidad = 0;
                for (int i = 0; i < carrito.Count; i++)
                {
                    if (e.CommandArgument.ToString() == carrito[i].Articulo.Id.ToString())
                    {
                        carrito[i].Cantidad++;
                        carrito[i].Subtotal = carrito[i].Subtotal + carrito[i].Articulo.Precio;


                        Session["lista"] = this.carrito;
                    }
                    cantidad += carrito[i].Cantidad;
                    master.setContador(cantidad);
                }

            }
        }

        protected void btnVaciar_Command(object sender, CommandEventArgs e)
        {
            carrito.Clear();
            Session["lista"] = this.carrito;

            master.setContador(0);
            Response.Redirect("Productos.aspx");
        }
    }
}