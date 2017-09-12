using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Presentacion.master
{
    public partial class masteruno : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario userSesion = (Usuario)Session["usuario"];
                this.validarFormularios(userSesion);
            }
        }

        private void validarFormularios(Usuario objeto)
        {
            foreach (Formulario form in objeto.RolUsuario.Listaformularios)
            {
                Control aux = new Control();
                aux = FindControl(form.Nombre);
                aux.Visible = true;
            }
        }
    }
}