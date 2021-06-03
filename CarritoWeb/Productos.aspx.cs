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
        public List<Carro> carrito = new List<Carro>();
        //public List<Articulo> carrito = new List<Articulo>();
        public static int contador;
        public string articulo = "No hay Porducto seleccionado";

       
        public int getContador()
        {
            return carrito.Count();
        }
        
        protected void Page_Load(object cender, EventArgs e)
        {

            if (Session["lista"] != null)
            {
                //carrito = Session["lista"] as List<Articulo>;
                carrito= Session["lista"] as List<Carro>;
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

            SiteMaster master = new SiteMaster();

            if (e.CommandName == "eventoAgregar")
            {
                if (getContador() == 0)
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
                //else
                //{
                    if (articuloexistente(e.CommandArgument.ToString()) == true)
                    {
                    
                        //for (int i = 0; i < carrito.Count; i++)
                        //{
                        //    if (e.CommandArgument.ToString() == carrito[i].Articulo.Id.ToString())
                        //    {
                        //        carrito[i].Cantidad++;
                        //        carrito[i].Subtotal = carrito[i].Subtotal + carrito[i].Articulo.Precio;


                        //        Session["lista"] = this.carrito;
                        //    }
                        //}

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

                //}


                master.contarProductos(carrito.Count);


            }

        }
    }
}