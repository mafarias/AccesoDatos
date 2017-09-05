using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class Ordenes : System.Web.UI.Page
    {
        NegocioOrdenCompra Negocio = new NegocioOrdenCompra();
        NegocioProductos negocioProductos = new NegocioProductos();
        NegocioCliente negocioClientes = new NegocioCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnGuardar.Enabled = true;
                ddlAccion.SelectedItem.Value = "1";
                ddlEliminado.SelectedValue = "SI";
                this.LLenarListas();
            }
        }

        protected void LLenarListas()
        {
            List<Cliente> Clientes = new List<Cliente>();
            if (ddlClientes.Items.Count == 0)
            {
                Clientes = negocioClientes.ObtenerClientesActivos();
                ddlClientes.DataSource = Clientes;
                ddlClientes.DataTextField = "Nombre";
                ddlClientes.DataValueField = "Id";
                ddlClientes.DataBind();
            }


            List<Producto> productos = new List<Producto>();
            if (LsbProductos.Items.Count == 0)
            {
                productos = negocioProductos.ObtenerProductosActivos();

                LsbProductos.DataSource = productos;
                LsbProductos.DataTextField = "Nombre";
                LsbProductos.DataValueField = "Id";
                LsbProductos.DataBind();
            }

            List<Orden> ordenes = new List<Orden>();

            ordenes = Negocio.ObtenerOrdensActivos();
            grdRegistros.DataSource = ordenes;
            grdRegistros.DataBind();

            ddlOrdenes.DataSource = ordenes;
            ddlOrdenes.DataTextField = "NoOrden";
            ddlOrdenes.DataValueField = "Id";
            ddlOrdenes.DataBind();
        }

        protected void ddlAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(ddlAccion.SelectedItem.Value);
            if (aux == 1)
            {
                ddlEliminado.SelectedValue = "NO";
                ddlEliminado.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                ddlOrdenes.Enabled = false;

            }
            if (aux == 2)
            {
                txtNoOrden.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = true;
            }
            if (aux == 3)
            {
                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
                txtNoOrden.Enabled = false;
                ddlClientes.Enabled = false;
                LsbProductos.Enabled = false;
                LsbProductos.Visible = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden();
            orden.NoOrden = Convert.ToInt32(txtNoOrden.Text);
            orden.Cliente.Id = Convert.ToInt32(ddlClientes.SelectedValue);
            orden.Eliminado = ddlEliminado.SelectedValue == "SI" ? true : false;
            List<OrdenCompra> ordenes = new List<OrdenCompra>();
            foreach (ListItem li in LsbProductos.Items)
            {
                OrdenCompra ordenco = new OrdenCompra();
                if (li.Selected == true)
                {
                    ordenco.IdOrden = orden.NoOrden;
                    ordenco.producto.Id = Convert.ToInt32(li.Value);
                    ordenes.Add(ordenco);
                }

            }
            orden.Productos = ordenes;

            orden.Id = Negocio.CrearOrden(orden);

            if (orden.Id > -1)
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " Se creo correctamente";
                VaciarCampos();
            }
            else
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " NO se creo correctamente";
            }


        }
        protected void VaciarCampos()
        {
            txtID.Text = string.Empty;
            txtNoOrden.Text = string.Empty;
            ddlClientes.SelectedIndex = 0;
            ddlEliminado.SelectedValue = "NO";
            foreach (ListItem li in LsbProductos.Items)
            {
                OrdenCompra ordenco = new OrdenCompra();
                if (li.Selected == true)
                {
                    li.Selected = false;
                }

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden();

            orden.Id = Convert.ToInt32( txtID.Text);
            orden.NoOrden = Convert.ToInt32(txtNoOrden.Text);
            orden.Cliente.Id = Convert.ToInt32(ddlClientes.SelectedValue);
            orden.Eliminado = ddlEliminado.SelectedValue == "SI"? true:false;
            List<OrdenCompra> ordenes = new List<OrdenCompra>();
            foreach(ListItem li in LsbProductos.Items)
            {
                OrdenCompra ordenco = new OrdenCompra();
                if (li.Selected== true)
                {
                    ordenco.IdOrden= orden.NoOrden;
                    ordenco.producto.Id = Convert.ToInt32(li.Value);
                    ordenes.Add(ordenco);
                }
                
            }
            orden.Productos = ordenes;

            bool res = Negocio.ModificarOrden(orden);

            if (res)
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " Se Modifico correctamente";
                VaciarCampos();
            }
            else
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " NO se Modifico correctamente";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden();
            orden.Id = Convert.ToInt32(txtID.Text);
            orden.NoOrden = Convert.ToInt32(txtNoOrden.Text);
            orden.Cliente.Id = Convert.ToInt32(ddlClientes.SelectedValue);
            orden.Eliminado = ddlEliminado.SelectedValue == "SI" ? true : false;

            bool res = Negocio.ModificarOrden(orden);

            if (res)
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " Se Elimino correctamente";
                VaciarCampos();
            }
            else
            {
                lblMensaje.Text = "La orden :" + orden.NoOrden + " NO se Elimino correctamente";
            }
        }

        protected void ddlOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Orden orden = new Orden();
            orden.Id = Convert.ToInt32(ddlOrdenes.SelectedValue);
            orden = Negocio.ObtenerOrden(orden);
            txtID.Text = orden.Id.ToString();
            txtNoOrden.Text = orden.NoOrden.ToString();
            ddlEliminado.SelectedValue = orden.Eliminado ? "SI" : "NO";
            ddlClientes.SelectedValue = orden.Cliente.Id.ToString();
            foreach (ListItem li in LsbProductos.Items)
            {
                foreach (OrdenCompra ordence in orden.Productos)
                {
                    if (li.Value == ordence.producto.Id.ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

        }
    }
}