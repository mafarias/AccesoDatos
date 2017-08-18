using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class NegocioProductos
    {

        DatosProducto datos = new DatosProducto();

        List<Producto> Lista = new List<Producto>();

        Producto Producto = new Producto();

        public List<Producto> ObtenerProductos()
        {
            Lista.Clear();
            Lista = datos.ObtenerProductos();
            return Lista;
        }

        public List<Producto> ObtenerProductosActivos()
        {
            Lista.Clear();
            Lista = datos.ObtenerProductosActivos();
            return Lista;
        }


        public Producto ObtenerProducto(Producto Producto)
        {
            Producto = datos.ConsultarProducto(Producto);

            return Producto;
        }


        public int CrearProducto(Producto Producto)
        {
            Producto.Id = datos.CrearProducto(Producto);

            return Producto.Id;
        }

        public bool ModificarProducto(Producto producto)
        {
            bool res = datos.ModificarProducto(producto);
            return res;
        }
        
        public bool EliminarProducto(Producto Producto)
        {
            bool res = datos.EliminarProducto(Producto);
            return res;
        }
    }
}
