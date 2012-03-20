<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Contato, App_Web_5fi1ymlp" title="Untitled Page" validaterequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Src="WUC_InforDestaque.ascx" TagName="WUC_InforDestaque" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Meios de contato</h2>
    <p>
        <strong>Localização:</strong>
        <br />
        Cidade:
        <asp:Label ID="LblCidade" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;Estado:
        <asp:Label ID="LblEstado" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
    </p>
    <p>
        <strong>Contatos:</strong>
        <br />
        Telefone:
        <asp:Label ID="LblTel1" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;E-mail:
        <asp:Label ID="LblMail1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2>
                    Formulário de Contato</h2>
                <p>
                    Nome:
                    <br />
                    <asp:TextBox ID="TextBoxNome" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p>
                    E-mail:
                    <br />
                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p>
                    Telefone:
                    <br />
                    <asp:TextBox ID="TextBoxTelefone" runat="server"></asp:TextBox>
                </p>
                <p>
                    Assunto:
                    <br />
                    <asp:DropDownList ID="DropDownListAss" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Informação</asp:ListItem>
                        <asp:ListItem>Elogio</asp:ListItem>
                        <asp:ListItem>Sugestão</asp:ListItem>
                        <asp:ListItem>Reclamação</asp:ListItem>
						<asp:ListItem>Pedido</asp:ListItem>
                        <asp:ListItem>Compra</asp:ListItem>
                        <asp:ListItem>Outro</asp:ListItem>
                    </asp:DropDownList>
                </p>
                Mensagem:
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" ToolbarStartExpanded="false" Height="125px" Width="319px">
                    </FCKeditorV2:FCKeditor>
                <p>
                    <asp:Button ID="Button1" runat="server" Text="Enviar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                        UseSubmitBehavior="False" OnClick="Button1_Click" />
                </p>
                <p>
                    <asp:Label ID="LblMsg" runat="server"></asp:Label></p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_InforDestaque ID="WUC_InforDestaque1" runat="server" />
</asp:Content>
