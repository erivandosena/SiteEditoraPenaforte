<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_InforDestaque.ascx.cs"
    Inherits="WUC_InforDestaque" %>
<ul>
    <li>
        <h2>
            Informativos</h2>
    </li>
</ul>
<ul>
    <asp:DataList ID="DataListInfo" runat="server" DataSourceID="DsInfo" EnableViewState="False"
        ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <li>
                <div>
                    <a href="<%# Eval("not_cod", "Info.aspx?n={0}") %>">
                        <%# Eval("texto_resumido")%></a></div>
            </li>
        </ItemTemplate>
    </asp:DataList>
    <div id="calendar">
        [+]<a href="/Infos.aspx" title="Clique aqui">Leia todos os informativos</a>
    </div>
</ul>
<p>
</p>
<asp:ObjectDataSource ID="DsInfo" runat="server" SelectMethod="Seleciona10NoticiasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
</asp:ObjectDataSource>
