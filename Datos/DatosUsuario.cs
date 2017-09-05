using AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosUsuario : DAL
    {
        private DataTable registros = new DataTable();

        private List<Usuario> usuarios = new List<Usuario>();

        public DatosUsuario() : base() { }

        public List<Usuario> ObtenerUsuarios()
        {
            usuarios.Clear();
            registros = Consultar("ConsultarUsuarios");

            foreach (DataRow registro in registros.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.Id = Convert.ToInt32(registro["Id"]);
                usuario.Nombre = registro["Nombre"].ToString();
                usuario.Identificacion = Convert.ToInt32(registro["Identificacion"]);
                usuario.Direccion = registro["Direccion"].ToString();
                usuario.Telefono = Convert.ToInt32(registro["Telefono"]);
                usuario.Eliminado = Convert.ToBoolean(registro["eliminado"]);
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            usuarios.Clear();
            registros = Consultar("ConsultarUsuariosActivos");

            foreach (DataRow registro in registros.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.Id = Convert.ToInt32(registro["Id"]);
                usuario.Nombre = registro["Nombre"].ToString();
                usuario.Identificacion = Convert.ToInt32(registro["Identificacion"]);
                usuario.Direccion = registro["Direccion"].ToString();
                usuario.Telefono = Convert.ToInt32(registro["Telefono"]);
                usuario.Eliminado = Convert.ToBoolean(registro["eliminado"]);
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public Usuario ConsultarUsuario(Usuario usuario)
        {
            usuarios.Clear();
            Parametro ParametroUsuario = new Parametro("@Id", DbType.Int16, usuario.Id);
            registros = Consultar("ConsultarUsuario", ParametroUsuario);
            DatosRoles datosRol = new DatosRoles();

            if (registros.Rows.Count > 0)
            {
                usuario.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                usuario.Nombre = registros.Rows[0]["Nombre"].ToString();
                usuario.Direccion = registros.Rows[0]["Direccion"].ToString();
                usuario.Identificacion = Convert.ToInt32(registros.Rows[0]["Identificacion"]);
                usuario.Telefono = Convert.ToInt32(registros.Rows[0]["Telefono"]);
                usuario.Eliminado = Convert.ToBoolean(registros.Rows[0]["eliminado"]);
                usuario.UserName = registros.Rows[0]["userName"].ToString();
                usuario.PassWord = registros.Rows[0]["pass"].ToString();
                usuario.RolUsuario = new Rol();
                usuario.RolUsuario.Id = Convert.ToInt32(registros.Rows[0]["IdRol"]);
                usuario.RolUsuario = datosRol.ConsultarRolXId(usuario.RolUsuario.Id);

            }

            return usuario;
        }

        public Usuario ConsultarUsuarioXLogin(Usuario usuario)
        {
            usuarios.Clear();
            Parametro ParametroUserName = new Parametro("@userName", DbType.String, usuario.UserName);
            Parametro ParametroPass = new Parametro("@passWord", DbType.String, usuario.PassWord);
            registros = Consultar("ValidarLogin", ParametroUserName,ParametroPass);


            if (registros.Rows.Count > 0)
            {
                usuario.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                usuario.Nombre = registros.Rows[0]["Nombre"].ToString();
                usuario.Direccion = registros.Rows[0]["Direccion"].ToString();
                usuario.Identificacion = Convert.ToInt32(registros.Rows[0]["Identificacion"]);
                usuario.Telefono = Convert.ToInt32(registros.Rows[0]["Telefono"]);
                usuario.Eliminado = Convert.ToBoolean(registros.Rows[0]["eliminado"]);
                
            }

            return usuario;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            Parametro parametroId = new Parametro("@Id", DbType.Int16, usuario.Id);
            Parametro parametroNombre = new Parametro("@Nombre", DbType.String, usuario.Nombre);
            Parametro parametroDir = new Parametro("@Direccion", DbType.String, usuario.Direccion);
            Parametro parametroIdenti = new Parametro("@Identificacion", DbType.Int32, usuario.Identificacion);
            Parametro paremtroTelefono = new Parametro("@Telefono", DbType.String, usuario.Telefono);
            Parametro parametroEliminado = new Parametro("@Eliminado", DbType.Boolean, usuario.Eliminado);

            bool res;

            res = Actualizar("ModificarUsuario", parametroId, parametroNombre,parametroIdenti, parametroDir, paremtroTelefono, parametroEliminado);

            return res;
        }

        public int CrearUsuario(Usuario usuario)
        {
            Parametro parametroNombre = new Parametro("@Nombre", DbType.String, usuario.Nombre);
            Parametro parametroDir = new Parametro("@Direccion", DbType.String, usuario.Direccion);
            Parametro paremtroTelefono = new Parametro("@Telefono", DbType.String, usuario.Telefono);
            Parametro parametroIdenti = new Parametro("@Identificacion", DbType.Int32, usuario.Identificacion);
            Parametro parametroEliminado = new Parametro("@eliminado", DbType.Boolean, usuario.Eliminado);

            usuario.Id = Convert.ToInt32(Insertar("CrearUsuario", parametroNombre,parametroIdenti, parametroDir, paremtroTelefono, parametroEliminado));

            return usuario.Id;
        }

        public bool EliminarUsuario(Usuario usuario)
        {
            Parametro parametroId = new Parametro("@Id", DbType.Int16, usuario.Id);
            Parametro parametroEliminado = new Parametro("@eliminado", DbType.Boolean, usuario.Eliminado);

            bool res;
            res = Actualizar("EliminarUsuario", parametroId, parametroEliminado);
            return res;
        }
    }
}
