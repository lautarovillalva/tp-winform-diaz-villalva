using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data;

namespace DAO
{
    public class Categorias_dao
    {

        AccesoDatos ds = new AccesoDatos();

        // Devuelve una lista de categorias haciendo una consulta a la base de datos
        public List<Categoria> getCategoria()
        {
            List<Categoria> lista = new List<Categoria>();

            string consulta = "Select * from Categorias";

            DataTable tabla = ds.ObtenerTabla("Categoria", consulta);

            for(int i=0; i < tabla.Rows.Count; i++)
            {
                Categoria cat = new Categoria
                {
                    Id = Convert.ToInt32(tabla.Rows[i][0]),
                    Nombre = tabla.Rows[i][1].ToString()
                };


                lista.Add(cat);
            }

            return lista;
        }

    }
}
