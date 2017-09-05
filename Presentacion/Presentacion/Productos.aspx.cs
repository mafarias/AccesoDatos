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
    public partial class Productos : System.Web.UI.Page
    {
        NegocioProductos Negocio = new NegocioProductos();

        NegocioCliente negocioClientes = new NegocioCliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LLenarLista();
           if(!IsPostBack)
           {
               this.LLenarLista();
               int i =1;
               btnGuardar.Enabled = true;
               ddlEliminado.SelectedValue = "NO";
               ddlEliminado.SelectedItem.Value = i.ToString();
           }
        }

        protected void LLenarLista()
        {
            
            grdRegistros.DataSource = Negocio.ObtenerProductosActivos();
            grdRegistros.DataBind();

            List<Producto> productos = new List<Producto>();
            if(ddlproductos.Items.Count==0)
            {
                productos = Negocio.ObtenerProductosActivos();
                ddlproductos.DataSource = productos;
                ddlproductos.DataTextField = "Nombre";
                ddlproductos.DataValueField = "Id";
                ddlproductos.DataBind();
            }
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Nombre = txtNombre.Text;
            producto.Cliente = txtCliente.Text;
            producto.Eliminado = ddlEliminado.SelectedValue=="SI"?true :false;
            if(!producto.Eliminado)
            {
                producto.Id = Negocio.CrearProducto(producto);
                if (producto.Id > -1)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "El producto:" + producto.Nombre + " Se creo correctamente";
                    this.LimpiarCampos();

                }
                else
                {
                    lblMensaje.Visible = true;
                    
                    lblMensaje.Text = "El producto:" + producto.Nombre + " NO se creo correctamente";
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se pude crear un producto con estado ELIMINADO en  SI";
            }


            
        }
        

        private void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtEliminado.Text = string.Empty;

        }

        protected void ddlAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux =Convert.ToInt32( ddlAccion.SelectedItem.Value);
            if(aux==1)
            {
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                txtEliminado.Enabled = false;
                LimpiarCampos();
            }
            if (aux == 2)
            {
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = true;
                LimpiarCampos();
            }
            if (aux == 3)
            {
                ddlproductos.Enabled = false;

                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
                txtNombre.Enabled = false;
                txtCliente.Enabled = false;
                btnEliminar.Enabled = true;
                LimpiarCampos();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Id = Convert.ToInt32(txtId.Text);
            producto.Nombre = txtNombre.Text;
            producto.Cliente = txtCliente.Text;
            producto.Eliminado = ddlEliminado.SelectedValue == "SI" ? true : false;

            bool res =Negocio.ModificarProducto(producto);

            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El producto:" + producto.Nombre + " Sé modífico correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El producto:" + producto.Nombre + " NO sé modífico correctamente";
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Id = Convert.ToInt32(txtId.Text); ;
            producto.Nombre = txtNombre.Text;
            producto.Cliente = txtCliente.Text;
            producto.Eliminado = true;

            bool res = Negocio.EliminarProducto(producto);

            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El producto:" + producto.Nombre + " Sé elimino correctamente";
                this.LimpiarCampos();
                

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El producto:" + producto.Nombre + " NO sé elimino correctamente";
            }
            
        }

       

        protected void ddlproductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            Producto producto = new Producto();
            producto.Id = Convert.ToInt32(ddlproductos.SelectedValue);
            producto =  Negocio.ObtenerProducto(producto);

            txtId.Text = producto.Id.ToString();
            txtNombre.Text = producto.Nombre;
            txtCliente.Text = producto.Cliente;
            txtEliminado.Text = producto.Eliminado ? "SI" : "NO";
        }
        
        
    }
}