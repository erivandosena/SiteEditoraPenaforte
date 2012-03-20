<%@ Page Title="Untitled Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ObrasAutor.aspx.cs" Inherits="ObrasAutor" %>

<%@ Register src="WUC_PublicidadeLateral.ascx" tagname="WUC_PublicidadeLateral" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
            Obras Literárias do Escritor
    </h2>
    <p></p>
    <p>
    <asp:DataList ID="DlImagnes" runat="server" CellSpacing="10" DataKeyField="obr_cod" 
    DataSourceID="DsObras" EnableViewState="False" RepeatColumns="3" RepeatDirection="Horizontal" 
    Width="100%">
            <ItemTemplate>
            <div style="text-align:center;display:block;width:175px;height:auto;padding:5px;overflow:hidden">
            <a href='<%# "Escritor.aspx?o=" + Eval("obr_cod") %>' title="Clique aqui!" style="text-decoration:none">
                <img alt="<%# Eval("obr_titulo") %>" border="0" src='../HandlerImgs.ashx?imgobr=<%# Eval("obr_cod") %>&amp;tamanhocapa=M' />
            <br />    
            <%# Eval("obr_titulo") %>
            </a>
            </div>
            </ItemTemplate>
        </asp:DataList>
    </p>
    
    <p></p>
    <script src='http://connect.facebook.net/pt_BR/all.js#xfbml=1'></script><fb:like href='www.jardsonbrito.com.br/Escritor.aspx' show_faces='true' width='450' font='trebuchet ms'></fb:like>
    <p>&nbsp;</p><p>&nbsp;</p>
    
    <asp:ObjectDataSource ID="DsObras" runat="server" SelectMethod="SelecionaObrasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="obr_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="obr_titulo" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_PublicidadeLateral ID="WUC_PublicidadeLateral1" runat="server" />
</asp:Content>

