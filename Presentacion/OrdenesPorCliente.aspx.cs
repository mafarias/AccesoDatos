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
    public partial class OrdenesPorCliente : System.Web.UI.Page
    {
        NegocioOrdenCompra Negocio = new NegocioOrdenCompra();
        NegocioCliente negocioClientes = new NegocioCliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.LLenarListas();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Orden> ordenes = new List<Orden>();
            ordenes.Clear();
            Orden orden = new Orden();
            orden.Cliente.Id = Convert.ToInt32( ddlClientes.SelectedValue);
            ordenes = Negocio.ObtenerOrdensXCliente(orden);

            grdRegistros.DataSource = ordenes;
            grdRegistros.DataBind();
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



        }
    }
}