<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Adm_Default" Title="Untitled Page" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left">
        Bem-vindo(a)!&nbsp;<asp:LoginName ID="LoginName1" runat="server" Font-Bold="True" />
        &nbsp;Você está na sua área restrita.</div>
    <div align="right">
        Hoje é
        <%= DateTime.Now.ToLongDateString() %>
    </div>
    <h2 class="barraconteudo">
        Usuários</h2>
    <ul>
        <li><a href="/Usuarios/Senhas.aspx">Modificar senha</a></li>
        <li><a href="/Usuarios/CadUsuario.aspx">Cadastrar usuário</a></li>
        <li><a href="/Usuarios/Gerenciamento.aspx">Gerenciar contas de usuários</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Professores</h2>
    <ul>
        <li><a href="Professores.aspx">Cadastro de Professores</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Alunos</h2>
    <ul>
        <li><a href="Alunos.aspx">Cadastro de Alunos</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Páginas</h2>
    <ul>
        <li><a href="Paginas.aspx">Administrar Conteúdo</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Obras literárias</h2>
    <ul>
        <li><a href="Obras.aspx">Administrar Obras</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Informativos</h2>
    <ul>
        <li><a href="Noticias.aspx">Administrar publicações</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Website</h2>
    <ul>
        <li><a href="Site.aspx">Informações do site</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Arquivos</h2>
    <ul>
        <li><a href="Upload.aspx">Envio de arquivos (Portal IEP)</a></li>
        <li><a href="UploadEscritor.aspx">Envio de arquivos (Página do Escritor)</a></li>
    </ul>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />

</asp:Content>
