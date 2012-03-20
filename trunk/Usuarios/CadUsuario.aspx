<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadUsuario.aspx.cs" Inherits="Adm_Usuarios_CadUsuario" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type='text/javascript'>
function iframeAutoHeight(quem){ 
    if(navigator.appName.indexOf("Internet Explorer")>-1){ //ie sucks
        var func_temp = function(){
            var val_temp = quem.contentWindow.document.body.scrollHeight + 15
            quem.style.height = val_temp + "px";
        }
        setTimeout(function() { func_temp() },100) //ie sucks
    }else{
        var val = quem.contentWindow.document.body.parentNode.offsetHeight + 15
        quem.style.height= val + "px";
    }    
}
</script>

<div id="distance">
    </div>
    <div id="container">
    <h2><font color="#D9D9D7">Cadastro</font></h2>
                <div align="right"><a href="/AreaRestrita.aspx">Voltar</a></div>
                <font color="Red"><u>OBSERVAÇÃO</u>:</font> Reservado ao cadastro de <strong>Alunos</strong> e <strong>Administradores</strong>
                <p>
        <iframe name="IfNovoUsuario" align="middle" marginwidth="0" marginheight="0" src="NovoUsuario.aspx"
            frameborder="0" scrolling="auto" onload="iframeAutoHeight(this)" allowtransparency="true"
            width="550"></iframe>
            </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

