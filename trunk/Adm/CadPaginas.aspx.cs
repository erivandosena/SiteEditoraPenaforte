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

public partial class Adm_CadPaginas : System.Web.UI.Page
{
    string CodPagina = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        CodPagina = Request.QueryString["codpagina"];

        if (CodPagina == string.Empty || CodPagina == null)
        {
            Button1.Text = "Salvar";
        }
        else
        {
            if (!IsPostBack)
            {
                CarregaPagina();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
        }
    }

    private void CarregaPagina()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaPaginasDr(int.Parse(CodPagina), null, "%"))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["pag_cod"].ToString();
                    TextBoxNome.Text = dr["pag_nome"].ToString();
                    TextBoxDesc.Text = dr["pag_descricao"].ToString();
                    FCKeditorPag.Value = dr["pag_conteudo"].ToString();
                    DropDownList.SelectedValue = dr["pag_menu"].ToString();
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Valida campos
            LblMsg.Text = "";
            if (Util.valida(TextBoxNome.Text) != string.Empty)
            {
                LblMsg.Text = Util.valida(TextBoxNome.Text);
                LblMsg.Text = "Título para o link da página - " + LblMsg.Text;
                TextBoxNome.Focus();
            }
            else
                if (Util.valida(TextBoxDesc.Text) != string.Empty)
                {
                    LblMsg.Text = Util.valida(TextBoxDesc.Text);
                    LblMsg.Text = "Descrição para o link da página - " + LblMsg.Text;
                    TextBoxDesc.Focus();
                }
                else
                    if (Util.valida(FCKeditorPag.Value) != string.Empty)
                    {
                        LblMsg.Text = Util.valida(FCKeditorPag.Value);
                        LblMsg.Text = "Conteúdo da página - " + LblMsg.Text;
                        FCKeditorPag.Focus();
                    }
                    else
                        if (Util.valida(DropDownList.SelectedValue) != string.Empty)
                        {
                            LblMsg.Text = Util.valida(DropDownList.SelectedValue);
                            LblMsg.Text = "Localização no menu - " + LblMsg.Text;
                            DropDownList.Focus();
                        }
                        else

                            if (IsValid)
                            {
                                string pag_nome = TextBoxNome.Text;
                                string pag_descricao = TextBoxDesc.Text;
                                string pag_conteudo = FCKeditorPag.Value;
                                string pag_menu = DropDownList.SelectedValue;

                                if (Label1.Text == string.Empty)
                                {
                                    //Insere
                                    BusinessLogic.InserePaginas(pag_nome, pag_descricao, pag_conteudo, pag_menu);
                                    LblMsg.Text = "Página cadastrada com sucesso!";
                                    LimpaControles(this);
                                    Label1.Text = string.Empty;
                                }
                                else
                                {
                                    //Atualiza
                                    BusinessLogic.AtualizaPaginas(int.Parse(CodPagina), pag_nome, pag_descricao, pag_conteudo, pag_menu);
                                    LblMsg.Text = "Página atualizada com sucesso!";
                                    CarregaPagina();
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

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is DropDownList) ((DropDownList)ctl).SelectedIndex = -1;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Paginas.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int pag_cod = int.Parse(CodPagina);

            BusinessLogic.ExcluiPaginas(pag_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;

            LblMsg.Text = "Página excluída com sucesso!";

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
