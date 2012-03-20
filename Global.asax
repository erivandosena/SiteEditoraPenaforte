<%@ Application Language="C#" %>
<%@ Import Namespace="Rwd.Util" %>

<script RunAt="server">
   
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

        // 3
        //Application["UsuariosOnline"] = (Application["UsuariosOnline"] == null ? 0 : int.Parse(Application["UsuariosOnline"].ToString())) - 1;

        if (Application["UsuariosOnline"] == null)
            Application["UsuariosOnline"] = 0;
        else
            Application["UsuariosOnline"] = int.Parse(Application["UsuariosOnline"].ToString()) - 1;
                
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

        Exception ex = Server.GetLastError();
        EmailException(ex);
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        
        //1
        //Application["UsuariosOnline"] = (Application["UsuariosOnline"] == null ? 0 : int.Parse(Application["UsuariosOnline"].ToString())) + 1;

        
        
        if (Application["UsuariosOnline"] == null)
            Application["UsuariosOnline"] = 1;
        else
            Application["UsuariosOnline"] = int.Parse(Application["UsuariosOnline"].ToString()) + 1;

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        
        //2
        //Application["UsuariosOnline"] = (Application["UsuariosOnline"] == null ? 0 : int.Parse(Application["UsuariosOnline"].ToString())) - 1;        

        Rwd.PageModule.Chat.AddMessage("Aula", User.Identity.Name, "Saiu");
        
        if (Application["UsuariosOnline"] == null)
            Application["UsuariosOnline"] = 0;
        else
            Application["UsuariosOnline"] = int.Parse(Application["UsuariosOnline"].ToString()) - 1;

    }

    //Erros
    private void EmailException(Exception ex)
    {

        string Sistema = "";
        StringBuilder sb = new StringBuilder();
        StringBuilder sbTxtErro = new StringBuilder();
        sb.Append("<html><style>TABLE {font-size: 8pt; font-family: Arial, Verdana;}</style><body><table>");

        sb.Append(FormatHeader("Página do erro"));
        sb.Append(FormatError("Caminho", Request.Path));
        sb.Append(FormatError("URL", Request.RawUrl));
        sb.Append(FormatError("Última mensagem de erro", Server.GetLastError().Message));
        sb.Append(FormatError("Último Erro Fonte", Server.GetLastError().Source));
        sb.Append(FormatError("Data e Hora do erro", Convert.ToString(DateTime.Now)));

        sb.Append(FormatHeader("Exceção (Exception)"));
        Exception ErrorInfo = Server.GetLastError().GetBaseException();
        sb.Append(FormatError("Mensagem de erro", ErrorInfo.Message));
        sb.Append(FormatError("Erro Fonte", ErrorInfo.Source));
        sb.Append(FormatError("Erro Target Site", ErrorInfo.TargetSite.ToString()));

        sb.Append(FormatHeader("Sessão (Session)"));
        for (int i = 0; i < Context.Session.Count; i++)
        {
            sb.Append(FormatError(Context.Session.Keys[i], Context.Session[i].ToString()));
            if (Context.Session.Keys[i].ToString().ToLower() == "sistema")
            {
                Sistema = Context.Session[i].ToString();
            }
        }

        sb.Append(FormatHeader("Consulta String (Query String)"));
        for (int i = 0; i < Context.Request.QueryString.Count; i++)
        {
            sb.Append(FormatError(Context.Request.QueryString.Keys[i], Context.Request.QueryString[i]));
            sbTxtErro.Append(Context.Request.QueryString.Keys[i] + ": " + Context.Request.QueryString[i] + "  ");
        }

        sb.Append(FormatHeader("Post Form"));
        for (int i = 0; i < Context.Request.Form.Count; i++)
        {
            if (Context.Request.Form.Keys[i].ToString().ToUpper() != "__LASTFOCUS" &&
                Context.Request.Form.Keys[i].ToString().ToUpper() != "__EVENTTARGET" &&
                Context.Request.Form.Keys[i].ToString().ToUpper() != "__EVENTARGUMENT" &&
                Context.Request.Form.Keys[i].ToString().ToUpper() != "__VIEWSTATE" &&
                Context.Request.Form.Keys[i].ToString().ToUpper() != "__EVENTVALIDATION")
            {
                sbTxtErro.Append(Context.Request.Form.Keys[i] + ": " + Context.Request.Form[i] + "  ");
            }

            sb.Append(FormatError(Context.Request.Form.Keys[i], Context.Request.Form[i]));
        }

        sb.Append(FormatHeader("Outros"));
        if (User.Identity.IsAuthenticated)
        {
            sb.Append(FormatError("User", User.Identity.Name));
        }
        sb.Append(FormatError("Exceção Stack Trace", Server.GetLastError().StackTrace));

        sb.Append(FormatHeader("Server Variables"));
        for (int i = 0; i < Context.Request.ServerVariables.Count; i++)
        {
            sb.Append(FormatError(Context.Request.ServerVariables.Keys[i], Context.Request.ServerVariables[i]));
        }
        sb.Append("</table><p align=center>Desenvolvido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></p></body></html>");


        string AdminEmail = ConfigurationManager.AppSettings["AdminEmail"];
        string SiteEmail = ConfigurationManager.AppSettings["SiteEmail"];

        Util.EnviaEmail(SiteEmail, AdminEmail, "Erro do site " + Request.Url.Authority, sb.ToString());
    }
    
    protected string FormatHeader(string var)
    {
        return "<tr bgcolor=red><td colspan=2><font color=white><strong>" + var + "</strong></font></td></tr>";
    }

    protected string FormatError(string key, string value)
    {
        return "<tr><td align=right><strong>" + key + ":</strong></td><td>" + value + "</td></tr>";
    }
       
</script>

