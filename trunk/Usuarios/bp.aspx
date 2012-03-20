<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="bp.aspx.cs" Inherits="bp" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Chat</font></h2>
        <div align="right">
            <a href="/AreaRestrita.aspx">Voltar</a></div>

        <p>
            <table cellspacing="0" border="0" align="center" bgcolor="#595957" width="600">
                <tr>
                    <td width="100">
                        <iframe 
                            style="background-position: center center; border-right: orange 2px solid; border-top: orange 2px solid; border-left: orange 2px solid; width: 500px; border-bottom: orange 2px solid; height: 300px; border-color: #FFFFFF;
                            border-width: 0px; background-image: url('../../images/logo_bp.gif'); background-repeat: no-repeat; background-color: #DDF1FF;" 
                            src="TheChatScreenWin.aspx">Chat</iframe>
                    </td>
                    <td width="90" valign="top" style="color: #FFFFFF">
                        <asp:Image ID="Image1" runat="server" BorderColor="#F4F4F4" BorderStyle="Solid" BorderWidth="4px"
                            Visible="False" />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #FFFFFF">
                        Message:
                        <asp:TextBox ID="TB_ToSend" runat="server" Width="370px" TabIndex="1"></asp:TextBox>
                    </td>
                    <td align="left" style="color: #FFFFFF" valign="middle">
                        <asp:Button ID="BT_Send" runat="server" Text="Send" CssClass="button1" TabIndex="2"
                            OnClick="BT_Send_Click"></asp:Button>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </p>

    </div>
    <p>
    </p>
    <h2 class="barraconteudo">
        Envio de Arquivos</h2>
    <ul>
        <li><a href="/Usuarios/UploadUsers.aspx">Upload</a></li>
    </ul>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
