using System;
using System.Collections.Generic;
using System.Text;
using DOMINIO;
using DAO;

namespace NEGOCIO
{
    public class Categorias_neg
    {
        public List<Categoria> ListarCategorias()
        {
            Categorias_dao aux = new Categorias_dao();
            return aux.getCategoria();

        }
    }
}
