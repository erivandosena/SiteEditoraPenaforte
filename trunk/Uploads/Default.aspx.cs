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
using System.IO;

public partial class Uploads_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Área Restrita - Download";

        if (!IsPostBack)
        {
            ListaArquivos();
            ListaArquivosEscritor();
        }
    }

    private void ListaArquivos()
    {
        DirectoryInfo di = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Uploads\Arquivos\");
        FileInfo[] fi = di.GetFiles();
        BulletedList1.Items.Clear();

        foreach (FileInfo arquivo in fi)
        {
            if ((Roles.IsUserInRole("Administrador") == true)|(Roles.IsUserInRole("Professor") == true)|(Roles.IsUserInRole("Aluno") == true))
            {
                BulletedList1.Items.Add(arquivo.Name);
                if (BulletedList1.Items.Count > 0)
                {
                    Label1.Text = "Arquivos restritos para professores e alunos do portal IEP <br />";
                }
            }
        }
    }

    private void ListaArquivosEscritor()
    {
        DirectoryInfo di = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Uploads\ArquivosEscritor\");
        FileInfo[] fi = di.GetFiles();
        BulletedList2.Items.Clear();

        foreach (FileInfo arquivo in fi)
        {
            BulletedList2.Items.Add(arquivo.Name);
            if (BulletedList2.Items.Count > 0)
            {
                Label2.Text = "Arquivos exclusivos da página do escritor <br />";
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ListaArquivos();
        ListaArquivosEscritor();
    }

    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {
        if (BulletedList1.SelectedIndex != 0)
        {
            FileInfo arquivo = new FileInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Uploads\Arquivos\" + BulletedList1.Items[e.Index].Value);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + arquivo.Name);
            Response.AddHeader("Content-Length", arquivo.Length.ToString());
            Response.ContentType = arquivo.GetType().ToString();
            Response.WriteFile(arquivo.FullName);
            Response.End();
        }
    }

    protected void BulletedList2_Click(object sender, BulletedListEventArgs e)
    {
        if (BulletedList2.SelectedIndex != 0)
        {
            FileInfo arquivo = new FileInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Uploads\ArquivosEscritor\" + BulletedList2.Items[e.Index].Value);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + arquivo.Name);
            Response.AddHeader("Content-Length", arquivo.Length.ToString());
            Response.ContentType = arquivo.GetType().ToString();
            Response.WriteFile(arquivo.FullName);
            Response.End();
        }
    }

}
