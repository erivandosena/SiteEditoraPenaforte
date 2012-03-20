<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Uploads_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Arquivos Enviados</font></h2>
        <div align="right">
            <a href="/AreaRestrita.aspx">Voltar</a></div>
        <asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="LinkButton" 
            onclick="BulletedList1_Click" Width="600px" Target="_blank">
        </asp:BulletedList>
            
            <h4>
                Selecione o arquivo para excluir:</h4>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="600px">
            </asp:RadioButtonList>
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
            Text="Excluir Arquivo" CausesValidation="False" />
        &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" 
            onclick="Button3_Click" Text="Atualizar" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </asp:Content>
