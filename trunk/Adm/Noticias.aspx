<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Noticias.aspx.cs" Inherits="Adm_Noticias" Title="Untitled Page" %>

<%@ Register Src="WUC_AcessoRapido.ascx" TagName="WUC_AcessoRapido" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Informativos Cadastrados</font></h2>
        <div align="right">
            <a href="/Adm/Default.aspx">Voltar</a></div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Names="Trebuchet MS"
            Font-Size="10pt" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
            PageSize="20">
            <FooterStyle Font-Bold="True" ForeColor="Black" />
            <RowStyle BackColor="WhiteSmoke" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="not_cod" DataNavigateUrlFormatString="~/Adm/CadNoticias.aspx?codnoticia={0}"
                    DataTextField="not_cod" DataTextFormatString="Alterar/Excluir/Autorizar" HeaderText="EDIÇÃO"
                    Text="Alterar">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="not_titulo" HeaderText="TÍTULO">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="PUBLICAÇÃO" DataField="not_data" DataFormatString="{0:d}">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="ESTADO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("not_status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("not_status") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFFFF4" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Italic="True" />
            <EditRowStyle />
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
