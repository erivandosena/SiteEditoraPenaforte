<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_AcessoRapidoObras.ascx.cs" Inherits="Adm_WUC_AcessoRapidoObras" %>

<ul>
    <li>
        <h2>
            Acesso Rápido</h2>
    </li>
</ul>

<ul>
    <asp:DataList ID="DataListObras" runat="server" DataSourceID="DsObras" 
        EnableViewState="False" ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <li>
                <a href="<%# Eval("obr_cod", "CadObra.aspx?codobra={0}") %>"><%# Eval("obr_titulo")%></a>
            </li>
        </ItemTemplate>
    </asp:DataList>
</ul>

<asp:ObjectDataSource ID="DsObras" runat="server" SelectMethod="SelecionaObrasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="obr_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="obr_titulo" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<ul>
    <li>
        <h2>
            Relatórios de acesso</h2>
    </li>
</ul>
<ul>
    <li><a href="http://stats.porta80.com.br" target="_blank">Estatísticas</a>
        <br />
        <i>Informações para acesso:</i><br />
        Site ID: <b>21473</b><br />
        Usuário: <b>jardsonbrito</b><br />
        Senha: <span style="color: #CCCCCC">87829877</span></li>
</ul>
<p> </p>
<ul>
    <li>
        <h2>
            Contas de e-mail</h2>
    </li>
</ul>
<ul>
    <li><a href='http://www.workspace.com.br/jardsonbrito/'
        target='_blank'>Meu Workspace</a>
        <br />
        <i>Informações para acesso:</i><br />
        Usuário: <b>jardsonbrito</b><br />
        Senha: <span style="color: #CCCCCC">87829877</span></li>
</ul>
