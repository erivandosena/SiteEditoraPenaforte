<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadPaginas.aspx.cs" Inherits="Adm_CadPaginas" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="distance">
    </div>
    <div id="container">
<h2><font color="#D9D9D7">Cadastro de Página</font></h2>
                
                <p>
<p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Título para o link da página:<br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>Descrição para o link da página:<br />
        <asp:TextBox ID="TextBoxDesc" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Conteúdo da página:<br />
        
        <FCKeditorV2:FCKeditor ID="FCKeditorPag" runat="server" 
        BasePath="~/fckeditor/" Height="700px" 
                                Width="100%"></FCKeditorV2:FCKeditor>
    </p>
    <p>Localização no menu:<br />
        <asp:DropDownList ID="DropDownList" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>ESQUERDO</asp:ListItem>
            <asp:ListItem>BASE</asp:ListItem>
        </asp:DropDownList>
    </p>
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
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>

