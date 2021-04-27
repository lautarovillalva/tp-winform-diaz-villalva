using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca MarcaArt { get; set; }
        public Categoria CategoriaArt { get; set; }
        public string UrlImagen { get; set; }
        public double Precio { get; set; }
    }
}
