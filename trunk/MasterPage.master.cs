using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Npgsql;
using Rwd.BLL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsuOnLine.Text = "Pessoas on-line: <strong>" + Application["UsuariosOnline"].ToString() + "</strong>";
        CarregaDadosWebsite();
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ImageLogo.ImageUrl = "/HandlerImgs.ashx?imgsit=" + dr["sit_cod"].ToString();
                    ImageLogo.AlternateText = dr["sit_titulo"].ToString();
                    LabelCopyright.Text = DateTime.Now.Year + " " + dr["sit_titulo"].ToString();

                    if (Page.Title == "Untitled Page")
                    {
                        if (Page.User.IsInRole("Administrador"))
                        {
                            Page.Title = dr["sit_titulo"].ToString() + " - Administrativo";
                        }
                        else
                            if (Page.User.IsInRole("Professor") || Page.User.IsInRole("Aluno"))
                            {
                                Page.Title = dr["sit_titulo"].ToString() + " - Área Restrita";
                            }
                    }

                    byte[] logo = dr["sit_logo"] as byte[];
                    if (logo == null)
                    {
                        ImageLogo.Visible = false;
                    }
                }
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Uploads/Default.aspx");
    }
}
