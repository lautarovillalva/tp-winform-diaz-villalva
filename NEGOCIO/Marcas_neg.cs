using System;
using System.Collections.Generic;
using System.Text;
using DOMINIO;
using DAO;

namespace NEGOCIO
{
    public class Marcas_neg
    {
        public List<Marca> ListarMarcas()
        {
            Marcas_dao aux = new Marcas_dao();
            return aux.getMarcas();
        }
    }
}
