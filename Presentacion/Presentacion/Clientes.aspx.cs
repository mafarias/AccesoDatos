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
    public partial class Clientes : System.Web.UI.Page
    {
        NegocioCliente Negocio = new NegocioCliente();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LLenarLista();
            if (!IsPostBack)
            {
                ddlAccion.SelectedItem.Value = "1";
                btnGuardar.Enabled = true;
            }
        }

        protected void LLenarLista()
        {
            grdRegistros.DataSource = Negocio.ObtenerClientesActivos();
            grdRegistros.DataBind();

            if(ddlClientes.Items.Count==0)
            {
                List<Cliente> Clientes = new List<Cliente>();
                Clientes = Negocio.ObtenerClientesActivos();
                ddlClientes.DataSource = Clientes;
                ddlClientes.DataTextField = "Nombre";
                ddlClientes.DataValueField = "Id";
                ddlClientes.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Nit = Convert.ToInt32( txtNit.Text);
            cliente.telefono = Convert.ToInt32(txtTelefono.Text);
            cliente.Direccion = txtDireccion.Text;
            cliente.Eliminado = false;
            cliente.Id = Negocio.CrearCliente(cliente);

            if (cliente.Id > -1)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El Cliente:" + cliente.Nombre + " Se creo correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El cliente:" + cliente.Nombre + " NO se creo correctamente";
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Id = Convert.ToInt32( txtId.Text);
            cliente.Nombre = txtNombre.Text;
            cliente.Nit = Convert.ToInt32(txtNit.Text);
            cliente.telefono = Convert.ToInt32(txtTelefono.Text);
            cliente.Direccion = txtDireccion.Text;
            cliente.Eliminado = ddlEliminado.SelectedValue == "SI" ? true : false;

            bool res  = Negocio.ActualizarCliente(cliente);

            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El Cliente:" + cliente.Nombre + " Se Modifico correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El cliente:" + cliente.Nombre + " NO se Modifico correctamente";
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Id=Convert.ToInt32( txtId.Text);
            cliente.Eliminado= true;
             
            bool res = Negocio.EliminarCliente(cliente);
            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El Cliente:" + cliente.Nombre + " Se Modifico correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El cliente:" + cliente.Nombre + " NO se Modifico correctamente";
            }
        }

        protected void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNit.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEliminado.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            
        }

        protected void ddlAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(ddlAccion.SelectedItem.Value);
            if (aux == 1)
            {
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                txtEliminado.Enabled = false;
                LimpiarCampos();
            }
            if (aux == 2)
            {
                Cliente cliente = new Cliente();
                cliente.Id =Convert.ToInt32( ddlClientes.SelectedValue);
                txtId.Text = cliente.Id.ToString();
                txtNit.Text = cliente.Nit.ToString();
                txtNombre.Text = cliente.Nombre;
                txtEliminado.Text = cliente.Eliminado.ToString();
                txtTelefono.Text = cliente.telefono.ToString();
                txtDireccion.Text = cliente.Direccion;

                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = true;
                LimpiarCampos();
            }
            if (aux == 3)
            {
                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
                txtNombre.Enabled = false;
                btnEliminar.Enabled = true;
                LimpiarCampos();
            }
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Id = Convert.ToInt32(ddlClientes.SelectedValue);
            cliente = Negocio.ObtenerCliente(cliente);


            txtId.Text = cliente.Id.ToString();
            txtNit.Text = cliente.Nit.ToString();
            txtNombre.Text = cliente.Nombre;
            ddlEliminado.SelectedValue = cliente.Eliminado ? "SI" : "NO";
            txtTelefono.Text = cliente.telefono.ToString();
            txtDireccion.Text = cliente.Direccion;

        }

        


    }
}