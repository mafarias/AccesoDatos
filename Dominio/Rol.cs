using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string urlInicio { get; set; }

        public string Mensaje { get; set; }

        public List<Formulario> Listaformularios { get; set; }
    }
}
