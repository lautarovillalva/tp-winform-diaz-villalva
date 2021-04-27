using System;
using System.Collections.Generic;
using System.Text;
using DOMINIO;
using DAO;
using System.Data;

namespace NEGOCIO
{
    public class Articulos_neg
    {

        public List<Articulo> listaArticulos()
        {
            Articulos_dao aux = new Articulos_dao();
            return aux.getArticulos();
        }

    }
}
