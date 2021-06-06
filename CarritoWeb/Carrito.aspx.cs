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
        private double total;

        public List<Carro> carrito = new List<Carro>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Carro>;

            }

            if (!IsPostBack)
            {
                calcularTotal();
            }

            repetidor.DataSource = carrito;
            repetidor.DataBind();

        }
        private void calcularTotal()
        {

            foreach (Carro item in carrito)
            {
                total += item.Subtotal;
            }

            lblTotal.Text = "TOTAL: $" + total;
            repetidor.DataBind();
        }

        protected void btnRestar_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "eventoRestar")
            {
                Carro aux = new Carro();

                bool paso = false;

                foreach (Carro item in carrito)
                {
                    if (item.Articulo.Id.ToString() == e.CommandArgument.ToString() && item.Cantidad >= 1)
                    {
                        aux = item;
                        item.Cantidad--;
                        item.Subtotal = item.Subtotal - item.Articulo.Precio;
                        paso = true;
                    }
                }
                if (aux.Cantidad == 0)
                {
                    carrito.Remove(aux);
                }

                if (paso)
                {
                    master.restarProducto();
                    calcularTotal();
                    repetidor.DataBind();
                    paso = false;
                }

            }

        }

        protected void btnSumar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSumar")
            {
                foreach (Carro item in carrito)
                {
                    if (item.Articulo.Id.ToString() == e.CommandArgument.ToString())
                    {
                        item.Cantidad++;
                        item.Subtotal = item.Subtotal + item.Articulo.Precio;

                    }
                }

                master.contarProducto();
                calcularTotal();
                repetidor.DataBind();
            }
        }

        protected void btnVaciar_Command(object sender, CommandEventArgs e)
        {
            carrito.Clear();
            Session["lista"] = this.carrito;

            master.setContador(0);
            Response.Redirect("Productos.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            Carro aux = new Carro();
            if (e.CommandName == "eventoEliminar")
            {
                foreach (Carro item in carrito)
                {
                    if (item.Articulo.Id.ToString() == e.CommandArgument.ToString())
                    {
                        aux = item;
                        
                    }

                }

                carrito.Remove(aux);
                master.setContador(master.getContador() - aux.Cantidad);
                calcularTotal();
                repetidor.DataBind();
            }

        }
    }
}