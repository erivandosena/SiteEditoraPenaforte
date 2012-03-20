<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="Adm_Upload" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Src="WUC_AcessoRapido.ascx" TagName="WUC_AcessoRapido" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Upload de Arquivo</font></h2>
        <div align="right">
            <a href="/AreaRestrita.aspx">Voltar</a></div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" />
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label></p>
        <div>
            <h4>
                Selecione o arquivo para excluir:</h4>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="600px">
            </asp:RadioButtonList>
            <p>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Excluir Arquivo" />
            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" 
                    onclick="Button3_Click" Text="Atualizar" />
            </p>
        </div>
        <h4>
            <a href="/Uploads/Default.aspx">Visualizar arquivo disponível para download</a></h4>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>
