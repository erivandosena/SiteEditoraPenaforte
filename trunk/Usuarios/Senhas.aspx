<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Senhas.aspx.cs" Inherits="Adm_Usuarios_Senhas" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="distance">
    </div>
    <div id="container">
        <h2>
            <font color="#D9D9D7">Senha</font></h2>
        <div align="right">
            <a href="/AreaRestrita.aspx">Voltar</a></div>
        <p>
            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="/Usuarios/Default.aspx"
                ContinueDestinationPageUrl="/Usuarios/Default.aspx" CreateUserUrl="/Usuarios/Default.aspx"
                DisplayUserName="True" SuccessPageUrl="/Usuarios/Default.aspx" CancelButtonText="Cancelar"
                ChangePasswordButtonText="Alterar Senha" ChangePasswordFailureText="Senha incorreta ou Nova Senha inválida. Novo comprimento mínimo de senha: {0}. Caracteres não-alfanuméricos requerido: {1}."
                ChangePasswordTitleText="&lt;b&gt;Alterar senha&lt;/b&gt;" ConfirmNewPasswordLabelText="Confirmar Nova Senha:"
                ConfirmPasswordCompareErrorMessage="Confirme a nova senha que deve corresponder à nova entrada de senha."
                ConfirmPasswordRequiredErrorMessage="É necessário confirmar a nova senha. " NewPasswordLabelText="Nova Senha:"
                NewPasswordRegularExpressionErrorMessage="Por favor, digite uma senha diferente."
                NewPasswordRequiredErrorMessage="É necessária nova senha." PasswordLabelText="Senha:"
                PasswordRequiredErrorMessage="É exigido senha." SuccessText="Sua senha foi alterada!"
                SuccessTitleText="Alteração de senha completada." UserNameLabelText="Nome de usuário:"
                UserNameRequiredErrorMessage="É necessário nome de usuário.">
            </asp:ChangePassword>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
