using System;
using System.Collections.Generic;
using System.Text;
using DOMINIO;
using DAO;
using System.Data;

namespace NEGOCIO
{
    // agregando otro  comentario de prueba por el tom
    public class Articulos_neg
    {

        public List<Articulo> listaArticulos()
        {
            Articulos_dao aux = new Articulos_dao();
            return aux.getArticulos();
        }

        public List<Articulo> listaArticulosFiltrados(string valor)
        {
            Articulos_dao aux = new Articulos_dao();
            return aux.getArticulosFiltrados(valor);
        }


        public bool agregarNuevoArticulo(Articulo articulo)
        {

            Articulos_dao aux = new Articulos_dao();
            return aux.setArticulo(articulo);

        }

        public bool modificarArticulo(Articulo articulo)
        {

            Articulos_dao aux = new Articulos_dao();
            return aux.modArticulo(articulo);

        }
        public bool eliminarArticulo(Articulo articulo)
        {

            Articulos_dao aux = new Articulos_dao();
            return aux.delArticulo(articulo);

        }


    }
}
