using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Carrito
    {
        public int Cantidad { get; set; }
        public Articulo articulo { get; set; }
        public decimal Subtotal { get; set; }
    }
}
