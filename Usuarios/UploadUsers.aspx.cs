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

public partial class Usuarios_UploadUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string diretorio = String.Empty;

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
                //para saber o nome do arquivo utilizaremos a propriedade getfilename
                //passando a string arq
                string nomearq = Path.GetFileName(Util.Remove_Acento(arq));
                //diretorio onde será gravado o arquivo
                //faremos uma chamada ao método tira_acentos para
                //remover espaços e caracteres indesejados.
                //criar o diretório arquivos no mesmo local da aplicação

                if (User.IsInRole("Professor"))
                {
                    diretorio = this.Server.MapPath("~\\Uploads\\Arquivos\\" + Util.Remove_Acento(nomearq));
                }
                if (User.IsInRole("Aluno"))
                {
                    diretorio = this.Server.MapPath("~\\Professores\\Uploads\\Arquivos\\" + Util.Remove_Acento(nomearq));
                }
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

}
