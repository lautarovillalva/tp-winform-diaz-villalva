using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class Articulos_dao
    {
        AccesoDatos ds = new AccesoDatos();

        public List<Articulo> getArticulos()
        {

            List<Articulo> lista = new List<Articulo>();
            DataTable tabla = ds.ObtenerTabla("Articulos", "select a.Codigo, a.Nombre, a.Descripcion, m.Descripcion, c.Descripcion, a.ImagenUrl, a.Precio from ARTICULOS as a, MARCAS as m, CATEGORIAS as c  where a.IdMarca = m.Id and a.IdCategoria = c.Id");

            for(int i=0; i< tabla.Rows.Count; i++)
            {
                Articulo art = new Articulo
                {
                    Codigo = tabla.Rows[i][0].ToString(),
                    Nombre = tabla.Rows[i][1].ToString(),
                    Descripcion = tabla.Rows[i][2].ToString(),
                    Marca = new Marca(tabla.Rows[i][3].ToString()),
                    Categoria = new Categoria(tabla.Rows[i][4].ToString()),
                    UrlImagen = tabla.Rows[i][5].ToString(),
                    Precio = Convert.ToDouble(tabla.Rows[i][6])
                };

                lista.Add(art);
               
            }

            return lista;        
         }

    }
}
