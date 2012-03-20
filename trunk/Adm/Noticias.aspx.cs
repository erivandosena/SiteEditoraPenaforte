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

public partial class Adm_Noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ o botão cadastrar nova
        if (Roles.IsUserInRole("Administrador") == true || Roles.IsUserInRole("Redator") == true)
        {
            Button1.Enabled = true;
        }
        else
        {
            Button1.Enabled = false;
        }

        if (!IsPostBack)
        {
            CarregaNoticias();
        }
    }

    protected void CarregaNoticias()
    {
        using (DataSet ds = BusinessLogic.SelecionaNoticiasDs(0, "%"))
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadNoticias.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        CarregaNoticias();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NOT_STATUS"));

            if (status == "N")
            {
                e.Row.Cells[3].Text = "<strong>Novo</strong>";
            }
            if (status == "A")
            {
                e.Row.Cells[3].Text = "<strong>Publicado</strong>";
            }
            if (status == "R")
            {
                e.Row.Cells[3].Text = "<strong>Suspenso</strong>";
            }

        }
    }
}
