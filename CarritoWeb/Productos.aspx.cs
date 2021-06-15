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
        public SiteMaster master = new SiteMaster();
        public List<Carro> carrito = new List<Carro>();


        public string producto = "";


        protected void Page_Load(object cender, EventArgs e)
        {

            cargarPorductos();

            if (Session["lista"] != null)
            {
                carrito = Session["lista"] as List<Carro>;
            }

        }


        public void cargarPorductos()
        {
            Articulos_neg art = new Articulos_neg();
            rpProductos.DataSource = art.listaArticulos();
            rpProductos.DataBind();
        }


        //Verifica si exite el articulo en el carrito en caso contrario devuelve falso 
        public bool articuloexistente(string id)
        {

            foreach(Carro item in carrito)
            {
                if(id == item.Articulo.Id.ToString())
                {
                    return true;
                }
            }

            return false;
        }


        //Setea la cantidad y el subtotal de los articulos dentro en del carrito
        public  void  sumarCantidad(string id)
        {

            foreach (Carro item in carrito)
            {
                if (id == item.Articulo.Id.ToString())
                {
                    item.Cantidad++;
                    item.Subtotal = item.Subtotal + item.Articulo.Precio;
                }
            }
        }


        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            
            Articulos_neg neg = new Articulos_neg();
            List<Articulo> lista = neg.listaArticulos();

            if (e.CommandName == "eventoAgregar")
            {
                    foreach (Articulo item in lista)
                    {
                        if (item.Id.ToString() == e.CommandArgument.ToString())
                        {

                        this.producto = item.Nombre;

                        if (!articuloexistente(e.CommandArgument.ToString())) {

                              Carro aux = new Carro
                              {
                                Articulo = item,
                                Cantidad = 1,
                                Subtotal = item.Precio
                              };

                               carrito.Add(aux);
                           }

                          else
                          {
                             sumarCantidad(e.CommandArgument.ToString());
                          }

                           Session["lista"] = carrito;
                        }
                    }

                master.contarProducto();

                
                mostrarAlerta();
            }

        }


       public void mostrarAlerta()
        {
            alert.Attributes.CssStyle.Add("display", "block");
        }

     
    }
}