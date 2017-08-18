

namespace Dominio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    [Serializable]
    public class Usuario
    
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Identificacion { get; set; }

        public string Direccion { get; set; }

        public int Telefono { get; set; }

        public bool Eliminado { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public Usuario() { }
    }
    
}
