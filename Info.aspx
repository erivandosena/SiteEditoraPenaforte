<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Info.aspx.cs" Inherits="Info" Title="Untitled Page" %>

<%@ Register Src="WUC_PublicidadeLateral.ascx" TagName="WUC_PublicidadeLateral" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

    var tam = 15;

    function mudaFonte(tipo,elemento){
	    if (tipo=="mais") {
		    if(tam<24) tam+=1;
		    createCookie('fonte',tam,365);
	    } else {
		    if(tam>10) tam-=1;
		    createCookie('fonte',tam,365);
	    }
	    document.getElementById('txt_home').style.fontSize = tam+'px';

    }

    function createCookie(name,value,days) {
	    if (days) {
		    var date = new Date();
		    date.setTime(date.getTime()+(days*24*60*60*1000));
		    var expires = "; expires="+date.toGMTString();
	    } else var expires = "";
	    document.cookie = name+"="+value+expires+"; path=/";
    }

    function readCookie(name) {
	    var nameEQ = name + "=";
	    var ca = document.cookie.split(';');
	    for(var i=0;i < ca.length;i++)
	    {
		    var c = ca[i];
		    while (c.charAt(0)==' ') c = c.substring(1,c.length);
		    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	    }
	    return null;
    }
    </script>

    <div id="noticia-1" class="post">
        <h3>
            <asp:Label ID="Lbl_Titulo" runat="server"></asp:Label></h3>
        <br />
        <asp:Label ID="Lbl_DatPub" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Lbl_DatAtualizacao" runat="server"></asp:Label>
        <p>
        </p>
        <div align="right">
            <a target="_blank" href="Impressao.aspx?n=<%= Request.QueryString["n"] %>" title="Imprimir notícia">
                <img alt="Imprimir" title="Imprimir" src="Images/imprimir.gif" border="0" /></a>
        </div>
        <p align="right">
            Tamanho da fonte: <a id="fontemenor" href="javascript:void(0);" title="Diminuir Fonte"
                onclick="mudaFonte('menos'); return false">-A</a> <a id="fontemaior" href="javascript:void(0);"
                    title="Aumentar Fonte" onclick="mudaFonte('mais'); return false">+A</a>
        </p>
        <div id="txt_home">
            <asp:Label ID="Lbl_Noticia" runat="server" CssClass="espacolinhas"></asp:Label>
        </div>
        <p>
        </p>
        <asp:Label ID="Lbl_Visualizacao" runat="server"></asp:Label>
        <p>
        </p>
        [ <a href="Infos.aspx" title="Listar todos os informativos">Outras publicações</a>
        ]
        <p>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_PublicidadeLateral ID="WUC_PublicidadeLateral1" runat="server" />
</asp:Content>
