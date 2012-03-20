<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Professores.aspx.cs" Inherits="Adm_Professores" Title="Untitled Page" %>

<%@ Register Src="WUC_AcessoRapido.ascx" TagName="WUC_AcessoRapido" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Professores Cadastrados</font></h2>
        <div align="right">
            <a href="/Adm/Default.aspx">Voltar</a></div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Names="Trebuchet MS"
            Font-Size="10pt" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20">
            <PagerSettings PageButtonCount="20" />
            <FooterStyle Font-Bold="True" ForeColor="Black" />
            <RowStyle BackColor="WhiteSmoke" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="pro_cod" DataNavigateUrlFormatString="~/Adm/CadProfessor.aspx?codprofessor={0}"
                    DataTextField="pro_cod" DataTextFormatString="Alterar / Excluir" HeaderText="EDIÇÃO"
                    Text="Alterar/Excluir/Foto">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="pro_nome" HeaderText="NOME">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="pro_email" HeaderText="E-MAIL">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Italic="True" />
            <EditRowStyle BackColor="#004080" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <p>
            <asp:Label ID="LblMsg" runat="server"></asp:Label></p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Cadastrar Novo" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" OnClick="Button1_Click" />
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>
