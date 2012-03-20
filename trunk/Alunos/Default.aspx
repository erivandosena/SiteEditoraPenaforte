<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Alunos_Default" Title="Untitled Page" %>

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
        Área Restrita do Aluno</h2>
    <ul>
        <li><a href="/Usuarios/Senhas.aspx">Modificar senha</a></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Sala de Aula</h2>
    <ul>
        <li>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Entrar 
    na sala</asp:LinkButton></li>
    </ul>
    <p>
    </p>
    <h2 class="barraconteudo">
        Porta Arquivos</h2>
    <ul>
        <li><a href="/Uploads/Default.aspx">Arquivos</a></li>
        <li><a href="/Usuarios/UploadUsers.aspx">Upload</a></li>
    </ul>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
