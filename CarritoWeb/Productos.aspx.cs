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


        public string articulo = "No hay Porducto seleccionado";

       

        protected void Page_Load(object cender, EventArgs e)
        {

            if (Session["lista"] != null)
            {

                carrito= Session["lista"] as List<Carro>;

                int cantidad = 0;
                foreach (Carro item in carrito)
                {
                    cantidad += item.Cantidad;

                }
                master.setContador(cantidad);
            }

        }
        private bool articuloexistente(string id)
        {
            bool existe = true;
            for (int i = 0; i < carrito.Count; i++)
            {
                if (id == carrito[i].Articulo.Id.ToString()) return existe;
            }

            return false;
        }
      

        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            
            Articulos_neg neg = new Articulos_neg();
            List<Articulo> lista = neg.listaArticulos();



            if (e.CommandName == "eventoAgregar")
            {
                if (master.getContador() == 0)
                {
                    foreach (Articulo item in lista)
                    {
                        if (item.Id.ToString() == e.CommandArgument.ToString())
                        {
                            Carro aux = new Carro
                            {
                                Articulo = item,
                                Cantidad = 1,
                                Subtotal = item.Precio
                            };
                            carrito.Add(aux);



                            Session["lista"] = this.carrito;


                        }
                    }
                }

                    if (articuloexistente(e.CommandArgument.ToString()) == true)
                    {
                    

                    }
                    else
                    {
                        foreach (Articulo item in lista)
                        {
                            if (item.Id.ToString() == e.CommandArgument.ToString())
                            {
                                Carro aux = new Carro
                                {
                                    Articulo = item,
                                    Cantidad = 1,
                                    Subtotal = item.Precio
                                };
                                carrito.Add(aux);



                                Session["lista"] = this.carrito;


                            }
                        }
                    }

                int cantidad=0;
                foreach (Carro item in carrito)
                {
                    cantidad += item.Cantidad;

                }
                master.setContador(cantidad);


            }

        }
    }
}