<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadObra.aspx.cs" Inherits="Adm_CadObra" ValidateRequest="false" %>

<%@ Register src="WUC_AcessoRapidoObras.ascx" tagname="WUC_AcessoRapidoObras" tagprefix="uc1" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="distance"></div>
<div id="container">
<h2><font color="#D9D9D7">Cadastro de Obra</font></h2>
                
                <p>
<p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Título:<br />
        <asp:TextBox ID="TextBoxTitulo" runat="server" Width="598px" MaxLength="250"></asp:TextBox></p>
        
    <p>Autor:<br />
        <asp:TextBox ID="TextBoxAutor" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
        
    <p>Descrição:<br />
        
        <fckeditorv2:fckeditor ID="FCKeditorObr" runat="server" 
        BasePath="~/fckeditor/" Height="350px" 
                                Width="100%"></fckeditorv2:fckeditor>
    </p>
        
    <p>Editora:<br />
        <asp:TextBox ID="TextBoxEditora" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
        
    <p>ISBN:<br />
        <asp:TextBox ID="TextBoxIsbn" runat="server" Width="150px" MaxLength="25"></asp:TextBox></p>
        
    <p>Idioma:<br />
        <asp:TextBox ID="TextBoxIdioma" runat="server" Width="150px" MaxLength="25"></asp:TextBox></p>
        
    <p>Edição:<br />
        <asp:TextBox ID="TextBoxEdicao" runat="server" Width="150px" MaxLength="10"></asp:TextBox></p> 
        
    <p>Ano:<br />
        <asp:TextBox ID="TextBoxAno" runat="server" Width="75px" MaxLength="4"></asp:TextBox></p> 
        
    <p>Total de páginas:<br />
        <asp:TextBox ID="TextBoxTotPag" runat="server" Width="75px" MaxLength="15"></asp:TextBox></p>
        
    <p>Formato: (cm de largura X cm de altura)<br />
        <asp:TextBox ID="TextBoxFormato" runat="server" Width="300px" MaxLength="40"></asp:TextBox></p>
        
    <p>Peso: (Kg)<br />
        <asp:TextBox ID="TextBoxPeso" runat="server" Width="75px" MaxLength="10"></asp:TextBox></p>
        
    <p>Preço: (R$)<br />
        <asp:TextBox ID="TextBoxPreco" runat="server" Width="75px" MaxLength="10"></asp:TextBox></p>
        
    <p>Capa:<br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Image ID="Image1" runat="server" />
                &nbsp;
                <asp:Button ID="Button4" runat="server" Text="Remover" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                    UseSubmitBehavior="False" CausesValidation="False" Visible="False" 
            OnClick="Button4_Click" /></p>

    <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
    
    <asp:Button ID="Button1" runat="server" Text="Inserir/Atualizar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" /> 
    &nbsp;           
    <asp:Button ID="Button2" runat="server" Text="Voltar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button2_Click" 
               CausesValidation="False"/>
    &nbsp;           
    <asp:Button ID="Button3" runat="server" Text="Excluir" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button3_Click" 
               CausesValidation="False" Visible="False"/>
               </p>
               </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_AcessoRapidoObras ID="WUC_AcessoRapidoObras1" runat="server" />
</asp:Content>

