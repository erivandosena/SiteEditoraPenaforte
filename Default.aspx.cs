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

public partial class _Default : System.Web.UI.Page
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
                    Page.Header.Title = dr["sit_titulo"].ToString() + " &bull; " + dr["sit_slogan"].ToString() + " - Principal";

                    //Adiciona description Meta control 
                    MetaDescription = dr["sit_titulo"].ToString() + ", " + dr["sit_slogan"].ToString() + " " + dr["sit_telefone"].ToString() + " " + dr["sit_cidade"].ToString() + " " + dr["sit_estado"].ToString();

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaPaginasNomesDs())
                    {
                        using (DataSet ds2 = BusinessLogic.SelecionaObrasNomesDs())
                        {
                            using (DataSet ds3 = BusinessLogic.SelecionaProfessoresNomesDs())
                            {
                                using (DataSet ds4 = BusinessLogic.SelecionaNoticiasNomesDs())
                                {
                                    MetaKeywords = DatasetToString(ds, ds2, ds3, ds4);
                                }
                            }
                        }
                    }
                    
                    
                    //Banner topo pagina inicial
                    LabelBanner.Text = dr["sit_mapa"].ToString();

                    //Slogan topo pagina inicial
                    LabelSlogan.Text = dr["sit_slogan"].ToString();

                    LabelPublicidade.Text = dr["sit_banner1"].ToString();
                }
            }
        }
    }

    private string DatasetToString(DataSet ds, DataSet ds2, DataSet ds3, DataSet ds4)
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
            using (DataTable dt2 = ds2.Tables[0])
            {
                while (i < dt2.Rows.Count)
                {
                    str += ", " + dt2.Rows[i][0].ToString();
                    i++;
                }
            }
            i = 0;
            using (DataTable dt4 = ds4.Tables[0])
            {
                while (i < dt4.Rows.Count)
                {
                    str += ", " + dt4.Rows[i][0].ToString();
                    i++;
                }
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
