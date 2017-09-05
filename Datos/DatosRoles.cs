using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using System.Data;
using AccesoDatos;

namespace Datos
{
    public class DatosRoles : DAL
    {

        private DataTable registros = new DataTable();
        List<Rol> Lista = new List<Rol>();

        public DatosRoles() : base() { }

        public List<Rol> ConsultarRoles()
        {
            Lista.Clear();
            registros = Consultar("ConsultarRoles");
            foreach (DataRow registro in registros.Rows)
            {
                Rol rol = new Rol();
                rol.Id = Convert.ToInt32(registro["Id"]);
                rol.Nombre = registro["nombre"].ToString();
                rol.urlInicio = registro["urlInicio"].ToString();
                rol.Mensaje= registro["mensajeInicio"].ToString();
                Lista.Add(rol);
            }
            
            return Lista;
           
        }
        
        public Rol ConsultarRolXId(int id)
        {
            Rol rol = new Rol();

            Parametro parId = new Parametro("@Id", DbType.Int16, id);
            DatosFormulario datosForm = new DatosFormulario();
            registros.Clear();
            registros = Consultar("ConsultarRolXID",parId);
            if (registros.Rows.Count > 0)
            {
                rol.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                rol.Nombre = registros.Rows[0]["nombre"].ToString();
                rol.urlInicio = registros.Rows[0]["urlInicio"].ToString();
                rol.Mensaje = registros.Rows[0]["mensajeInicio"].ToString();
                rol.Listaformularios = datosForm.ObtenerFormulariosXrol(rol.Id);

            }

            return rol;
        }
    }
}
