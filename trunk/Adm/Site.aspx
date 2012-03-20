<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Site.aspx.cs" Inherits="Adm_Site" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="WUC_AcessoRapido.ascx" TagName="WUC_AcessoRapido" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Cadastro do Site</font></h2>
        <p>
            <p>
                Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
            <p>
                Título do site:<br />
                <asp:TextBox ID="TextBoxNome" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
            <p>
                Slogan:<br />
                <asp:TextBox ID="TextBoxSlogan" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
            <p>
                Cidade:<br />
                <asp:TextBox ID="TextBoxCidade" runat="server" Width="300px" MaxLength="20"></asp:TextBox></p>
            <p>
                Estado:<br />
                <asp:TextBox ID="TextBoxEstado" runat="server" Width="300px" MaxLength="20"></asp:TextBox></p>
            <p>
                Telefone:<br />
                <asp:TextBox ID="TextBoxTel1" runat="server" Width="300px" MaxLength="14"></asp:TextBox></p>
            <p>
                E-mail:<br />
                <asp:TextBox ID="TextBoxEmail1" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
            <p>
                Skype:<br />
                <asp:TextBox ID="TextBoxEmail2" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
            <p>
                Twitter:<br />
                <asp:TextBox ID="TextBoxEmail3" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
            <p>
                Orkut:<br />
                <asp:TextBox ID="TextBoxEmail4" runat="server" Width="300px" MaxLength="100"></asp:TextBox></p>
            <p>
                YouTube:<br />
                <asp:TextBox ID="TextBoxEmail5" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
            <p>
                Banner (página inicial): (Largura 603 pixels, Altura 190 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorBanner" runat="server" BasePath="~/fckeditor/"
                    Height="300px" Width="100%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p>
                Publicidade 1 (página inicial): (Largura máxima permitida, 603 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorPub1" runat="server" BasePath="~/fckeditor/"
                    Height="400px" Width="100%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p>
                Publicidade 2 (páginas): (Largura máxima permitida, 250 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorPub2" runat="server" BasePath="~/fckeditor/"
                    Height="550px" Width="50%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p>
                Logomarca:<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Image ID="Image1" runat="server" />
                &nbsp;
                <asp:Button ID="Button4" runat="server" Text="Remove" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                    UseSubmitBehavior="False" CausesValidation="False" Visible="False" OnClick="Button4_Click" />
            </p>
            <p>
                <asp:Label ID="LblMsg" runat="server"></asp:Label></p>
            <asp:Button ID="Button1" runat="server" Text="Salvar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" OnClick="Button1_Click" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="Voltar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" OnClick="Button2_Click" CausesValidation="False" />
            &nbsp;
            <asp:Button ID="Button3" runat="server" Text="Excluir" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" CausesValidation="False" Visible="False" OnClick="Button3_Click" />
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>
