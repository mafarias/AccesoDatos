using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Dominio;
using AccesoDatos;





namespace Negocio
{
    public class NegocioUsuarios
    {
        DatosUsuario datos = new DatosUsuario();

        List<Usuario> Lista = new List<Usuario>();

        Usuario usuario = new Usuario();

        public List<Usuario> ObtenerUsuarios()
        {
            Lista.Clear();
            Lista = datos.ObtenerUsuarios();
            return Lista;
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            Lista.Clear();
            Lista = datos.ObtenerUsuariosActivos();
            return Lista;
        }


        public Usuario ObtenerUsuario(Usuario usuario)
        {
            usuario = datos.ConsultarUsuario(usuario);

            return usuario;
        }

        public Usuario TraerLogin(Usuario usuario)
        {
                       
            usuario = datos.ConsultarUsuarioXLogin(usuario);
            
            if (!usuario.Eliminado && usuario.Id>0)
            {
                 usuario.RolUsuario.Mensaje =usuario.RolUsuario.Mensaje+ " " + usuario.Nombre;
            }
            else if (!usuario.Eliminado)
            {
                usuario.RolUsuario.Mensaje = "Usuario deshabilitado";
            }
            else
            {
                usuario.RolUsuario.Mensaje = "Username o clave incorrecta";
            }
            
            return usuario;
        }


        public int CrearUsuario(Usuario usuario)
        {
            usuario.Id = datos.CrearUsuario(usuario);

            return usuario.Id;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            bool res = datos.ModificarUsuario(usuario);
            return res;
        }
        

        public bool EliminarUsuario (Usuario usuario)
        {
            bool res = datos.EliminarUsuario(usuario);
            return res;
        }


    }
}
