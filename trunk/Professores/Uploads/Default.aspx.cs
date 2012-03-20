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
        if (!IsPostBack)
        {
            ListaArquivos();
            RelacionaExclusao();
        }
    }

    private void ListaArquivos()
    {
        DirectoryInfo di = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Professores\Uploads\Arquivos\");
        FileInfo[] fi = di.GetFiles();
        BulletedList1.Items.Clear();

        foreach (FileInfo arquivo in fi)
        {
              BulletedList1.Items.Add(arquivo.Name);
        }
    }

    private void RelacionaExclusao()
    {
        RadioButtonList1.Items.Clear();
        DirectoryInfo di = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Professores\Uploads\Arquivos\");
        FileInfo[] fi = di.GetFiles();
        //  RadioButtonList1.Items.Add("(Escolha um arquivo)");
        foreach (FileInfo arquivo in fi)
            RadioButtonList1.Items.Add(arquivo.Name);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Se for selecionado algum item da lista
        if (RadioButtonList1.SelectedIndex > -1)
        {
            try
            {
                FileInfo arq = new FileInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Professores\Uploads\Arquivos\" + RadioButtonList1.SelectedValue);
                if (arq.Exists)
                {
                    arq.Delete();
                    ListaArquivos();
                    RelacionaExclusao();
                    Label1.Text = "Arquivo excluído com sucesso!";
                }
            }
            catch (Exception erro)
            {
                Label1.Text = "Erro ao excluir aquivo. <br />" + erro;
            }
        }
        else
        {
            Label1.Text = "Selecione o arquivo na lista!";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ListaArquivos();
        RelacionaExclusao();
    }

    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {
        if (BulletedList1.SelectedIndex != 0)
        {
            FileInfo arquivo = new FileInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Professores\Uploads\Arquivos\" + BulletedList1.Items[e.Index].Value);
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + arquivo.Name);
        Response.AddHeader("Content-Length", arquivo.Length.ToString());
        Response.ContentType = arquivo.GetType().ToString();
        Response.WriteFile(arquivo.FullName);
        Response.End();
        }
    }
}
