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
using Npgsql;
using Rwd.BLL;

public partial class Infos : System.Web.UI.Page
{
    public string MetaDescription
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "description";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    public string MetaKeywords
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "keywords";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDadosWebsite();
        CarregaNoticias();
    }

    private void CarregaNoticias()
    {
        LblMsg.Text = string.Empty;
        using (DataSet ds = BusinessLogic.SelecionaNoticiasPublicadasDs())
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                GVNoticias.DataSource = ds;
                GVNoticias.DataBind();
            }
            else
            {
                LblMsg.Text = "Ainda não existem publicações.";
            }
        }
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["sit_titulo"].ToString() + " - Informativos";

                    //Adiciona description Meta control 
                    MetaDescription = Page.Title + " - " + dr["sit_slogan"].ToString();

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaNoticiasNomesDs())
                    {
                        MetaKeywords = DatasetToString(ds);
                    }
                }
            }
        }
    }

    private string DatasetToString(DataSet ds)
    {
        Int32 i = 0;
        String str = "rwd";
        using (DataTable dt = ds.Tables[0])
        {
            while (i < dt.Rows.Count)
            {
                str += ", " + dt.Rows[i][0].ToString();
                i++;
            }
            return (str);
        }
    }

    protected void GVNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVNoticias.PageIndex = e.NewPageIndex;
        CarregaNoticias();
    }
}
