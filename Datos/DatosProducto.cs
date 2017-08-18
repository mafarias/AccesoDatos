using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Dominio;
using System.Data;

namespace Datos
{
    public class DatosProducto : DAL

    {
        List<Producto> Productos = new List<Producto>();

        DataTable registros = new DataTable();


        public DatosProducto () : base(){}

        public List<Producto> ObtenerProductos()
        {
            Productos.Clear();
            registros = Consultar("ConsultarProductos");

            foreach (DataRow registro in registros.Rows)
            {
                Producto producto = new Producto();

                producto.Id = Convert.ToInt32(registro["Id"]);
                producto.Nombre = registro["Producto"].ToString();
                producto.Cliente = registro["Cliente"].ToString();
                Convert.ToBoolean( registro["Eliminado"].ToString());
                Productos.Add(producto);
            }
            return Productos;
        }


        public List<Producto> ObtenerProductosActivos()
        {
            Productos.Clear();
            registros = Consultar("ConsultarProductosActivos");

            foreach (DataRow registro in registros.Rows)
            {
                Producto producto = new Producto();

                producto.Id = Convert.ToInt32(registro["Id"]);
                producto.Nombre = registro["Producto"].ToString();
                producto.Cliente = registro["Cliente"].ToString();
                producto.Eliminado = Convert.ToBoolean( registro["Eliminado"]);
                Productos.Add(producto);
            }
            return Productos;
        }

        public Producto ConsultarProducto(Producto producto)
        {
            Productos.Clear();
            Parametro ParametroId = new Parametro("@Id", DbType.Int32, producto.Id);
            registros = Consultar("ConsultarProducto", ParametroId);

            if(registros.Rows.Count >0)
            {
                producto.Id = Convert.ToInt32(registros.Rows[0]["Id"]);
                producto.Nombre = registros.Rows[0]["Producto"].ToString();
                producto.Cliente = registros.Rows[0]["Cliente"].ToString();
                producto.Eliminado = Convert.ToBoolean(registros.Rows[0]["Eliminado"]);
            }

            return producto;
        }

        public bool ModificarProducto (Producto producto)
        {
            Parametro Id = new Parametro("@Id",DbType.Int32,producto.Id);
            Parametro Nombre = new Parametro("@Producto",DbType.String,producto.Nombre);
            Parametro Cliente = new Parametro("@Cliente",DbType.String,producto.Cliente);
            Parametro Eliminado = new Parametro("@Eliminado",DbType.Boolean,producto.Eliminado);

             bool res;

            res = Actualizar("ModificarProducto", Id,Nombre,Cliente,Eliminado);

            return res;
        }

        public int CrearProducto(Producto producto)
        {
            Parametro Nombre = new Parametro("@Producto",DbType.String,producto.Nombre);
            Parametro Cliente = new Parametro("@Cliente",DbType.String,producto.Cliente);
            Parametro Eliminado = new Parametro("@Eliminado",DbType.Boolean,producto.Eliminado);

            producto.Id = Convert.ToInt32(Insertar("CrearProducto",Nombre,Cliente,Eliminado));

            return producto.Id;
        }

        public bool EliminarProducto(Producto producto)
        {
             Parametro Id = new Parametro("@Id",DbType.Int32,producto.Id); 
             Parametro Eliminado = new Parametro("@Eliminado",DbType.Boolean,producto.Eliminado);
            bool res;
            res = Actualizar("EliminarProducto",Id,Eliminado);
            return res;

        }


        
    }
}
