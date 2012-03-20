<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Uploads_Default, App_Web_dxjdf_a4" title="Untitled Page" %>

<%@ Register Src="../WUC_InforDestaque.ascx" TagName="WUC_InforDestaque" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            color: #999999;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Arquivos Disponíveis para Download</font></h2>
        <div align="right"></div>
            
           <span class="style1"><!-- <asp:Label ID="Label1" runat="server"></asp:Label> 
		   Arquivos restritos para professores e alunos do portal Editora Penaforte -->
		   </span>

        <asp:BulletedList ID="BulletedList1"  runat="server" DisplayMode="LinkButton" 
            onclick="BulletedList1_Click" Width="600px" Target="_blank">
        </asp:BulletedList>
        <span class="style1"><asp:Label ID="Label2" runat="server"></asp:Label></span> 
        <asp:BulletedList ID="BulletedList2" runat="server" DisplayMode="LinkButton" 
            Width="600px" Target="_blank" onclick="BulletedList2_Click">
        </asp:BulletedList>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Atualizar 
        Lista</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_InforDestaque ID="WUC_InforDestaque1" runat="server" />
</asp:Content>
