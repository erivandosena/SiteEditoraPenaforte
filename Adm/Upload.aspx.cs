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
using Rwd.Util;

public partial class Adm_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        if (!IsPostBack)
        {
            CarregaArquivos();
        }
    }

    private void CarregaArquivos()
    {
        RadioButtonList1.Items.Clear();
        DirectoryInfo di = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"\Uploads\Arquivos\");
        FileInfo[] fi = di.GetFiles();
        //  RadioButtonList1.Items.Add("(Escolha um arquivo)");
        foreach (FileInfo arquivo in fi)
            RadioButtonList1.Items.Add(arquivo.Name);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //inicializar as variáveis
            string arq = FileUpload1.PostedFile.FileName;
            string extensao = "";
            string extensaoX = "";
            double tamanho = 0;
            //tamanho maximo do upload em kb
            double permitido = 524288;
            //vamos utilizar uma variavel para controlar a aceitação das regras
            //se o valor padrão da variavel for alterado é porque alguma regra foi violada
            string erroregra = "0";
            // teste para verificar se foi submetido o arquivo
            if (FileUpload1.PostedFile != null)
            {
                //identificamos o tamanho do arquivo
                tamanho = Convert.ToDouble(FileUpload1.PostedFile.ContentLength) / 1024;
                //verificamos a extensão através dos últimos 4 caracteres
                extensao = arq.Substring(arq.Length - 4).ToLower();
                extensaoX = arq.Substring(arq.Length - 5).ToLower();
                //para saber o nome do arquivo utilizaremos a propriedade getfilename
                //passando a string arq
                string nomearq = Path.GetFileName(Util.Remove_Acento(arq));
                //diretorio onde será gravado o arquivo
                //faremos uma chamada ao método tira_acentos para
                //remover espaços e caracteres indesejados.
                //criar o diretório arquivos no mesmo local da aplicação
                string diretorio = this.Server.MapPath("~\\Uploads\\Arquivos\\" + Util.Remove_Acento(nomearq));
                // o tamanho acima do permitido - violação de regra
                if (tamanho > permitido)
                {
                    this.Label1.Text = "Tamanho máximo permitido é de " + permitido + " kb!";
                    erroregra = "1";
                }
                // extensão diferente de jpg, doc, pdf e gif - violação de regra
                if ((extensao != ".jpg" &&
                    extensao != ".txt" &&
                    extensao != ".rtf" &&
                    extensao != ".doc" &&
                    extensao != ".ppt" &&
                    extensao != ".pdf" &&
                    extensao != ".pps" &&
                    extensao != ".rar" &&
                    extensao != ".zip" &&
                    extensao != ".mpg" &&
                    extensao != ".flv" &&
                    extensao != ".avi" &&
                    extensao != ".wmv" &&
                    extensao != ".mp3" &&
                    extensao != ".mp4" &&
                    extensao != ".wma" &&
                    extensao != ".3gp" &&
                    extensao != ".png" &&
                    extensaoX != ".docx" &&
                    extensaoX != ".ppsx" &&
                    extensaoX != ".pptx"))
                {
                    this.Label1.Text = "Extensão inválida, só são permitidos:<br /> .jpg, .png, .txt, .rtf, .doc, .docx, .pdf, .pps, .ppsx, .ppt, .pptx, .zip, .rar, .mp3, .mp4, .wma, .wmv, .avi, .mpg, .flv, .3gp";
                    erroregra = "2";
                }
                if (erroregra == "0")
                {
                    try
                    {
                        // verifica se já existe o nome do arquivo submetido
                        if (!File.Exists(diretorio))
                        {
                            FileUpload1.PostedFile.SaveAs(diretorio);
                            CarregaArquivos();
                            this.Label1.Text = "Arquivo enviado com sucesso!";
                        }
                        else
                            this.Label1.Text = "Já existe um arquivo com esse nome!";
                    }
                          //caso ocorra alguma exceção será mostado no label
                    catch (UnauthorizedAccessException ex)
                    {
                        this.Label1.Text = "Erro no upload:" + ex.Message;
                    }
                }
            }
        }
        catch
        {
            this.Label1.Text = "Erro no upload";
        }
    }

    //método que remove acentos, espaços e carateres indesejados

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Se for selecionado algum item da lista
        if (RadioButtonList1.SelectedIndex > -1)
        {
            try
            {
                FileInfo arq = new FileInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"\Uploads\Arquivos\" + RadioButtonList1.SelectedValue);
                if (arq.Exists)
                {
                    arq.Delete();
                    CarregaArquivos();
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
        CarregaArquivos();
    }
}
