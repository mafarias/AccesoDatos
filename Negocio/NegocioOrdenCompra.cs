using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Dominio;

namespace Negocio
{
    public class NegocioOrdenCompra
    {
        DatosOrdenCompras datos = new DatosOrdenCompras();
        List<Orden> Lista = new List<Orden>();

        public List<Orden> ObtenerOrdens()
        {
            Lista.Clear();
            Lista = datos.ObtenerOrdenesCompra();
            return Lista;
        }

        public List<Orden> ObtenerOrdensActivos()
        {
            Lista.Clear();
            Lista = datos.ObtenerOrdenesCompraActivas();
            return Lista;
        }

        public List<Orden> ObtenerOrdensXCliente(Orden orden )
        {
            Lista.Clear();
            Lista = datos.ObtenerOrdenesCompraXCliente(orden);
            return Lista;
        }

        public bool ModificarOrden(Orden orden)
        {
            return datos.ActualizarOrden(orden);
        }

        public Orden ObtenerOrden(Orden Orden)
        {
            Orden = datos.ObtenerOrden(Orden);

            return Orden;
        }


        public int CrearOrden(Orden Orden)
        {
            Orden.Id = datos.CrearOrdenCompra(Orden);

            return Orden.Id;
        }
        
        //public bool EliminarOrden(Orden Orden)
        //{
        //    bool res = Orden);
        //    return res;
        //}

    }
}

