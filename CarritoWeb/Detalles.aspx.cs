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
        public SiteMaster master = new SiteMaster();
        public Articulo ArticuloDetalle ;
        private string IdArticulo = "";
        public List<Carro> carrito = new List<Carro>();
        public static int cantidad = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            IdArticulo = Request.QueryString["id"];

            ArticuloDetalle = new Articulo();
            buscarArticulo();

            if (Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Carro>;
            }

        }


        public void buscarArticulo()
        {
            Articulos_neg neg = new Articulos_neg();
            List<Articulo> lista = neg.listaArticulos();

            foreach(Articulo item in lista)
            {
              
              
                    if (IdArticulo == item.Id.ToString())
                    {
                        this.ArticuloDetalle = item;
                    }

            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }


        public void sumarCantidad(string id)
        {

            foreach (Carro item in carrito)
            {
                if (id == item.Articulo.Id.ToString())
                {
                    item.Cantidad+= cantidad;
                    item.Subtotal = item.Subtotal + item.Articulo.Precio;
                }
            }
        }


        public bool articuloexistente(string id)
        {

            foreach (Carro item in carrito)
            {
                if (id == item.Articulo.Id.ToString())
                {
                    return true;
                }
            }

            return false;
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            if (!articuloexistente(this.IdArticulo.ToString()))
            {


                Carro aux = new Carro
                {
                    Articulo = ArticuloDetalle,
                    Cantidad = cantidad,
                    Subtotal = ArticuloDetalle.Precio * Convert.ToDouble(cantidad)
                };

                carrito.Add(aux);
               
            }

            else
            {
               sumarCantidad(this.IdArticulo.ToString());
            }

            Session["lista"] = carrito;

            for (int i = 0; i < cantidad; i++)
            {
                master.contarProducto();
            }

            cantidad = 1;
            mostrarAlerta();

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            cantidad++;
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            cantidad--;
        }


        public void mostrarAlerta()
        {
            alert.Attributes.CssStyle.Add("display", "block");
        }
    }
}