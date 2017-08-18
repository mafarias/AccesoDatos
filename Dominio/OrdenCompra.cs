using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Dominio
{
    public class OrdenCompra
    {
        public Producto producto { get; set; }

        public int IdOrden { get; set; }

        public OrdenCompra()
        {
            producto = new Producto();
        }
    }
}
