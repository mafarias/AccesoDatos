﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    [Serializable]
    public class Formulario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Url { get; set; }

        public bool IsInicio { get; set; }

        public List<Control> listControles { get; set; }
    }
}
