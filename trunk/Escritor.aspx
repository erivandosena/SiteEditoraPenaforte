<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Escritor.aspx.cs" Inherits="Escritor" Title="Untitled Page" %>

<%@ Register src="WUC_ObrasDestaque.ascx" tagname="WUC_ObrasDestaque" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>
            <asp:Label ID="LabelTitulo" runat="server"></asp:Label>
    </h2>
    
    <div style="float:left;text-align:center;vertical-align:top;width:330px;overflow:hidden">
    <p>
        <asp:Image ID="ImageCapa" runat="server" BorderWidth="0" />
    </p>    
    </div>
    
    <div style="float:left;text-align:left;vertical-align:top;padding-left:10px;width:261px;overflow:hidden">

            <asp:Label ID="LabelAutor" runat="server"></asp:Label>

            <asp:Label ID="LabelEditora" runat="server"></asp:Label>

            <asp:Label ID="LabelEdicao" runat="server" Visible="False"></asp:Label>
  
            <asp:Label ID="LabelAno" runat="server" Visible="False"></asp:Label>
   
            <asp:Label ID="LabelIdioma" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LabelPaginas" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LabelFormato" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LabelPeso" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LabelIsbn" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LabelPreco" runat="server" Visible="False"></asp:Label>

    </div>
    <div style="clear:both;padding-top:10px">
    <asp:Label ID="LabelDescricao" runat="server"></asp:Label>
    </div>
    
    <p></p>
    <asp:Label ID="LabelRecFacebook" runat="server"></asp:Label>
    <p>&nbsp;</p><p>&nbsp;</p>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_ObrasDestaque ID="WUC_ObrasDestaque1" runat="server" />
</asp:Content>

