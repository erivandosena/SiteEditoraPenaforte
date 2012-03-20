using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rwd.BLL;
using Npgsql;
using Rwd.Util;
using System.Data;
using System.Web.Security;

public partial class Adm_CadObra : System.Web.UI.Page
{
    string CodObra = null;
    byte[] capa = null;
    int tamanho = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Enabled = true;

        //Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        CodObra = Request.QueryString["codobra"];

        if (CodObra == string.Empty || CodObra == null)
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Valida campos
            LblMsg.Text = "";
            if (Util.valida(TextBoxTitulo.Text) != string.Empty)
            {
                LblMsg.Text = Util.valida(TextBoxTitulo.Text);
                LblMsg.Text = "Título - " + LblMsg.Text;
                TextBoxTitulo.Focus();
            }
            else
                if (Util.valida(TextBoxAutor.Text) != string.Empty)
                {
                    LblMsg.Text = Util.valida(TextBoxAutor.Text);
                    LblMsg.Text = "Autor - " + LblMsg.Text;
                    TextBoxAutor.Focus();
                }
                else
                    if (Util.valida(FCKeditorObr.Value) != string.Empty)
                    {
                        LblMsg.Text = Util.valida(FCKeditorObr.Value);
                        LblMsg.Text = "Descrição - " + LblMsg.Text;
                        FCKeditorObr.Focus();
                    }
                    else

                        if (IsValid)
                        {
                            string obr_titulo = TextBoxTitulo.Text;
                            string obr_descricao = FCKeditorObr.Value;
                            string obr_autor = TextBoxAutor.Text;
                            string obr_isbn = TextBoxIsbn.Text;
                            string obr_editora = TextBoxEditora.Text;
                            string obr_ano = TextBoxAno.Text;
                            string obr_idioma = TextBoxIdioma.Text;
                            string obr_edicao = TextBoxEdicao.Text;
                            string obr_paginas = TextBoxTotPag.Text;
                            string obr_formato = TextBoxFormato.Text;
                            string obr_peso = TextBoxPeso.Text;
                            string obr_preco = TextBoxPreco.Text;

                            if (FileUpload1.HasFile)
                            {
                                capa = FileUpload1.FileBytes;
                                tamanho = (int)FileUpload1.FileContent.Length;
                            }
                            else
                            {
                                capa = null;
                            }

                            if (Label1.Text == string.Empty)
                            {
                                //Insere
                                BusinessLogic.InsereObras(obr_titulo, obr_descricao, obr_autor, obr_isbn, obr_editora, obr_ano, obr_idioma, obr_edicao, obr_paginas, obr_formato, obr_peso, obr_preco, capa, tamanho);
                                LblMsg.Text = "Obra cadastrada com sucesso!";
                                LimpaControles(this);
                                Label1.Text = string.Empty;
                            }
                            else
                            {
                                //Atualiza
                                if (FileUpload1.HasFile)
                                {
                                    capa = FileUpload1.FileBytes;
                                    tamanho = (int)FileUpload1.FileContent.Length;
                                    BusinessLogic.AtualizaObraCapa(int.Parse(Label1.Text), capa, tamanho);
                                }

                                BusinessLogic.AtualizaObras(int.Parse(CodObra), obr_titulo, obr_descricao, obr_autor, obr_isbn, obr_editora, obr_ano, obr_idioma, obr_edicao, obr_paginas, obr_formato, obr_peso, obr_preco);
                                LblMsg.Text = "Obra atualizada com sucesso!";
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Obras.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int obr_cod = int.Parse(CodObra);

            BusinessLogic.ExcluiObras(obr_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

            LblMsg.Text = "Obra excluída com sucesso!";

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
        capa = null;
        BusinessLogic.AtualizaObraCapa(int.Parse(Label1.Text), capa, 0);
        Button4.Visible = false;
        LblMsg.Text = "Capa removida com sucesso!";
    }

    private void CarregaPagina()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaObrasDr(int.Parse(CodObra), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["obr_cod"].ToString();
                    TextBoxTitulo.Text = dr["obr_titulo"].ToString();
                    FCKeditorObr.Value = dr["obr_descricao"].ToString();
                    TextBoxAutor.Text = dr["obr_autor"].ToString();
                    TextBoxEditora.Text = dr["obr_editora"].ToString();
                    TextBoxIsbn.Text = dr["obr_isbn"].ToString();
                    TextBoxIdioma.Text = dr["obr_idioma"].ToString();
                    TextBoxEdicao.Text = dr["obr_edicao"].ToString();
                    TextBoxAno.Text = dr["obr_ano"].ToString();
                    TextBoxTotPag.Text = dr["obr_paginas"].ToString();
                    TextBoxFormato.Text = dr["obr_formato"].ToString();
                    TextBoxPeso.Text = dr["obr_peso"].ToString();
                    TextBoxPreco.Text = dr["obr_preco"].ToString();
                    Image1.ImageUrl = "/HandlerImgs.ashx?imgobr=" + Label1.Text;

                    capa = dr["obr_capa"] as byte[];
                    if (capa != null)
                    {
                        Button4.Visible = true;
                    }
                }
            }
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }
}
