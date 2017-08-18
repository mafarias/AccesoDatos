using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    [Serializable]
    public class Cliente
    {
        public int Id { get; set; }

        public int Nit { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public int telefono { get; set; }

        public bool Eliminado { get; set; }

        public Cliente()
        {
            
        }
    }
}
