using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using Rwd.BLL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Escritor : System.Web.UI.Page
{
    public string MetaDescription
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "description";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    public string MetaKeywords
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "keywords";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    string Obra = null;
    byte[] capalivro = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Obra = Request.QueryString["o"];

        if (string.IsNullOrEmpty(Obra))
        {
            Response.Redirect("ObrasAutor.aspx");
        }
        else
            CarregaDadosWebsite();
        CarregaObra();
    }

    private void CarregaObra()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaObrasDr(int.Parse(Obra), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = Page.Title + " - Obras do Autor - " + dr["obr_titulo"].ToString();
                    //Adiciona description Meta control 
                    MetaDescription = Page.Title + " Autor:" + dr["obr_autor"].ToString();

                    LabelRecFacebook.Text = "<script src='http://connect.facebook.net/pt_BR/all.js#xfbml=1'></script><fb:like href='www.jardsonbrito.com.br/Escritor.aspx?o=" + Obra.ToString() + "' show_faces='true' width='450' action='recommend' font='trebuchet ms'></fb:like>";

                    LabelTitulo.Text = dr["obr_titulo"].ToString();
                    LabelAutor.Text = "<p></p><strong>Autor:</strong> " + dr["obr_autor"].ToString();
                    LabelEditora.Text = "<p></p><strong>Editora:</strong> " + dr["obr_editora"].ToString();
                    if (!string.IsNullOrEmpty(dr["obr_edicao"].ToString()))
                    {
                        LabelEdicao.Visible = true;
                        LabelEdicao.Text = "<p></p><strong>Edição:</strong> " + dr["obr_edicao"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["obr_ano"].ToString()))
                    {
                        LabelAno.Visible = true;
                        LabelAno.Text = "<p></p><strong>Ano de lançamento:</strong> " + dr["obr_ano"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_isbn"].ToString()))
                    {
                        LabelIsbn.Visible = true;
                        LabelIsbn.Text = "<p></p><strong>ISBN:</strong> " + dr["obr_isbn"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_idioma"].ToString()))
                    {
                        LabelIdioma.Visible = true;
                        LabelIdioma.Text = "<p></p><strong>Idioma:</strong> " + dr["obr_idioma"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_paginas"].ToString()))
                    {
                        LabelPaginas.Visible = true;
                        LabelPaginas.Text = "<p></p><strong>Total de páginas:</strong> " + dr["obr_paginas"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_formato"].ToString()))
                    {
                        LabelFormato.Visible = true;
                        LabelFormato.Text = "<p></p><strong>Formato:</strong> " + dr["obr_formato"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_peso"].ToString()))
                    {
                        LabelPeso.Visible = true;
                        LabelPeso.Text = "<p></p><strong>Peso:</strong> " + dr["obr_peso"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["obr_preco"].ToString()))
                    {
                        LabelPreco.Visible = true;
                        LabelPreco.Text = "<p></p><strong>Preço:</strong> " + dr["obr_preco"].ToString();
                    }
                    LabelDescricao.Text = dr["obr_descricao"].ToString();

                    capalivro = dr["obr_capa"] as byte[];
                    if (capalivro != null)
                    {
                        ImageCapa.ImageUrl = "../HandlerImgs.ashx?tamanhocapa=N&imgobr=" + Obra.ToString();
                        ImageCapa.AlternateText = dr["obr_titulo"].ToString();
                    }
                    if (capalivro == null)
                    {
                        ImageCapa.Visible = false;
                    }

                }
            }
        }
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["sit_titulo"].ToString();

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaObrasNomesDs())
                    {
                        MetaKeywords = DatasetToString(ds);
                    }
                }
            }
        }
    }

    private string DatasetToString(DataSet ds)
    {
        Int32 i = 0;
        String str = "rwd";
        using (DataTable dt = ds.Tables[0])
        {
            while (i < dt.Rows.Count)
            {
                str += ", " + dt.Rows[i][0].ToString();
                i++;
            }
            return (str);
        }
    }
}
