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

public partial class Conteudo : System.Web.UI.Page
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

    string Pagina = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Pagina = Request.QueryString["pag"];

        if (string.IsNullOrEmpty(Pagina))
        {
            Response.Redirect("Default.aspx");
        }
        else

            CarregaDadosWebsite();
        CarregaConteudo();

    }

    private void CarregaConteudo()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaPaginasDr(int.Parse(Pagina), null, null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = Page.Title + " - "+ dr["pag_nome"].ToString();
                    //Adiciona description Meta control 
                    MetaDescription = Page.Title + ", " + dr["pag_descricao"].ToString();
                   
                    LabelPagina.Text = dr["pag_descricao"].ToString();
                    Label1.Text = dr["pag_conteudo"].ToString();
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
                    using (DataSet ds = BusinessLogic.SelecionaPaginasNomesDs())
                    {
                            using (DataSet ds3 = BusinessLogic.SelecionaProfessoresNomesDs())
                            {

                                    MetaKeywords = DatasetToString(ds, ds3);

                            }
                    }

                }
            }
        }
    }

    private string DatasetToString(DataSet ds, DataSet ds3)
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
            i = 0;
            using (DataTable dt3 = ds3.Tables[0])
            {
                while (i < dt3.Rows.Count)
                {
                    str += ", " + dt3.Rows[i][0].ToString();
                    i++;
                }
            }
            return (str);
        }
    }
}
