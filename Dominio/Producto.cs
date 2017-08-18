using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    [Serializable]
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cliente { get; set; }

        public bool Eliminado { get; set; }
        public Producto()
        { }

    }
}
