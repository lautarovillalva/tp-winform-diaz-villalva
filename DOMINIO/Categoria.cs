using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


      

        public Categoria(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public Categoria() { }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
