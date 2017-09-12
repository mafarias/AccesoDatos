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
            
            NegocioUsuarios negocio = new NegocioUsuarios();
            usuario = negocio.TraerLogin(usuario);
            Session["usuario"] = usuario;
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + usuario.RolUsuario.Mensaje + "');</script>");
            Response.Redirect(usuario.RolUsuario.urlInicio);
            


        }
    }
}