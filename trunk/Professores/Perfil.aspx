<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Perfil.aspx.cs" Inherits="Professores_Perfil" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Perfil do Professor</font></h2>
        <div align="right">
            <a href="/AreaRestrita.aspx">Voltar</a></div>
        <p>
            Nome:<br />
            <asp:TextBox ID="TextBoxNome" runat="server" Width="400px" MaxLength="100"></asp:TextBox></p>
        <p>
            Telefone:<br />
            <asp:TextBox ID="TextBoxTel1" runat="server" Width="300px" MaxLength="14"></asp:TextBox></p>
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
            E-mail:<br />
            <asp:TextBox ID="TextBoxEmail1" runat="server" Width="300px" MaxLength="50" Enabled="False"
                ReadOnly="True"></asp:TextBox></p>
        <p>
            Quem sou eu:<br />
            <FCKeditorV2:FCKeditor ID="FCKeditorSobre" runat="server" BasePath="~/fckeditor/"
                Height="200px" Width="100%" ToolbarStartExpanded="false" ToolbarSet="Basic">
            </FCKeditorV2:FCKeditor>
        </p>
        <p>
            Foto:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Image ID="Image1" runat="server" AlternateText="Foto miniatura" BorderColor="#FDFDFD"
                BorderStyle="Solid" BorderWidth="5px" />
            &nbsp;
            <asp:Button ID="Button4" runat="server" Text="Remove" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" CausesValidation="False" Visible="False" OnClick="Button4_Click" />
        </p>
        <p>
            <asp:Label ID="LblMsg" runat="server"></asp:Label></p>
        <asp:Button ID="Button1" runat="server" Text="Salvar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
            UseSubmitBehavior="False" OnClick="Button1_Click" />
        &nbsp;
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
