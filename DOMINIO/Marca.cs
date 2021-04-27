using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Marca
    {
        public string Nombre { get; set; }


        public Marca(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
