using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for Util
/// </summary>
/// 

namespace Rwd.Util
{

    public class Util
    {
        //Valida controles
        public static string valida(string controle)
        {
            string mensagem = string.Empty;
            if (controle.Trim() == string.Empty)
            {
                mensagem = "<b>Campo requerido.</b>";
            }
            else
            {
                mensagem = string.Empty;
            }

            return mensagem;
        }
        //Remove acentos
        public static string RemoveAcento(string palavra)
        {
            string palavraSemAcento = null;
            string caracterComAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
            string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

            for (int i = 0; i < palavra.Length; i++)
            {
                if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                {
                    int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                    palavraSemAcento += caracterSemAcento.Substring(car, 1);
                }
                else
                {
                    palavraSemAcento += palavra.Substring(i, 1);
                }
            }

            return palavraSemAcento;
        }

        public static string Remove_Acento(string texto)
        {
            string comacentos = "!@#$%¨&*()-?:{}][äåáâàãäáâàãéêëèéêëèíîïìíîïìöóôòõöóôòõüúûüúûùçç ";
            string semacentos = "_________________aaaaaaaaaaaeeeeeeeeiiiiiiiioooooooooouuuuuuucc_";
            for (int i = 0; i < comacentos.Length; i++)
                texto = texto.Replace(comacentos[i].ToString(), semacentos[i].ToString()).Trim();
            return texto;
        }


        //Envio de e-mail
        public static void EnviaEmail(string De, string Para, string Assunto, string Mensagem)
        {
            using(MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Body = Mensagem;
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);
            }
        }

        //Envio de e-mail com dados
        public static void EnviaEmailDados(string De, string Para, string Assunto, string Usuario, string Senha)
        {
            using (MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Body = "<font face='Trebuchet MS', Georgia, 'Times New Roman', Times, serif'>"+
                "<table border='0' cellpadding='0' cellspacing='0' width='600' align='center'>"+
                "<tr><td valign='top'><table border='0' cellpadding='0' cellspacing='0' align='left'>"+
                "<tr><td><a href='http://www.jardsonbrito.com.br' target='_blank'>"+
                "<img border='0' src='http://www.jardsonbrito.com.br/Images/logoweb.png'></a>"+
                "</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>"+
                " <strong><font face='Tahoma' color='#595957'><h2>www.jardsonbrito.com.br</h2></font></strong>"+
                "</td></tr></table></td></tr><tr><td valign='top'><hr style='height: 8px; color: #E1BD4B' />"+
                "</td></tr><tr><td valign='top'>&nbsp;</td></tr><tr><td valign='top'>"+
                " Por favor, dirija-se ao site e <a href='http://www.jardsonbrito.com.br/Login.aspx'"+
                " title='faça login' target='_blank'>faça login</a> utilizando as seguintes informa&ccedil;&otilde;es."+
                "<br />Usu&aacute;rio: <strong>" + Usuario + "</strong><br />Senha: <strong>" + Senha + "</strong>" +
                "</td></tr><tr><td valign='top'>&nbsp;</td></tr><tr><td valign='top'><hr style='height: 8px; color: #649515' />"+
                "</td></tr><tr><td valign='top' align='center'><font face='Tahoma' size='1' color='#333333'>&copy; Todos os direitos reservados. Produzido"+
                " por: <a href='http://www.rwd.net.br' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></font>"+
                "</td></tr></table></font>";
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);
            }
        }

        //valida e-mail
        public static bool ValidaEmail(string sEmail)
        {
            if (sEmail == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(sEmail, @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|[a-zA-Z]{2})$",
                RegexOptions.IgnorePatternWhitespace);
            }
        }

        public Util()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}
