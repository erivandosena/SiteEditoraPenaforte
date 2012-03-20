<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Conteudo.aspx.cs" Inherits="Conteudo" Title="Untitled Page" %>

<%@ Register Src="WUC_PublicidadeLateral.ascx" TagName="WUC_PublicidadeLateral" TagPrefix="uc1" %>
<%@ Register Src="WUC_InforDestaque.ascx" TagName="WUC_InforDestaque" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        <div>
            <asp:Label ID="LabelPagina" runat="server"></asp:Label></div>
    </h2>
    <p>
    </p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc2:WUC_InforDestaque ID="WUC_InforDestaque1" runat="server" />
    <uc1:WUC_PublicidadeLateral ID="WUC_PublicidadeLateral1" runat="server" />
</asp:Content>
