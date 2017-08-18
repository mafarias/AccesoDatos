using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Dominio;
using System.Data;

namespace Datos
{
    public class DatosCliente : DAL
    {
        private DataTable registros = new DataTable();

        private List<Cliente> Clientes = new List<Cliente>();

        public DatosCliente() : base() { }

        public List<Cliente> ObtenerClientes()
        {
            Clientes.Clear();
            registros = Consultar("ConsultarClientes");

            foreach (DataRow registro in registros.Rows)
            {
                Cliente Cliente = new Cliente();
                Cliente.Id = Convert.ToInt32(registro["Id"]);
                Cliente.Nombre = registro["Nombre"].ToString();
                Cliente.Nit = Convert.ToInt32(registro["Nit"]);
                Cliente.Direccion = registro["Direccion"].ToString();
                Cliente.telefono = Convert.ToInt32(registro["Telefono"]);
                Cliente.Eliminado = Convert.ToBoolean(registro["eliminado"]);
                Clientes.Add(Cliente);
            }
            return Clientes;
        }

        public List<Cliente> ObtenerClientesActivos()
        {
            Clientes.Clear();
            registros = Consultar("ConsultarClientesActivos");

            foreach (DataRow registro in registros.Rows)
            {
                Cliente Cliente = new Cliente();
                Cliente.Id = Convert.ToInt32(registro["Id"]);
                Cliente.Nombre = registro["Nombre"].ToString();
                Cliente.Nit = Convert.ToInt32(registro["Nit"]);
                Cliente.Direccion = registro["Direccion"].ToString();
                Cliente.telefono = Convert.ToInt32(registro["Telefono"]);
                Cliente.Eliminado = Convert.ToBoolean(registro["eliminado"]);
                Clientes.Add(Cliente);
            }
            return Clientes;
        }

        public Cliente ConsultarCliente(Cliente Cliente)
        {
            Clientes.Clear();
            Parametro ParametroCliente = new Parametro("@Id", DbType.Int16, Cliente.Id);
            registros = Consultar("ConsultarCliente", ParametroCliente);


            if (registros.Rows.Count > 0)
            {
                Cliente.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                Cliente.Nombre = registros.Rows[0]["Nombre"].ToString();
                Cliente.Direccion = registros.Rows[0]["Direccion"].ToString();
                Cliente.Nit = Convert.ToInt32(registros.Rows[0]["Nit"]);
                Cliente.telefono = Convert.ToInt32(registros.Rows[0]["Telefono"]);
                Cliente.Eliminado = Convert.ToBoolean(registros.Rows[0]["eliminado"]);

            }

            return Cliente;
        }

        public bool ModificarCliente(Cliente Cliente)
        {
            Parametro parametroId = new Parametro("@Id", DbType.Int16, Cliente.Id);
            Parametro parametroNombre = new Parametro("@Nombre", DbType.String, Cliente.Nombre);
            Parametro parametroNit = new Parametro("@Nit", DbType.Int32, Cliente.Nit);
            Parametro parametroDir = new Parametro("@Direccion", DbType.String, Cliente.Direccion);
            Parametro paremtroTelefono = new Parametro("@Telefono", DbType.String, Cliente.telefono);
            Parametro parametroEliminado = new Parametro("@Eliminado", DbType.Boolean, Cliente.Eliminado);

            bool res;

            res = Actualizar("ModificarCliente", parametroId, parametroNombre, parametroNit, parametroDir, paremtroTelefono, parametroEliminado);

            return res;
        }

        public int CrearCliente(Cliente Cliente)
        {
            Parametro parametroNombre = new Parametro("@Nombre", DbType.String, Cliente.Nombre);
            Parametro parametroDir = new Parametro("@Direccion", DbType.String, Cliente.Direccion);
            Parametro parametroNit = new Parametro("@Nit", DbType.Int32, Cliente.Nit);
            Parametro paremtroTelefono = new Parametro("@Telefono", DbType.String, Cliente.telefono);
            Parametro parametroEliminado = new Parametro("@Eliminado", DbType.Boolean, Cliente.Eliminado);

            Cliente.Id = Convert.ToInt32(Insertar("CrearCliente", parametroNombre, parametroNit, parametroDir, paremtroTelefono, parametroEliminado));

            return Cliente.Id;
        }

        public bool EliminarCliente(Cliente Cliente)
        {
            Parametro parametroId = new Parametro("@Id", DbType.Int16, Cliente.Id);
            Parametro parametroEliminado = new Parametro("@Eliminado", DbType.Boolean, Cliente.Eliminado);

            bool res;
            res = Actualizar("EliminarCliente", parametroId, parametroEliminado);
            return res;
        }
    }

}

