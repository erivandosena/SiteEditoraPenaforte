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

public partial class Adm_Usuarios_Senhas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox Txt = (TextBox)this.ChangePassword1.ChangePasswordTemplateContainer.FindControl("UserName");
        //Permissões de acesso conforme role p/ a pagina senhas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Txt.Enabled = false;
        }
    }
}
