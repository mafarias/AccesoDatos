using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dominio;
using AccesoDatos;
using System.Text;

namespace Datos
{
    public class DatosFormulario: DAL
    {
        private DataTable registros = new DataTable();


        
        

        List<Formulario> Lista = new List<Formulario>();

        public List<Formulario> ObtenerFormulariosXrol(int IdRol)
        {
            Lista.Clear();
            registros.Clear();
            Parametro parIdRol = new Parametro("@idRol", DbType.Int32, IdRol);
            registros = Consultar("ConsultarFormulariosXrol",parIdRol);

            foreach (DataRow registro in registros.Rows)
            {
                Formulario form = new Formulario();
                form.Id = Convert.ToInt32(registro["Id"]);
                form.Nombre = registro["nombre"].ToString();
                form.Url = registro["url"].ToString();
                form.IsInicio = Convert.ToBoolean(registro["isInicio"]);
                Lista.Add(form);
            }
            return Lista;
        }

     
    }
}
