using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using AccesoDatos;
using System.Data;


namespace Datos
{
    public class DatosOrdenCompras : DAL
    {
        DataTable registros = new DataTable();

        public DatosOrdenCompras(): base(){}

                
        public int CrearOrdenCompra(Orden orden)
        {
            Parametro parametroIdCliente = new Parametro("@IdCliente", DbType.Int32, orden.Cliente.Id);
            Parametro parametroNoOrden = new Parametro("@NoOrden", DbType.Int32, orden.NoOrden);
            Parametro parametroEliminado = new Parametro("@Eliminado", DbType.Boolean, orden.Eliminado);

            orden.Id = Insertar("CrearOrdenCompra", parametroIdCliente, parametroNoOrden, parametroEliminado);

            foreach(OrdenCompra producto in orden.Productos)
            {
                Parametro parametroIdOrden = new Parametro("@IdOrden", DbType.Int32, orden.Id);
                Parametro parametroIdProducto = new Parametro("@IdProducto", DbType.Int32, producto.producto.Id);

                Actualizar("CrearOrdenProducto", parametroIdOrden, parametroIdProducto);
            }

            return orden.Id;
        }

        public bool ActualizarOrden(Orden orden)
        {
            Parametro parametroId = new Parametro("@IdOrden", DbType.Int32, orden.Id);
            Parametro parametroIdCompra = new Parametro("@Id", DbType.Int32, orden.Id);
            Parametro parametroIDCLiente = new Parametro("@IdCliente", DbType.Int32, orden.Cliente.Id);
            Parametro ParametroEliminado = new Parametro("@Eliminado", DbType.Boolean, orden.Eliminado);
            Actualizar("DesasociarProductos", parametroId);

            bool res = Actualizar("ModificarOrdenCompra", parametroIdCompra,parametroIDCLiente,ParametroEliminado);

            foreach (OrdenCompra producto in orden.Productos)
            {
                Parametro parametroIdOrden = new Parametro("@IdOrden", DbType.Int32, orden.Id);
                Parametro parametroIdProducto = new Parametro("@IdProducto", DbType.Int32, producto.producto.Id);

                Actualizar("CrearOrdenProducto", parametroIdOrden, parametroIdProducto);
            }

            return res;

        }



        public List<OrdenCompra> ObtenerOrdenesProductoXOrden(int no)
        {
            List<OrdenCompra> Ordenes = new List<OrdenCompra>();
            DataTable registros2 = new DataTable();

            Parametro Orden = new Parametro("@IdOrden",DbType.Int32,no);


            registros2 = Consultar("ObtenerOrdenCompraXId", Orden);
            foreach(DataRow registro in registros2.Rows)
            {
                OrdenCompra ordenco = new OrdenCompra();
                ordenco.IdOrden = Convert.ToInt32(registro["IdOrden"]);
                ordenco.producto.Id = Convert.ToInt32(registro["IdProducto"]);
                Ordenes.Add(ordenco);
            }
            return Ordenes;
        }

        public List<Orden> ObtenerOrdenesCompra()
        {
            registros.Clear();
            List<Orden> ordenes = new List<Orden>();

            registros = Consultar("ConsultarOrdenesCompra");

            foreach (DataRow registro in registros.Rows)
            {
                Orden orden = new Orden();
                orden.Id = Convert.ToInt32(registro["Id"]);
                orden.NoOrden = Convert.ToInt32(registro["NoOrden"]);
                orden.Eliminado = Convert.ToBoolean(registro["Eliminado"]);
                orden.Cliente.Id = Convert.ToInt32(registro["IdCliente"]);
                orden.Productos = ObtenerOrdenesProductoXOrden(orden.Id);
            }
            return ordenes;
        }

        public List<Orden> ObtenerOrdenesCompraActivas()
        {
            registros.Clear();
            List<Orden> ordenes = new List<Orden>();

            registros = Consultar("ConsultarOrdenesCompraActivas");

            foreach (DataRow registro in registros.Rows)
            {
                Orden orden = new Orden();
                orden.Id = Convert.ToInt32(registro["Id"]);
                orden.NoOrden = Convert.ToInt32(registro["NoOrden"]);
                orden.Eliminado = Convert.ToBoolean(registro["Eliminado"]);
                orden.Cliente.Id = Convert.ToInt32(registro["IdCliente"]);
                orden.Productos = ObtenerOrdenesProductoXOrden(orden.Id);
                ordenes.Add(orden);
            }


            return ordenes;
        }

        public List<Orden> ObtenerOrdenesCompraXCliente( Orden orden1)
        {
            registros.Clear();
            List<Orden> ordenes = new List<Orden>();

            Parametro IdCliente = new Parametro("@IdCliente", DbType.Int32, orden1.Cliente.Id);
            registros = Consultar("ConsultarOrdenesCompraXCliente",IdCliente);

            foreach (DataRow registro in registros.Rows)
            {
                Orden orden = new Orden();
                orden.Id = Convert.ToInt32(registro["Id"]);
                orden.NoOrden = Convert.ToInt32(registro["NoOrden"]);
                orden.Eliminado = Convert.ToBoolean(registro["Eliminado"]);
                orden.Cliente.Id = Convert.ToInt32(registro["IdCliente"]);
                orden.Productos = ObtenerOrdenesProductoXOrden(orden.Id);
                ordenes.Add(orden);
            }


            return ordenes;
        }

        public Orden ObtenerOrden( Orden orden)
        {
            Parametro ParametroOrden = new Parametro("@Id", DbType.Int16, orden.Id);
            registros = Consultar("ConsultarOrdenCompra", ParametroOrden);
            
            if (registros.Rows.Count > 0)
            {
                orden.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                orden.NoOrden = Convert.ToInt32( registros.Rows[0]["NoOrden"]);
                orden.Cliente.Id = Convert.ToInt32(registros.Rows[0]["IdCliente"]);
                orden.Eliminado = Convert.ToBoolean(registros.Rows[0]["Eliminado"]);
                orden.Productos = ObtenerOrdenesProductoXOrden(orden.Id);

            }
            return orden;
        }


        
    }
}
