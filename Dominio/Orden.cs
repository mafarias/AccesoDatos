using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Orden
    {
        public int Id { get; set; }

        public int NoOrden { get; set; }

        public Cliente Cliente { get; set; }

        public List<OrdenCompra> Productos { get; set; }

        public bool Eliminado { get; set; }

        public Orden()
        {
            Cliente = new Cliente();
            Productos = new List<OrdenCompra>();
        }
    }
}
