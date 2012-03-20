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

public partial class WUC_PublicidadeLateral : System.Web.UI.UserControl
{
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
                    Label1.Text = dr["sit_banner2"].ToString();
                }
            }
        }
    }
}
