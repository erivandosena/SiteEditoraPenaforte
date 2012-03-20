<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alunos.aspx.cs" Inherits="Adm_Alunos" Title="Untitled Page" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="distance">
    </div>
    <div id="container">
<h2><font color="#D9D9D7">Alunos Cadastrados</font></h2>
                <div align="right"><a href="/Adm/Default.aspx">Voltar</a></div>
       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
                Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" 
               onpageindexchanging="GridView1_PageIndexChanging" PageSize="20">
                <PagerSettings PageButtonCount="20" />
                <FooterStyle Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="NOME USUÁRIO">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="E-MAIL">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Italic="True" />
                <EditRowStyle BackColor="#004080" />
                <AlternatingRowStyle BackColor="White" />
       </asp:GridView>

       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
       <p><asp:Button ID="Button1" runat="server" Text="Cadastrar Novo" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click"/>
       </p>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>

