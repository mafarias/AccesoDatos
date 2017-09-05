using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Datos;


namespace Negocio
{
    public class NegocioRoles
    {
        DatosRoles datos = new DatosRoles();
        
        public List<Rol> ConsultarRoles()
        {
            try
            {
                return datos.ConsultarRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Rol ConsultarRolXId(int id)
        {
            try
            {
                return datos.ConsultarRolXId(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
