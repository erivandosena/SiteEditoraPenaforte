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

public partial class Alunos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Rwd.PageModule.Chat.AddMessage("Aula", User.Identity.Name, "Entrou");
        Response.Redirect("~/Usuarios/bp.aspx?Channel=Aula&User=(Aluno)" + User.Identity.Name);
    }
}
