using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class NegocioCliente
    {
        DatosCliente datos = new DatosCliente();

        List<Cliente> Lista = new List<Cliente>();

        Cliente Cliente = new Cliente();

        public List<Cliente> ObtenerClientes()
        {
            Lista.Clear();
            Lista = datos.ObtenerClientes();
            return Lista;
        }

        public List<Cliente> ObtenerClientesActivos()
        {
            Lista.Clear();
            Lista = datos.ObtenerClientesActivos();
            return Lista;
        }


        public Cliente ObtenerCliente(Cliente Cliente)
        {
            Cliente = datos.ConsultarCliente(Cliente);

            return Cliente;
        }


        public int CrearCliente(Cliente Cliente)
        {
            Cliente.Id = datos.CrearCliente(Cliente);

            return Cliente.Id;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            bool res = datos.ModificarCliente(cliente);
            return res;
        }


        public bool EliminarCliente(Cliente Cliente)
        {
            bool res = datos.EliminarCliente(Cliente);
            return res;
        }


    }
}

