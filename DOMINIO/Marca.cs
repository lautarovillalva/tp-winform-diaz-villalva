using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public Marca(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public Marca() {}

        public override string ToString()
        {
            return Nombre;
        }
    }
}
