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

public partial class Adm_CadNoticias : System.Web.UI.Page
{
    string NoticiaCod = null;
    string ImagemCod = null;
    string ImagemOpcao = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["codnoticia"];
        ImagemCod = Request.QueryString["codimg"];
        ImagemOpcao = Request.QueryString["opcao"];

        //Permissões de acesso conforme role p/ o botão autorizar
        if (Roles.IsUserInRole("Administrador") == true || Roles.IsUserInRole("Publicador") == true)
        {
            Button4.Enabled = true;
        }
        else
        {
            Button4.Enabled = false;
        }
        //Permissões de acesso conforme role p/ o botão excluir
        if (Roles.IsUserInRole("Administrador") == true)
        {
            Button3.Enabled = true;
        }
        else
        {
            Button3.Enabled = false;
        }

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(ImagemCod) || !string.IsNullOrEmpty(ImagemOpcao))
            {
                ImagensNoticia();

                if (ImagemOpcao == "atualiza")
                {
                    LblMsg.Text += "Imagem atualizada com sucesso!";
                }
                else
                    if (ImagemOpcao == "exclui")
                    {
                        LblMsg.Text = "Imagem excluída com sucesso!";
                    }
            }
            else
                if (string.IsNullOrEmpty(NoticiaCod))
                {
                    Button1.Text = "Salvar";
                    Panel1.Visible = true;
                }
                else
                {
                    CarregaNoticia();
                    Button1.Text = "Atualizar";
                    Button3.Visible = true;
                    Button4.Visible = true;
                    Button5.Visible = true;
                    Panel1.Visible = true;
                }
        }
    }

    private void CarregaNoticia()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasDr(int.Parse(NoticiaCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LabelCodigo.Text = dr["not_cod"].ToString();
                    TxtLegenda.Text = dr["not_legenda"].ToString();
                    TxtTitulo.Text = dr["not_titulo"].ToString();
                    TextResumo.Text = dr["not_sumario"].ToString();
                    FCKeditorNoticia.Value = dr["not_noticia"].ToString();
                    TxtAutor.Text = dr["not_autor"].ToString();
                    TxtEmailAutor.Text = dr["not_autoremail"].ToString();
                    TxtFonte.Text = dr["not_fonte"].ToString();

                    LabelNoticia.Text = dr["not_titulo"].ToString();
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Noticias.aspx");
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Salvar ou atualizar Informativo
        if (Button1.Text == "Salvar" || Button1.Text == "Atualizar")
        {
            try
            {
                if (IsValid)
                {
                    string not_cod = LabelCodigo.Text;
                    string not_legenda = TxtLegenda.Text;
                    string not_titulo = TxtTitulo.Text;
                    string not_sumario = TextResumo.Text;
                    string not_noticia = FCKeditorNoticia.Value;
                    string not_autor = TxtAutor.Text;
                    string not_autoremail = TxtEmailAutor.Text.ToLower();
                    string not_fonte = TxtFonte.Text;

                    if (string.IsNullOrEmpty(LabelCodigo.Text))
                    {
                        //Insere
                        BusinessLogic.InsereNoticias(
                            not_legenda,
                            not_titulo,
                            not_sumario,
                            not_fonte,
                            not_autor,
                            not_autoremail,
                            not_noticia);
                        LblMsg.Text = "Informativo cadastrado com sucesso!";
                        LimpaControles(this);
                        LabelCodigo.Text = string.Empty;

                        //Não envia se for o administrador for redator 
                        if (!Roles.IsUserInRole("Administrador"))
                        {

                            // ==== INICIO ===== Envia e-mail p/ usuarios com roles Publicador

                            string SiteEmail = ConfigurationManager.AppSettings["SiteEmail"];
                            string UrlSite = string.Concat("http://", Request.Url.Authority.ToString());

                            string CorpoEmail = "<table width='600' border='0' cellspacing='0' cellpadding='0' align='center'>" +
                                             "<tr><td colspan='2' align='center' bgcolor='#F4F4F4'><a href=" + UrlSite.ToString() + " target='_blank'><img border='0' src='" + UrlSite.ToString() + "/Images/logoweb.png'></a> <strong> " + Request.Url.Authority + " - Publicação de Informativo/Matéria/Artigo/Notícia</strong></td>" +
                                             "</tr><tr><td colspan='2'><p><br />Prezado,</p><p>Administrador de publicações do site " + Request.Url.Authority + ", foi cadastrado um novo Informativo que aguarda sua autorização para que seja publicada on-line.<br /><br /></p></td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>Título:</td><td bgcolor='#F9F9F9'>" + not_titulo.ToString() + "</td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>Data:</td><td bgcolor='#F9F9F9'>" + string.Format("Atualizado: {0:d}", DateTime.Now) + "</td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>Redator:</td><td bgcolor='#F9F9F9'>" + User.Identity.Name + "</td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>Status atual:</td><td bgcolor='#F9F9F9'>Novo</td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>IP do computador remoto: </td><td valign='top' bgcolor='#F9F9F9'>" + Request.UserHostAddress + "</p></td></tr><tr>" +
                                             "<td bgcolor='#FBFBFB'>&nbsp;</td><td height='60' bgcolor='#F9F9F9'><font size='5'><strong><a href='" + UrlSite.ToString() + "/Adm/Noticias.aspx' title='Autorizar agora' target='_blank'>Autorizar agora</a></strong></font></td></tr>" +
                                             "<tr><td colspan='2'>&nbsp;</td></tr><tr><td colspan='2' align='center'>" +
                                             "Produzido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></td></tr></table>";

                            string[] roleListStr = Roles.GetUsersInRole("Administrador");

                            if (not_autoremail == string.Empty)
                            {
                                MembershipUser user = Membership.GetUser();
                                not_autoremail = user.Email;
                            }

                            //for (int i = 0; i < roleListStr.Length - 1; i++)
                            for (int i = 0; i < roleListStr.Length; i++)
                            {
                                MembershipUser user;
                                user = Membership.GetUser(roleListStr.GetValue(i).ToString());
                                string email = user.Email;
                                Util.EnviaEmail(not_autoremail, email, "Autorizar Publicação", CorpoEmail.ToString());
                            }

                            // ==== FINAL ===== Envia e-mail p/ usuarios com roles Publicador
                        }

                    }
                    else
                    {
                        //Atualiza
                        BusinessLogic.AtualizaNoticias(
                            int.Parse(NoticiaCod),
                            DateTime.Now.Date,
                            not_legenda,
                            not_titulo,
                            not_sumario,
                            not_fonte,
                            not_autor,
                            not_autoremail,
                            not_noticia);
                        LblMsg.Text = "Informativo atualizado com sucesso!";
                        CarregaNoticia();
                    }
                }

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

        //Autorizar Informativo 
        if (Button1.Text == "Confirma")
        {
            try
            {
                if (IsValid)
                {
                    int not_cod = int.Parse(NoticiaCod);
                    string not_status = DDL_Status.SelectedValue;

                    BusinessLogic.AtualizaNoticiasPublicacao(not_cod, not_status);
                    LblMsg.Text = "Confirmação executada com sucesso!";
                    DDL_Status.SelectedIndex = -1;
                }

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

        //Inclui, atualiza ou exclui imagem da Informativo
        if (Button1.Text == "Adiciona")
        {
            try
            {
                //Valida campos
                LblMsg.Text = "";
                if (!FileUpload1.HasFile)
                {
                    LblMsg.Text = Util.valida(FileUpload1.FileName);
                    LblMsg.Text = "Localizar imagem - " + LblMsg.Text;
                    FileUpload1.Focus();
                }
                else
                    
                if (IsValid)
                {
                    int not_cod = int.Parse(NoticiaCod);
                    byte[] foto = FileUpload1.FileBytes;
                    int ima_foto_tamanho = int.Parse(FileUpload1.FileContent.Length.ToString());
                    string ima_legenda = TxtImgLegenda.Text;

                    BusinessLogic.InsereImagensnoticia(not_cod, foto, ima_foto_tamanho, ima_legenda);
                    LblMsg.Text = "Imagem adicionada com sucesso!";
                    TxtImgLegenda.Text = string.Empty;
                }

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
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int not_cod = int.Parse(NoticiaCod);

            BusinessLogic.ExcluiNoticias(not_cod);

            LimpaControles(this);
            LabelCodigo.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;

            LblMsg.Text = "Informativo excluída com sucesso!";

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
        LblMsg.Text = string.Empty;

        if (Button4.Text == "Autorizar")
        {
            Panel1.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button5.Enabled = false;

            Button4.Text = "Retorna";
            Button1.Text = "Confirma";
        }
        else
        {
            Response.Redirect("CadNoticias.aspx?codnoticia=" + NoticiaCod.ToString());
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        ImagensNoticia();
    }

    private void ImagensNoticia()
    {
        LblMsg.Text = string.Empty;

        if (Button5.Text == "Inserir Imagem")
        {
            Panel1.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Visible = true;

            Button5.Text = "Retorna";
            Button1.Text = "Adiciona";
        }
        else
        {
            Response.Redirect("CadNoticias.aspx?codnoticia=" + NoticiaCod.ToString());
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            //Valida campos
            LblMsg.Text = "";
            if (!FileUpload1.HasFile)
            {
                LblMsg.Text = Util.valida(FileUpload1.FileName);
                LblMsg.Text = "Localizar imagem - " + LblMsg.Text;
                FileUpload1.Focus();
            }
            else
            if (IsValid)
            {
                byte[] foto = FileUpload1.FileBytes;

                BusinessLogic.AtualizaImagensnoticia(
                    int.Parse(ImagemCod),
                    int.Parse(NoticiaCod),
                    foto,
                    int.Parse(FileUpload1.FileContent.Length.ToString()),
                    TxtImgLegenda.Text);

                LblMsg.Text = "Imagem atualizada com sucesso!";
                TxtImgLegenda.Text = string.Empty;
                Response.Redirect("CadNoticias.aspx?codnoticia=" + NoticiaCod.ToString() + "&codimg=" + ImagemCod.ToString() + "&opcao=" + ImagemOpcao.ToString());
            }
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic.ExcluiImagensnoticia(int.Parse(ImagemCod));

            Response.Redirect("CadNoticias.aspx?codnoticia=" + NoticiaCod.ToString() + "&codimg=" + ImagemCod.ToString() + "&opcao=" + ImagemOpcao.ToString());
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
}
