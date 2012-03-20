using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Rwd.DAL;
using Npgsql;

/// <summary>
/// Summary description for NoticiasBLL
/// </summary>
/// 

namespace Rwd.BLL
{

    [DataObject(true)]
    public class BusinessLogic
    {
        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE PÁGINAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InserePaginas(string pag_nome, string pag_descricao, string pag_conteudo, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);
                db.AddParameter("@pag_menu", pag_menu);

                db.ExecuteNonQuery("insere_paginas");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaPaginasDr(int pag_cod, string pag_nome, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                db.Parameters.Add(new NpgsqlParameter("@pag_menu", pag_menu));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_paginas");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasDs(int pag_cod, string pag_nome, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                db.Parameters.Add(new NpgsqlParameter("@pag_menu", pag_menu));
                DataSet ds = db.ExecuteDataSet("seleciona_paginas");
                return ds;
            }
        }

        //Seleciona nomes paginas por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_paginas_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaPaginas(int pag_cod, string pag_nome, string pag_descricao, string pag_conteudo, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);
                db.AddParameter("@pag_menu", pag_menu);

                db.ExecuteNonQuery("atualiza_paginas");
            }
        }

        //Exclui
        public static void ExcluiPaginas(int pag_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);

                db.ExecuteNonQuery("exclui_paginas");
            }
        }
        ////////////////////////////////////////////////////////////////////

        //Atualização 17-01-2011
        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE OBRAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereObras(string obr_titulo, string obr_descricao, string obr_autor, string obr_isbn,
                                       string obr_editora, string obr_ano, string obr_idioma, string obr_edicao, string obr_paginas,
                                       string obr_formato, string obr_peso, string obr_preco, byte[] obr_capa, int obr_capa_tamanho)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@obr_titulo", obr_titulo);
                db.AddParameter("@obr_descricao", obr_descricao);
                db.AddParameter("@obr_autor", obr_autor);
                db.AddParameter("@obr_isbn", obr_isbn);
                db.AddParameter("@obr_editora", obr_editora);
                db.AddParameter("@obr_ano", obr_ano);
                db.AddParameter("@obr_idioma", obr_idioma);
                db.AddParameter("@obr_edicao", obr_edicao);
                db.AddParameter("@obr_paginas", obr_paginas);
                db.AddParameter("@obr_formato", obr_formato);
                db.AddParameter("@obr_peso", obr_peso);
                db.AddParameter("@obr_preco", obr_preco);

                if (obr_capa == null)
                {
                    db.AddParameter("@obr_capa", obr_capa);
                    db.AddParameter("@obr_capa_mini", obr_capa);
                }
                else
                {
                    db.AddParameter("@obr_capa", ResizeImageFile(obr_capa, 500));
                    db.AddParameter("@obr_capa_mini", ResizeImageFile(obr_capa, 250));
                }

                db.AddParameter("@obr_capa_tamanho", obr_capa_tamanho); 

                db.ExecuteNonQuery("insere_obras");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaObrasDr(int obr_cod, string obr_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@obr_cod", obr_cod));
                db.Parameters.Add(new NpgsqlParameter("@obr_titulo", obr_titulo));

                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_obras");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaObrasDs(int obr_cod, string obr_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@obr_cod", obr_cod));
                db.Parameters.Add(new NpgsqlParameter("@obr_titulo", obr_titulo));

                DataSet ds = db.ExecuteDataSet("seleciona_obras");
                return ds;
            }
        }

        //Seleciona nomes Obras por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaObrasNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_obras_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaObras(int obr_cod, string obr_titulo, string obr_descricao, string obr_autor, string obr_isbn,
                                         string obr_editora, string obr_ano, string obr_idioma, string obr_edicao, string obr_paginas,
                                         string obr_formato, string obr_peso, string obr_preco)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@obr_cod", obr_cod);
                db.AddParameter("@obr_titulo", obr_titulo);
                db.AddParameter("@obr_descricao", obr_descricao);
                db.AddParameter("@obr_autor", obr_autor);
                db.AddParameter("@obr_isbn", obr_isbn);
                db.AddParameter("@obr_editora", obr_editora);
                db.AddParameter("@obr_ano", obr_ano);
                db.AddParameter("@obr_idioma", obr_idioma);
                db.AddParameter("@obr_edicao", obr_edicao);
                db.AddParameter("@obr_paginas", obr_paginas);
                db.AddParameter("@obr_formato", obr_formato);
                db.AddParameter("@obr_peso", obr_peso);
                db.AddParameter("@obr_preco", obr_preco);

                db.ExecuteNonQuery("atualiza_obras");
            }
        }

        //Exclui
        public static void ExcluiObras(int obr_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@obr_cod", obr_cod);

                db.ExecuteNonQuery("exclui_obras");
            }
        }

        //Atualiza capa
        public static void AtualizaObraCapa(int obr_cod, byte[] obr_capa, int obr_capa_tamanho)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@obr_cod", obr_cod);

                if (obr_capa == null)
                {
                    db.AddParameter("@obr_capa", obr_capa);
                    db.AddParameter("@obr_capa_mini", obr_capa);
                }
                else
                {
                    db.AddParameter("@obr_capa", ResizeImageFile(obr_capa, 500));
                    db.AddParameter("@obr_capa_mini", ResizeImageFile(obr_capa, 250));
                }

                db.AddParameter("@obr_capa_tamanho", obr_capa_tamanho); 

                db.ExecuteNonQuery("atualiza_obras_imagem");
            }
        }
        //Exibe capa
        public static Stream ExibeCapaObra(int id, TamanhoCapa tamanho)
        {

            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", id);
                db.AddParameter("@tamanho", (int)tamanho);
                object result = db.ExecuteScalar("seleciona_obras_imagem");
                try
                {
                    return new MemoryStream((byte[])result);
                }
                catch
                {
                    return null;
                }
            }

        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE SITE
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereSite(
            string sit_titulo,
            string sit_slogan,
            string sit_endereco,
            string sit_cidade,
            string sit_estado,
            string sit_cep,
            string sit_telefone,
            string sit_email,
            string sit_skype,
            string sit_twitter,
            string sit_orkut,
            string sit_youtube,
            string sit_banner1,
            string sit_banner2,
            string sit_mapa,
            byte[] sit_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_titulo", sit_titulo);
                db.AddParameter("@sit_slogan", sit_slogan);
                db.AddParameter("@sit_endereco", sit_endereco);
                db.AddParameter("@sit_cidade", sit_cidade);
                db.AddParameter("@sit_estado", sit_estado);
                db.AddParameter("@sit_cep", sit_cep);
                db.AddParameter("@sit_telefone", sit_telefone);
                db.AddParameter("@sit_email", sit_email);
                db.AddParameter("@sit_skype", sit_skype);
                db.AddParameter("@sit_twitter", sit_twitter);
                db.AddParameter("@sit_orkut", sit_orkut);
                db.AddParameter("@sit_youtube", sit_youtube);
                db.AddParameter("@sit_banner1", sit_banner1);
                db.AddParameter("@sit_banner2", sit_banner2);
                db.AddParameter("@sit_mapa", sit_mapa);

                if (sit_logo == null)
                {
                    db.AddParameter("@sit_logo", sit_logo);
                }
                else
                {
                    db.AddParameter("@sit_logo", ResizeImageFile(sit_logo, 96));
                }

                db.ExecuteNonQuery("insere_site");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaSiteDr()
        {
            using (DataAccess db = new DataAccess())
            {
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_site");
                return dr;
            }
        }

        //Atualiza
        public static void AtualizaSite(
            int sit_cod,
            string sit_titulo,
            string sit_slogan,
            string sit_endereco,
            string sit_cidade,
            string sit_estado,
            string sit_cep,
            string sit_telefone,
            string sit_email,
            string sit_skype,
            string sit_twitter,
            string sit_orkut,
            string sit_youtube,
            string sit_banner1,
            string sit_banner2,
            string sit_mapa)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);
                db.AddParameter("@sit_titulo", sit_titulo);
                db.AddParameter("@sit_slogan", sit_slogan);
                db.AddParameter("@sit_endereco", sit_endereco);
                db.AddParameter("@sit_cidade", sit_cidade);
                db.AddParameter("@sit_estado", sit_estado);
                db.AddParameter("@sit_cep", sit_cep);
                db.AddParameter("@sit_telefone", sit_telefone);
                db.AddParameter("@sit_email", sit_email);
                db.AddParameter("@sit_skype", sit_skype);
                db.AddParameter("@sit_twitter", sit_twitter);
                db.AddParameter("@sit_orkut", sit_orkut);
                db.AddParameter("@sit_youtube", sit_youtube);
                db.AddParameter("@sit_banner1", sit_banner1);
                db.AddParameter("@sit_banner2", sit_banner2);
                db.AddParameter("@sit_mapa", sit_mapa);

                db.ExecuteNonQuery("atualiza_site");
            }
        }

        //Atualiza imagem
        public static void AtualizaSiteImagem(int sit_cod, byte[] sit_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);

                if (sit_logo == null)
                {
                    db.AddParameter("@sit_logo", sit_logo);
                }
                else
                {
                    db.AddParameter("@sit_logo", ResizeImageFile(sit_logo, 96));
                }

                db.ExecuteNonQuery("atualiza_site_imagem");
            }
        }

        //Exclui
        public static void ExcluiSite(int sit_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);

                db.ExecuteNonQuery("exclui_site");
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE NOTÍCIAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereNoticias(
            string not_legenda,
            string not_titulo,
            string not_sumario,
            string not_fonte,
            string not_autor,
            string not_autoremail,
            string not_noticia)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_legenda", not_legenda);
                db.AddParameter("@not_titulo", not_titulo);
                db.AddParameter("@not_sumario", not_sumario);
                db.AddParameter("@not_fonte", not_fonte);
                db.AddParameter("@not_autor", not_autor);
                db.AddParameter("@not_autoremail", not_autoremail);
                db.AddParameter("@not_noticia", not_noticia);

                db.ExecuteNonQuery("insere_noticias");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaNoticiasDr(int not_cod, string not_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                db.Parameters.Add(new NpgsqlParameter("@not_titulo", not_titulo));

                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_noticias");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaNoticiasDs(int not_cod, string not_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                db.Parameters.Add(new NpgsqlParameter("@not_titulo", not_titulo));

                DataSet ds = db.ExecuteDataSet("seleciona_noticias");
                return ds;
            }
        }

        //Seleciona notícias publicadas por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaNoticiasPublicadasDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_noticias_exibe_todas");
                return ds;
            }
        }

        //Seleciona 10 notícias por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet Seleciona10NoticiasDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_noticias_10");
                return ds;
            }
        }

        //Seleciona nomes noticias por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaNoticiasNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_noticias_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaNoticias(
            int not_cod,
            DateTime not_dataalteracao,
            string not_legenda,
            string not_titulo,
            string not_sumario,
            string not_fonte,
            string not_autor,
            string not_autoremail,
            string not_noticia)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@not_dataalteracao", not_dataalteracao);
                db.AddParameter("@not_legenda", not_legenda);
                db.AddParameter("@not_titulo", not_titulo);
                db.AddParameter("@not_sumario", not_sumario);
                db.AddParameter("@not_fonte", not_fonte);
                db.AddParameter("@not_autor", not_autor);
                db.AddParameter("@not_autoremail", not_autoremail);
                db.AddParameter("@not_noticia", not_noticia);

                db.ExecuteNonQuery("atualiza_noticias");
            }
        }
        
        //Atualiza publicação
        public static void AtualizaNoticiasPublicacao(int not_cod, string not_status)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@not_status", not_status);

                db.ExecuteNonQuery("atualiza_noticias_publicacao");
            }
        }

        //Atualiza visualização
        public static void AtualizaNoticiasVisualizao(int codigo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", codigo);

                db.ExecuteNonQuery("atualiza_noticias_visualizacoes");
            }
        }

        //Exclui
        public static void ExcluiNoticias(int not_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);

                db.ExecuteNonQuery("exclui_noticias");
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE IMAGENS DA NOTÍCIA
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereImagensnoticia(
            int not_cod,
            byte[] foto,
            int ima_foto_tamanho,
            string ima_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@ima_foto_mini", ResizeImageFile(foto, 200));
                db.AddParameter("@ima_foto_normal", ResizeImageFile(foto, 500));
                db.AddParameter("@ima_foto_ampliada", ResizeImageFile(foto, 900));
                db.AddParameter("@ima_foto_tamanho", ima_foto_tamanho);
                db.AddParameter("@ima_legenda", ima_legenda);

                db.ExecuteNonQuery("insere_imagensnoticia");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaImagensnoticiaDr(int url_cod, string url_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@url_cod", url_cod));
                db.Parameters.Add(new NpgsqlParameter("@url_nome", url_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_imagensnoticia");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaImagensnoticiaDs(int not_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                DataSet ds = db.ExecuteDataSet("seleciona_imagensnoticia");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaImagensnoticia(
            int ima_cod,
            int not_cod,
            byte[] foto,
            int ima_foto_tamanho,
            string ima_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@ima_cod", ima_cod);
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@ima_foto_mini", ResizeImageFile(foto, 200));
                db.AddParameter("@ima_foto_normal", ResizeImageFile(foto, 500));
                db.AddParameter("@ima_foto_ampliada", ResizeImageFile(foto, 900));
                db.AddParameter("@ima_foto_tamanho", ima_foto_tamanho);
                db.AddParameter("@ima_legenda", ima_legenda);

                db.ExecuteNonQuery("atualiza_imagensnoticia");
            }
        }

        //Exclui
        public static void ExcluiImagensnoticia(int ima_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@ima_cod", ima_cod);

                db.ExecuteNonQuery("exclui_imagensnoticia");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE PROFESSORES
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereProfessores(
            string pro_nome, 
            string pro_sobre,  
            string pro_telefone,
            string pro_email, 
            string pro_skype,  
            string pro_twitter,
            string pro_orkut, 
            string pro_youtube,
            byte[] pro_foto)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pro_nome", pro_nome); 
                db.AddParameter("@pro_sobre", pro_sobre);  
                db.AddParameter("@pro_telefone", pro_telefone);
                db.AddParameter("@pro_email", pro_email); 
                db.AddParameter("@pro_skype", pro_skype);  
                db.AddParameter("@pro_twitter", pro_twitter);
                db.AddParameter("@pro_orkut", pro_orkut);
                db.AddParameter("@pro_youtube", pro_youtube); 

                if (pro_foto == null)
                {
                    db.AddParameter("@pro_foto_miniatura", pro_foto);
                    db.AddParameter("@pro_foto_normal", pro_foto);
                }
                else
                {
                    db.AddParameter("@pro_foto_miniatura", ResizeImageFile(pro_foto, 115));
                    db.AddParameter("@pro_foto_normal", ResizeImageFile(pro_foto, 480));
                }

                db.ExecuteNonQuery("insere_professores");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaProfessoresDr(int pro_cod, string pro_nome, string pro_email)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pro_cod", pro_cod));
                db.Parameters.Add(new NpgsqlParameter("@pro_nome", pro_nome));
                db.Parameters.Add(new NpgsqlParameter("@pro_email", pro_email));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_professores");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaProfessoresDs(int pro_cod, string pro_nome, string pro_email)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pro_cod", pro_cod));
                db.Parameters.Add(new NpgsqlParameter("@pro_nome", pro_nome));
                db.Parameters.Add(new NpgsqlParameter("@pro_email", pro_email));
                DataSet ds = db.ExecuteDataSet("seleciona_professores");
                return ds;
            }
        }

        //Seleciona nomes professores por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaProfessoresNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_professores_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaProfessores(
            int pro_cod,
            string pro_nome, 
            string pro_sobre,  
            string pro_telefone,
            string pro_email, 
            string pro_skype,  
            string pro_twitter,
            string pro_orkut,
            string pro_youtube)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pro_cod", pro_cod); 
                db.AddParameter("@pro_nome", pro_nome); 
                db.AddParameter("@pro_sobre", pro_sobre);  
                db.AddParameter("@pro_telefone", pro_telefone);
                db.AddParameter("@pro_email", pro_email); 
                db.AddParameter("@pro_skype", pro_skype);  
                db.AddParameter("@pro_twitter", pro_twitter);
                db.AddParameter("@pro_orkut", pro_orkut);
                db.AddParameter("@pro_youtube", pro_youtube); 

                db.ExecuteNonQuery("atualiza_professores");
            }
        }

        //Atualiza email
        public static void AtualizaProfessoresEmail(int pro_cod, string pro_email)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pro_cod", pro_cod);
                db.AddParameter("@pro_email", pro_email);

                db.ExecuteNonQuery("atualiza_professores_email");
            }
        }

        //Atualiza imagem
        public static void AtualizaProfessoresImagem(int pro_cod, byte[] pro_foto)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pro_cod", pro_cod);
                if (pro_foto == null)
                {
                    db.AddParameter("@pro_foto_miniatura", pro_foto);
                    db.AddParameter("@pro_foto_normal", pro_foto);
                }
                else
                {
                    db.AddParameter("@pro_foto_miniatura", ResizeImageFile(pro_foto, 115));
                    db.AddParameter("@pro_foto_normal", ResizeImageFile(pro_foto, 480));
                }

                db.ExecuteNonQuery("atualiza_professores_imagem");
            }
        }

        //Exclui
        public static void ExcluiProfessores(int pro_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pro_cod", pro_cod);

                db.ExecuteNonQuery("exclui_professores");
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE TRATAMENTO DE IMAGEM
        ////////////////////////////////////////////////////////////////////
        //Helper Functions
        private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
            {
                Size newSize = CalculateDimensions(oldImage.Size, targetSize);                 //Format24bppRgb
                using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format64bppArgb))
                {
                    using (Graphics canvas = Graphics.FromImage(newImage))
                    {
                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                        MemoryStream m = new MemoryStream();
                        newImage.Save(m, ImageFormat.Jpeg);
                        return m.GetBuffer();
                    }
                }
            }
        }

        //Dimensiona
        private static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }

        //Imagens noticia
        public static Stream ExibeFotoNoticia(int id, TamanhoImagem size)
        {

            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", id);
                db.AddParameter("@tamanho", (int)size);
                object result = db.ExecuteScalar("seleciona_imagensnoticia_imagem");
                try
                {
                    return new MemoryStream((byte[])result);
                }
                catch
                {
                    return null;
                }
            }

        }

        //Imagem professores
        public static Stream ExibeFotoProfessores(int id, TamanhoImagem size)
        {

            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", id);
                db.AddParameter("@tamanho", (int)size);
                object result = db.ExecuteScalar("seleciona_professores_imagem");
                try
                {
                    return new MemoryStream((byte[])result);
                }
                catch
                {
                    return null;
                }
            }

        }

        //Imagem site
        public static Stream ExibeFotoSite(int id)
        {

            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", id);
                object result = db.ExecuteScalar("seleciona_site_imagem");
                try
                {
                    return new MemoryStream((byte[])result);
                }
                catch
                {
                    return null;
                }
            }

        }

        //Trata erro relacionado á imagem
        public static Stream ExibeFotoPasta(TamanhoImagem size)
        {
            string path = HttpContext.Current.Server.MapPath("~/Images/");
            switch (size)
            {
                case TamanhoImagem.Miniatura:
                    path += "si_200.gif";
                    break;
                case TamanhoImagem.Normal:
                    path += "si_400.gif";
                    break;
                case TamanhoImagem.Ampliado:
                    path += "si_900.gif";
                    break;
                default:
                    path += "si_200.gif";
                    break;
            }
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        ////////////////////////////////////////////////////////////////////
    }
}

public enum TamanhoImagem
{
    Miniatura = 1,	//ex.: 200px
    Normal = 2,		//ex.: 500px
    Ampliado = 3	//ex.: 900px
}


public enum TamanhoCapa
{
    Miniatura = 1,	//ex.: 250px
    Normal = 2,		//ex.: 500px
}