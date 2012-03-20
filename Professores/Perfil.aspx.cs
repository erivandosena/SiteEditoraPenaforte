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
using Rwd.Util;
using System.Net.Mail;
using System.IO;

public partial class Professores_Perfil : System.Web.UI.Page
{
    byte[] foto = null;
    string EmailProfessor = null;

    private static string CodProfessor(string email)
    {
        string cod = "";
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaProfessoresDr(-1, null, email))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cod = dr["pro_cod"].ToString();
                }
            }
        }
        return cod;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ////Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        //if (!Roles.IsUserInRole("Administrador") == true)
        //{
        //    Response.Redirect("/Adm/Default.aspx");
        //}

        MembershipUser user;
        user = Membership.GetUser();
        EmailProfessor = user.Email;

        if (!IsPostBack)
        {
            CarregaProfessor();
        }
        Button1.Text = "Atualizar";
    }

    private void CarregaProfessor()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaProfessoresDr(-1, null, EmailProfessor))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TextBoxNome.Text = dr["pro_nome"].ToString();
                    TextBoxTel1.Text = dr["pro_telefone"].ToString();
                    TextBoxEmail1.Text = dr["pro_email"].ToString();
                    TextBoxEmail2.Text = dr["pro_skype"].ToString();
                    TextBoxEmail3.Text = dr["pro_twitter"].ToString();
                    TextBoxEmail4.Text = dr["pro_orkut"].ToString();
                    TextBoxEmail5.Text = dr["pro_youtube"].ToString();
                    FCKeditorSobre.Value = dr["pro_sobre"].ToString();

                    Image1.ImageUrl = "~/HandlerImgs.ashx?Tamanho=M&imgpro=" + CodProfessor(EmailProfessor);

                    foto = dr["pro_foto_miniatura"] as byte[];
                    if (foto != null)
                    {
                        Button4.Visible = true;
                    }

                    Button1.Text = "Atualizar";
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Valida campos
        LblMsg.Text = "";
        if (Util.valida(TextBoxNome.Text) != string.Empty)
        {
            LblMsg.Text = Util.valida(TextBoxNome.Text);
            LblMsg.Text = "Nome - " + LblMsg.Text;
            TextBoxNome.Focus();
        }
        else
            if (Util.valida(FCKeditorSobre.Value) != string.Empty)
            {
                LblMsg.Text = Util.valida(FCKeditorSobre.Value);
                LblMsg.Text = "Quem sou eu - " + LblMsg.Text;
                FCKeditorSobre.Focus();
            }
            else
                if (!FileUpload1.HasFile && Button4.Visible == false)
                {
                    LblMsg.Text = Util.valida(FileUpload1.FileName);
                    LblMsg.Text = "Foto - " + LblMsg.Text;
                    FileUpload1.Focus();
                }
                else
                    if (IsValid)
                    {
                        string pro_nome = TextBoxNome.Text;
                        string pro_telefone = TextBoxTel1.Text;
                        string pro_email = TextBoxEmail1.Text;
                        string pro_skype = TextBoxEmail2.Text;
                        string pro_twitter = TextBoxEmail3.Text;
                        string pro_orkut = TextBoxEmail4.Text;
                        string pro_youtube = TextBoxEmail5.Text;
                        string pro_sobre = FCKeditorSobre.Value;
                        //Atualiza
                        if (FileUpload1.HasFile)
                        {
                            foto = FileUpload1.FileBytes;
                            BusinessLogic.AtualizaProfessoresImagem(Convert.ToInt32(CodProfessor(EmailProfessor)), foto);
                        }
                        BusinessLogic.AtualizaProfessores(
                            Convert.ToInt32(CodProfessor(EmailProfessor)),
                            pro_nome,
                            pro_sobre,
                            pro_telefone,
                            pro_email,
                            pro_skype,
                            pro_twitter,
                            pro_orkut,
                            pro_youtube);
                        LblMsg.Text = "Atualizado com sucesso!";
                        LimpaControles(this);

                        CarregaProfessor();
                    }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        foto = null;
        BusinessLogic.AtualizaProfessoresImagem(Convert.ToInt32(CodProfessor(EmailProfessor)), foto);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }
}
