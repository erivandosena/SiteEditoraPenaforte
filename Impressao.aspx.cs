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

public partial class Impressão : System.Web.UI.Page
{
    string NoticiaCod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["n"];

        if (string.IsNullOrEmpty(NoticiaCod))
        {
            Response.Redirect("Default.aspx");
        }
        else

        CarregaNoticia();
    }

    private void CarregaNoticia()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasDr(int.Parse(NoticiaCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Title = "Impressão - " + dr["not_titulo"].ToString();
                    LabelTitulo.Text = dr["not_titulo"].ToString();
                    LabelPublicado.Text = string.Format("Publicado, {0:D}", dr["not_data"]);
                    LabelAtualizado.Text = string.Format("Atualizado: {0:d}", dr["not_dataalteracao"]);
                    LabelTexto.Text = dr["not_noticia"].ToString();
                }
            }
        }
    }

}
