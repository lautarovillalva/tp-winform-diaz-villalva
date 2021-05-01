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

            string consulta = "select a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion, c.Descripcion, a.ImagenUrl, a.Precio from ARTICULOS as a, MARCAS as m, CATEGORIAS as c  where a.IdMarca = m.Id and a.IdCategoria = c.Id";

            DataTable tabla = ds.ObtenerTabla("Articulos", consulta);

            for(int i=0; i< tabla.Rows.Count; i++)
            {
                Articulo art = new Articulo
                {
                    Id = Convert.ToInt32(tabla.Rows[i][0]), 
                    Codigo = tabla.Rows[i][1].ToString(),
                    Nombre = tabla.Rows[i][2].ToString(),
                    Descripcion = tabla.Rows[i][3].ToString(),
                    Marca = new Marca(tabla.Rows[i][4].ToString()),
                    Categoria = new Categoria(tabla.Rows[i][5].ToString()),
                    UrlImagen = tabla.Rows[i][6].ToString(),
                    Precio = Convert.ToDouble(tabla.Rows[i][7])
                };

                lista.Add(art);
               
            }

            return lista;        
         }


        public List<Articulo> getArticulosFiltrados(string valor)
        {

            List<Articulo> lista = new List<Articulo>();

            string consulta = "select distinct a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion, c.Descripcion, a.ImagenUrl, a.Precio from ARTICULOS  as a , MARCAS as m, CATEGORIAS as c where a.IdMarca = m.Id and a.IdCategoria = c.Id and  (Nombre like '%" + valor + "%' or c.Descripcion like '%" + valor + "%'  or m.Descripcion like '%" + valor + "%' or a.Codigo like '%" + valor + "%')";

            DataTable tabla = ds.ObtenerTabla("Articulos", consulta);

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Articulo art = new Articulo
                {
                    Id = Convert.ToInt32(tabla.Rows[i][0]),
                    Codigo = tabla.Rows[i][1].ToString(),
                    Nombre = tabla.Rows[i][2].ToString(),
                    Descripcion = tabla.Rows[i][3].ToString(),
                    Marca = new Marca(tabla.Rows[i][4].ToString()),
                    Categoria = new Categoria(tabla.Rows[i][5].ToString()),
                    UrlImagen = tabla.Rows[i][6].ToString(),
                    Precio = Convert.ToDouble(tabla.Rows[i][7])
                };

                lista.Add(art);

            }

            return lista;
        }

        public bool setArticulo(Articulo articulo)
        {
           string consulta = "insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values" + "('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "','" + articulo.Categoria.Id + "','" + articulo.Categoria.Id + "','" + articulo.UrlImagen + "','" + articulo.Precio.ToString() + "')";
           int filas = ds.EjecutarConsulta(consulta);

            if (filas > 0)
            {
                return true;
            }

            return false;
        }
        public bool modArticulo(Articulo articulo)
        {
            string consulta = "update ARTICULOS set Codigo='"+articulo.Codigo+"', Nombre='"+articulo.Nombre+"', Descripcion='"+articulo.Descripcion+"', IdMarca='"+articulo.Marca.Id+"',IdCategoria='"+articulo.Categoria.Id+"', ImagenUrl='"+articulo.UrlImagen+ "', Precio='" + articulo.Precio.ToString() + "' where Id='"+articulo.Id+"'";
            int filas = ds.EjecutarConsulta(consulta);

            if (filas > 0)
            {
                return true;
            }

            return false;
        }
        public bool delArticulo(Articulo articulo)
        {
            string consulta = "delete from ARTICULOS where Id="+articulo.Id+"";
            int filas = ds.EjecutarConsulta(consulta);

            if (filas > 0)
            {
                return true;
            }

            return false;
        }


    }
}
