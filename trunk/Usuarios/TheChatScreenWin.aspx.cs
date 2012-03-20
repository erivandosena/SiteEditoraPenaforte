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

public partial class TheChatScreenWin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sDealer = "";
        if (Session["ChatChannel"] != null)
            sDealer = Session["ChatChannel"].ToString();

        Response.Write("<meta http-equiv=\"Refresh\"content=\"4\">");
        Response.Write(Chat.GetAllMessages(sDealer));
    }
}
