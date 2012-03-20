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

public partial class Adm_CadProfessor : System.Web.UI.Page
{
    byte[] foto = null;
    string CodProfessor = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        CodProfessor = Request.QueryString["CodProfessor"];

        if (CodProfessor == string.Empty || CodProfessor == null)
        {
            Button1.Text = "Salvar";
        }
        else
        {
            if (!IsPostBack)
            {
                CarregaProfessor();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
            Button5.Visible = true;
            Button6.Visible = true;
        }
    }

    private void CarregaProfessor()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaProfessoresDr(int.Parse(CodProfessor), null, null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["pro_cod"].ToString();
                    TextBoxNome.Text = dr["pro_nome"].ToString();
                    TextBoxTel1.Text = dr["pro_telefone"].ToString();
                    TextBoxEmail1.Text = dr["pro_email"].ToString();

                    MembershipUserCollection users = Membership.FindUsersByEmail(dr["pro_email"].ToString());
                    foreach (MembershipUser user in users)
                    {
                            TextBoxUsuario.Text = user.UserName;
                    }

                    TextBoxEmail2.Text = dr["pro_skype"].ToString();
                    TextBoxEmail3.Text = dr["pro_twitter"].ToString();
                    TextBoxEmail4.Text = dr["pro_orkut"].ToString();
                    TextBoxEmail5.Text = dr["pro_youtube"].ToString();
                    FCKeditorSobre.Value = dr["pro_sobre"].ToString();

                    Session["UserAtual"] = TextBoxUsuario.Text;
                    Session["MailAtual"] = TextBoxEmail1.Text;

                    Image1.ImageUrl = "~/HandlerImgs.ashx?Tamanho=M&imgpro=" + Label1.Text;

                    foto = dr["pro_foto_miniatura"] as byte[];
                    if (foto != null)
                    {
                        Button4.Visible = true;
                    }

                    Button1.Text = "Atualizar";
                    Button3.Visible = true;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Valida campos
        LblMsg.Text = "";
        //Gera o nome de usuario
        if (string.IsNullOrEmpty(TextBoxUsuario.Text))
        {
            if (Util.valida(TextBoxNome.Text) != string.Empty)
            {
                LblMsg.Text = Util.valida(TextBoxNome.Text);
                LblMsg.Text = "Nome do(a) Professor - " + LblMsg.Text;
                TextBoxNome.Focus();
            }
            else
                if (Util.valida(TextBoxEmail1.Text) != string.Empty)
                {
                    LblMsg.Text = Util.valida(TextBoxEmail1.Text);
                    LblMsg.Text = "E-mail - " + LblMsg.Text;
                    TextBoxEmail1.Focus();
                }
                else
                    if (!Util.ValidaEmail(TextBoxEmail1.Text.ToLower()))
                    {
                        LblMsg.Text = "Informe um e-mail válido";
                        TextBoxEmail1.Focus();
                    }
                    else
                        TextBoxUsuario.Text = GeraNomeUsuario(TextBoxEmail1.Text.ToLower());
        }

        if (Util.valida(TextBoxNome.Text) != string.Empty)
        {
            LblMsg.Text = Util.valida(TextBoxNome.Text);
            LblMsg.Text = "Nome do(a) Professor - " + LblMsg.Text;
            TextBoxNome.Focus();
        }
        else
            if (Util.valida(TextBoxEmail1.Text) != string.Empty)
            {
                LblMsg.Text = Util.valida(TextBoxEmail1.Text);
                LblMsg.Text = "E-mail - " + LblMsg.Text;
                TextBoxEmail1.Focus();
            }
            else
                if (!Util.ValidaEmail(TextBoxEmail1.Text))
                {
                    LblMsg.Text = "Informe um e-mail válido";
                    TextBoxEmail1.Focus();
                }
                else
                    //Validação p/ o membership
                    //verifica se o e-mail ja existe
                    if (VerificaEmail(TextBoxEmail1.Text) && Label1.Text == string.Empty)
                    {
                        LblMsg.Text = "E-mail já existe, informe outro";
                        TextBoxEmail1.Focus();
                    }
                    else
                        //verifica se o user já existe e Gera o nome de usuario
                        if (VerificaUsuario(TextBoxUsuario.Text) && Label1.Text == string.Empty)
                        {
                            LblMsg.Text = "Nome de usuário já existe, informe outro";
                            TextBoxUsuario.Focus();
                        }
                        else
                            //Validação p/ o membership
                            if (!FileUpload1.HasFile && Label1.Text == string.Empty)
                            {
                                LblMsg.Text = Util.valida(FileUpload1.FileName);
                                LblMsg.Text = "Foto - " + LblMsg.Text;
                                FileUpload1.Focus();
                            }
                            else
                                try
                                {
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

                                        if (FileUpload1.HasFile)
                                        {
                                            foto = FileUpload1.FileBytes;
                                        }
                                        else
                                        {
                                            foto = null;
                                        }

                                        if (Label1.Text == string.Empty)
                                        {
                                            //Insere
                                            BusinessLogic.InsereProfessores(
                                                pro_nome,
                                                pro_sobre,
                                                pro_telefone,
                                                pro_email,
                                                pro_skype,
                                                pro_twitter,
                                                pro_orkut,
                                                pro_youtube,
                                                foto);
                                            LblMsg.Text += "Professor e ";

                                            //---------- Cadastra usuario membership ----------
                                            // Generate a new 12-character password with 1 non-alphanumeric character.
                                            string password = Membership.GeneratePassword(6, 1);

                                            MembershipCreateStatus memStatus = new MembershipCreateStatus();
                                            MembershipUser newUser = Membership.CreateUser(Util.Remove_Acento(TextBoxUsuario.Text.ToLower()), password, TextBoxEmail1.Text.ToLower(), null, null, true, out memStatus);
                                            Roles.AddUserToRole(Util.Remove_Acento(TextBoxUsuario.Text), "Professor");

                                            string SiteEmail = ConfigurationManager.AppSettings["SiteEmail"];
                                            //Envia e-mail para o usuario cadastrado
                                            Util.EnviaEmailDados(SiteEmail, TextBoxEmail1.Text.ToLower(), "Seus dados para acesso ", Util.Remove_Acento(TextBoxUsuario.Text.ToLower()), password);

                                            if (memStatus == MembershipCreateStatus.Success)
                                            {
                                                LblMsg.Text += "Usuário cadastrado com sucesso!";
                                            }

                                            //---------- Cadastra usuario membership ----------

                                            LimpaControles(this);
                                            Label1.Text = string.Empty;
                                        }
                                        else
                                        {
                                            //Atualiza
                                            if (FileUpload1.HasFile)
                                            {
                                                foto = FileUpload1.FileBytes;
                                                BusinessLogic.AtualizaProfessoresImagem(int.Parse(Label1.Text), foto);
                                            }
                                            BusinessLogic.AtualizaProfessores(
                                                int.Parse(Label1.Text),
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
                                            Label1.Text = string.Empty;

                                            CarregaProfessor();
                                        }


                                    }
                                }
                                catch (System.Configuration.Provider.ProviderException)
                                {
                                    LblMsg.Text = "Usuário não criado!";
                                }
                                catch (NpgsqlException)
                                {
                                    LblMsg.Text = "Erro nos dados.";
                                }
                                catch (Exception)
                                {
                                    LblMsg.Text = "Erro no sistema.";
                                }

    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Professores.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int pro_cod = int.Parse(CodProfessor);

            BusinessLogic.ExcluiProfessores(pro_cod);

            if (!string.IsNullOrEmpty(Session["UserAtual"].ToString()))
            {
                if (VerificaUsuario(Session["UserAtual"].ToString()))
                {
                    Membership.DeleteUser(Session["UserAtual"].ToString());
                }
            }

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;


            LblMsg.Text = "Excluído com sucesso!";

        }
        catch (NpgsqlException ex)
        {
            LblMsg.Text = "Erro nos dados: " + ex.Message;
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Erro no sistema: " + ex.Message;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        foto = null;
        BusinessLogic.AtualizaProfessoresImagem(int.Parse(Label1.Text), foto);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }

    private static string GeraNomeUsuario(string nome)
    {
       string nome_usuario = string.Empty;
       string str_email = nome.Trim().ToLower();
       nome_usuario = str_email.Substring(0, str_email.IndexOf("@"));
       return nome_usuario;
    }
    
    //verificar a disponibilidade e-mail
    private static bool VerificaEmail(string e_mail)
    {
        bool emailExist = false;
        MembershipUserCollection users = Membership.FindUsersByEmail(e_mail.ToLower());
        foreach (MembershipUser email in users)
        {
            if (e_mail.ToLower() == email.Email)
            {
                emailExist = true;
                break;
            }
            else
            {
                emailExist = false;
            }
        }
        return emailExist;
    }

    //verificar a disponibilidade user
    private static bool VerificaUsuario(string usuario)
    {
        bool userExist = false;
        MembershipUserCollection users = Membership.FindUsersByName(usuario.ToLower());
        foreach (MembershipUser user in users)
        {
            if (usuario.ToLower() == user.UserName)
            {
                userExist = true;
                break;
            }
            else
            {
                userExist = false;
            }
        }
        return userExist;
    }

    private string GetEmailTemplate()
    {
        string templatePath = Server.MapPath(@"~\HtmlDadosAcesso.html");

        using (StreamReader sr = new StreamReader(templatePath))
            return sr.ReadToEnd();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        MembershipUser u;

        //Valida email
        if (!Util.ValidaEmail(TextBoxEmail1.Text.ToLower()))
        {
            LblMsg.Text = "Informe um e-mail válido";
            TextBoxEmail1.Focus();
        }
        else
            //verifica se o e-mail ja existe
            if (VerificaEmail(TextBoxEmail1.Text))
            {
                LblMsg.Text = "E-mail já existe, informe outro";
                TextBoxEmail1.Focus();
            }
            else

                try
                {
                    u = Membership.GetUser(Session["UserAtual"].ToString());
                    u.Email = TextBoxEmail1.Text.ToLower();
                    Membership.UpdateUser(u);

                    // Atualiza também no cadastro
                    BusinessLogic.AtualizaProfessoresEmail(int.Parse(Label1.Text), TextBoxEmail1.Text.ToLower());

                    CarregaProfessor();
                    LblMsg.Text = "E-mail atualizado com sucesso!";
                }
                catch (System.Configuration.Provider.ProviderException)
                {
                    LblMsg.Text = "E-mail não atualizado!";
                }
                catch (NpgsqlException)
                {
                    LblMsg.Text = "Erro nos dados.";
                }
                catch (Exception)
                {
                    LblMsg.Text = "Erro no sistema.";
                }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        //verifica se o user já existe
        if (VerificaUsuario(TextBoxUsuario.Text))
        {
            LblMsg.Text = "Nome de usuário já existe, informe outro";
            TextBoxUsuario.Focus();
        }
        else

            try
            {
                Membership.DeleteUser(Session["UserAtual"].ToString());

                //Cria nova conta com o novo usuario
                string password = Membership.GeneratePassword(6, 1);
                MembershipCreateStatus memStatus = new MembershipCreateStatus();
                MembershipUser newUser = Membership.CreateUser(Util.Remove_Acento(TextBoxUsuario.Text.ToLower()), password, TextBoxEmail1.Text.ToLower(), null, null, true, out memStatus);
                Roles.AddUserToRole(Util.Remove_Acento(TextBoxUsuario.Text), "Professor");

                if (memStatus == MembershipCreateStatus.Success)
                {
                    //Envia e-mail para o usuario cadastrado
                    string SiteEmail = ConfigurationManager.AppSettings["SiteEmail"];
                    Util.EnviaEmailDados(SiteEmail, TextBoxEmail1.Text.ToLower(), "Alteração de Usuário - Seus dados para acesso ", Util.Remove_Acento(TextBoxUsuario.Text.ToLower()), password);

                    CarregaProfessor();
                    LblMsg.Text = "Usuário atualizado com sucesso!";
                }

            }
            catch (System.Configuration.Provider.ProviderException)
            {
                LblMsg.Text = "Usuário não atualizado!";
            }
            catch (NpgsqlException)
            {
                LblMsg.Text = "Erro nos dados.";
            }
            catch (Exception)
            {
                LblMsg.Text = "Erro no sistema.";
            }

    }
}