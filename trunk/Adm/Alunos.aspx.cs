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

public partial class Adm_Alunos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina paginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        CarregaAlunos();
    }

    protected void CarregaAlunos()
    {
        string[] usersInRole = Roles.GetUsersInRole("Aluno");
        MembershipUserCollection users = new MembershipUserCollection();

        foreach (string userName in usersInRole)
        {
            users.Add(Membership.GetUser(userName));
        }

        GridView1.DataSource = users;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        CarregaAlunos();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Usuarios/CadUsuario.aspx");
    }
}
