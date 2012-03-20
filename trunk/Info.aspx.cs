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

public partial class Info : System.Web.UI.Page
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

    string NoticiaCod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["n"];

        if (string.IsNullOrEmpty(NoticiaCod))
        {
            Response.Redirect("Default.aspx");
        }
        else
            if (!IsPostBack)
            {
                CarregaDadosWebsite();
                AtualizaContador();
                CarregaNoticia();
            }
    }

    private void CarregaNoticia()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasDr(int.Parse(NoticiaCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = Page.Title + " - " + dr["not_titulo"].ToString();
                    //Adiciona description Meta control 
                    MetaDescription = Page.Title + string.Format(" em {0:D}", dr["not_data"]);
                   
                    Lbl_Titulo.Text = dr["not_titulo"].ToString();
                    Lbl_DatPub.Text = string.Format("Publicado, {0:D}", dr["not_data"]);
                    Lbl_DatAtualizacao.Text = string.Format("Atualizado: {0:d}", dr["not_dataalteracao"]);
                    Lbl_Noticia.Text = dr["not_noticia"].ToString();
                    Lbl_Visualizacao.Text = "Número de exibições: " + dr["not_visualizacao"].ToString();
                }
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
                    Page.Header.Title = dr["sit_titulo"].ToString();

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

    protected void AtualizaContador()
    {
        if (!string.IsNullOrEmpty(NoticiaCod))
        {
            BusinessLogic.AtualizaNoticiasVisualizao(int.Parse(NoticiaCod));
        }

    }
}
