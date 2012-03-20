using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using Rwd.BLL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class ObrasAutor : System.Web.UI.Page
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
                    Page.Header.Title = dr["sit_titulo"].ToString() + " - Obras do Autor";

                    //Adiciona description Meta control 
                    MetaDescription = dr["sit_titulo"].ToString() + " - " + dr["sit_slogan"].ToString() + ", Obras literárias do autor";

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaObrasNomesDs())
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
}
