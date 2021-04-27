using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Categoria
    {
        public string Nombre { get; set; }

        public Categoria(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
