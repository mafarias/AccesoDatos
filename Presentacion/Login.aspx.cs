using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Usuario usuario = new Usuario();
           usuario.UserName = Login1.UserName.ToString();
            usuario.PassWord = Login1.Password.ToString();
            Dictionary<string, Usuario> objeto = new Dictionary<string, Usuario>();
            string url = "Clientes.aspx";
            NegocioUsuarios negocio = new NegocioUsuarios();
            objeto = negocio.TraerLogin(usuario);
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + objeto.Keys.ToString() + "');window.location=\"" + url + "\"</script>");


        }
    }
}