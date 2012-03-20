using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Adm_Usuarios_CadUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadusuario.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }
    }
}
