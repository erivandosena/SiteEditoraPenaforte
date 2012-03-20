<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadProfessor.aspx.cs" Inherits="Adm_CadProfessor" Title="Untitled Page" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="distance">
    </div>
    <div id="container">
<h2><font color="#D9D9D7">Cadastro do Professor</font></h2>
                
                <p>
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Nome do(a) Professor(a):<br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="300px" MaxLength="100"></asp:TextBox></p>
    <p>E-mail:<br />
        <asp:TextBox ID="TextBoxEmail1" runat="server" Width="300px" MaxLength="50"></asp:TextBox>           
    <asp:Button ID="Button5" runat="server" Text="Alterar E-mail" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button5_Click"/>
                            </p>
    <p>Nome de Usuário: (Opcional)<br />
        <asp:TextBox ID="TextBoxUsuario" runat="server" Width="170px" MaxLength="50"></asp:TextBox>           
    <asp:Button ID="Button6" runat="server" Text="Alterar Nome de Usuário" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button6_Click"/>
                            </p>
    <p>Telefone:<br />
        <asp:TextBox ID="TextBoxTel1" runat="server" Width="300px" MaxLength="14"></asp:TextBox></p>
    <p>Skype:<br />
        <asp:TextBox ID="TextBoxEmail2" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
    <p>Twitter:<br />
        <asp:TextBox ID="TextBoxEmail3" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
    <p>Orkut:<br />
        <asp:TextBox ID="TextBoxEmail4" runat="server" Width="300px" MaxLength="100"></asp:TextBox></p>
    <p>YouTube:<br />
        <asp:TextBox ID="TextBoxEmail5" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
    <p>Sobre o(a) Professor(a):<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorSobre" runat="server" 
            BasePath="~/fckeditor/" Height="200px" Width="100%" ToolbarStartExpanded="false"></FCKeditorV2:FCKeditor></p>
    <p>Foto:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
        <asp:Image ID="Image1" runat="server" AlternateText="Foto miniatura" 
            BorderColor="#FDFDFD" BorderStyle="Solid" BorderWidth="5px" />
        &nbsp;
        <asp:Button ID="Button4" runat="server" Text="Remove" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button4_Click"/>
    </p>
         
    <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
    
    <asp:Button ID="Button1" runat="server" Text="Salvar" 
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
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button3_Click"/>
        </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>

