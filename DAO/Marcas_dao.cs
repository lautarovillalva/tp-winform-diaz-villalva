using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data;

namespace DAO
{
    public class Marcas_dao
    {
        AccesoDatos ds = new AccesoDatos();

        // Devuelve una lista de categorias haciendo una consulta a la base de datos
        public List<Marca> getMarcas()
        {
            List<Marca> lista = new List<Marca>();

            string consulta = "Select * from Marcas";

            DataTable tabla = ds.ObtenerTabla("Marca", consulta);

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Marca mar = new Marca
                {
                    Id = Convert.ToInt32(tabla.Rows[i][0]),
                    Nombre = tabla.Rows[i][1].ToString()
                };


                lista.Add(mar);
            }

            return lista;
        }
    }
}
