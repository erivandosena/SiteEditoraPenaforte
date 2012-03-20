<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Infos.aspx.cs" Inherits="Infos" Title="Untitled Page" %>

<%@ Register Src="WUC_PublicidadeLateral.ascx" TagName="WUC_PublicidadeLateral" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Histórico de Informativos</h2>
    <asp:GridView ID="GVNoticias" runat="server" AutoGenerateColumns="False" GridLines="None"
        Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" AllowPaging="True" OnPageIndexChanging="GVNoticias_PageIndexChanging"
        ShowHeader="False" PageSize="50" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#4A3D24" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="not_data" DataFormatString="{0:dd/MM/yyyy}" ShowHeader="False">
                <HeaderStyle Font-Bold="True" />
                <ItemStyle Font-Bold="False" Font-Size="8pt" ForeColor="#464646" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="not_cod" DataNavigateUrlFormatString="Info.aspx?n={0}"
                DataTextField="texto_resumido" ShowHeader="False">
                <HeaderStyle Font-Bold="False" Font-Underline="False" />
                <ItemStyle Font-Underline="False" />
            </asp:HyperLinkField>
        </Columns>
        <PagerStyle BackColor="#595957" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="LblMsg" runat="server"></asp:Label>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_PublicidadeLateral ID="WUC_PublicidadeLateral1" runat="server" />
</asp:Content>
