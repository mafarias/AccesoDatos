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
    public partial class AUsuarios : System.Web.UI.Page
    {
        NegocioUsuarios Negocio = new NegocioUsuarios();

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
            grdRegistros.DataSource = Negocio.ObtenerUsuariosActivos();
            grdRegistros.DataBind();

            if (ddlUsuarios.Items.Count == 0)
            {
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = Negocio.ObtenerUsuariosActivos();
                ddlUsuarios.DataSource = usuarios;
                ddlUsuarios.DataTextField = "Nombre";
                ddlUsuarios.DataValueField = "Id";
                ddlUsuarios.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Nombre = txtNombre.Text;
            usuario.Identificacion = Convert.ToInt32(txtIdentificacion.Text);
            usuario.Telefono = Convert.ToInt32(txtTelefono.Text);
            usuario.Direccion = txtDireccion.Text;
            usuario.Eliminado = false;

            usuario.Id = Negocio.CrearUsuario(usuario);

            if (usuario.Id > -1)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " Se creo correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " NO se creo correctamente";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Id = Convert.ToInt32(txtId.Text);
            usuario.Nombre = txtNombre.Text;
            usuario.Identificacion = Convert.ToInt32(txtIdentificacion.Text);
            usuario.Telefono = Convert.ToInt32(txtTelefono.Text);
            usuario.Direccion = txtDireccion.Text;
            usuario.Eliminado = ddlEliminado.SelectedValue == "SI" ? true : false;

            bool res = Negocio.ModificarUsuario(usuario);

            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " Se Modifico correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " NO se Modifico correctamente";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Id = Convert.ToInt32(txtId.Text);
            usuario.Eliminado = true;

            bool res = Negocio.EliminarUsuario(usuario);
            if (res)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " Se Elimino correctamente";
                this.LimpiarCampos();

            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario:" + usuario.Nombre + " NO se Elimino correctamente";
            }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Id = Convert.ToInt32(ddlUsuarios.SelectedValue);
            usuario = Negocio.ObtenerUsuario(usuario);


            txtId.Text = usuario.Id.ToString();
            txtIdentificacion.Text = usuario.Identificacion.ToString();
            txtNombre.Text = usuario.Nombre;
            ddlEliminado.SelectedValue = usuario.Eliminado ? "SI" : "NO";
            txtTelefono.Text = usuario.Telefono.ToString();
            txtDireccion.Text = usuario.Direccion;
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
                Usuario usuario = new Usuario();
                if(ddlUsuarios.SelectedValue=="")
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                }
                else
                {
                    usuario.Id = Convert.ToInt32(ddlUsuarios.SelectedValue);
                    txtId.Text = usuario.Id.ToString();
                    txtIdentificacion.Text = usuario.Identificacion.ToString();
                    txtNombre.Text = usuario.Nombre;
                    txtEliminado.Text = usuario.Eliminado.ToString();
                    txtTelefono.Text = usuario.Telefono.ToString();
                    txtDireccion.Text = usuario.Direccion;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = true;
                }
                
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

        protected void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEliminado.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;

        }
    }
}