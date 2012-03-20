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
using Rwd.PageModule;
using Rwd.BLL;
using Npgsql;

public partial class bp : System.Web.UI.Page
{
    public Object dir = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Channel"] == null || Session["ChatChannel"] == null)
        {
            Rwd.PageModule.Chat.AddMessage(null, "Aviso", "Você não está mais na sala!");
            LinkButton1.Text = "Entrar";
        }
        else
        {
            LinkButton1.Text = "Sair";
        }
        
        if (Page.IsPostBack == false)
        {
            if (Request.Params["Channel"] != null)
                Session["ChatChannel"] = Request.Params["Channel"].ToString();
            else
                Session["ChatChannel"] = "1";
        }

        if (Cache["profemail"] != null)
        {
            if (string.IsNullOrEmpty(Label1.Text))
            {
                CarregaProfessor();
            }
        }
    }

    protected void BT_Send_Click(object sender, EventArgs e)
    {
        string sChannel = "";
        string sUser = "";

        if (Request.Params["Channel"] != null)
            sChannel = Request.Params["Channel"].ToString();
        else
            sChannel = "1";

        if (Request.Params["User"] != null)
            sUser = Request.Params["User"].ToString();
        else
        {
            Random pRan = new Random();
            int iNum = pRan.Next(9);
            sUser = "Annonymouse" + iNum;
        }

        if (TB_ToSend.Text.Length > 0)
        {
            Chat.AddMessage(sChannel,
                sUser,
                TB_ToSend.Text);

            TB_ToSend.Text = "";
        }
    }

    public string GetChatPage()
    {
        return ("TheChatScreenWin.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (LinkButton1.Text == "Sair")
        {
            Session["Channel"] = null;
            Session["ChatChannel"] = null;
            Rwd.PageModule.Chat.AddMessage("Aula", User.Identity.Name, "Saiu");
        }
        else
        {
            Rwd.PageModule.Chat.AddMessage("Aula", User.Identity.Name, "Entrou");
            Response.Redirect("~/Usuarios/bp.aspx?Channel=Aula&User=" + User.Identity.Name);
        }
    }

    private void CarregaProfessor()
    {
        Image1.Visible = true;
        Image1.ImageUrl = Cache["proffoto"].ToString();
        Label1.Text = Cache["profnome"] as string + " " +
        "<a href='mailto:" + Cache["profemail"].ToString() + "'>E-mail</a><br />" +
        "<a href='skype:" + Cache["profskype"].ToString() + "?call'>Skype</a><br />" +
        "<a href='" + Cache["proftwitter"].ToString() + "' target='_brack'>Twitter</a><br />" +
        "<a href='" + Cache["proforkut"].ToString() + "' target='_brack'>Orkut</a><br />" +
        "<a href='" + Cache["profyoutube"].ToString() + "' target='_brack'>YouTube</a><br />";
    }

}
