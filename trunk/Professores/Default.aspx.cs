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

public partial class Professores_Default : System.Web.UI.Page
{
    string EmailProfessor = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MembershipUser user;
        user = Membership.GetUser();
        EmailProfessor = user.Email;

        CarregaProfessor();
        Rwd.PageModule.Chat.AddMessage("Aula", Cache["profnome"] as string, "Entrou");
        Response.Redirect("~/Usuarios/bp.aspx?Channel=Aula&User=" + Cache["profnome"] as string);
    }

    private void CarregaProfessor()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaProfessoresDr(-1, null, EmailProfessor))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cache.Insert("profemail", dr["pro_email"].ToString());
                    Cache.Insert("profnome", dr["pro_nome"].ToString());
                    Cache.Insert("profsobre", dr["pro_sobre"].ToString());
                    Cache.Insert("profskype", dr["pro_skype"].ToString());
                    Cache.Insert("proftwitter", dr["pro_twitter"].ToString());
                    Cache.Insert("proforkut", dr["pro_orkut"].ToString());
                    Cache.Insert("profyoutube", dr["pro_youtube"].ToString());

                    Cache.Insert("proffoto", "~/HandlerImgs.ashx?Tamanho=M&imgpro=" + dr["pro_cod"].ToString());
                }
            }
        }
    }

}
