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
using Rwd.BLL;
using Npgsql;

public partial class Adm_Paginas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina paginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }
        if (!IsPostBack)
        {
            CarregaPaginas();
        }
    }

    protected void CarregaPaginas()
    {
        using (DataSet ds = BusinessLogic.SelecionaPaginasDs(0, "%", "%"))
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                LblMsg.Text = "Ainda não existem cadastros.";
            }
        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        CarregaPaginas();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadPaginas.aspx");
    }
}
