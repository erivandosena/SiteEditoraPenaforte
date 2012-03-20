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

public partial class AreaRestrita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("Administrador"))
        {
            Response.Redirect("/Adm/Default.aspx");
        }
        else
            if (User.IsInRole("Professor"))
            {
                Response.Redirect("/Professores/Default.aspx");
            }
            else
                if (User.IsInRole("Aluno"))
                {
                    Response.Redirect("/Alunos/Default.aspx");
                }
                else
                    if (User.Identity.IsAuthenticated == false)
                    {
                        Server.Transfer("Login.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
    }
}
