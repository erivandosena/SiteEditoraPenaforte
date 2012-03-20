<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LembraSenha.aspx.cs" Inherits="LembraSenha" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Recuperar Senha</h2>
    <p>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" AnswerLabelText="Resposta:"
            AnswerRequiredErrorMessage="Resposta é necessário." GeneralFailureText="Sua tentativa de recuperar a sua senha não foi bem sucedida. Por favor, tente novamente."
            QuestionFailureText="Sua resposta não pôde ser verificada. Por favor, tente novamente."
            QuestionInstructionText="Responda a pergunta abaixo para receber sua senha."
            QuestionLabelText="Pergunta:" QuestionTitleText="&lt;b&gt;Confirmação de Identidade&lt;/b&gt;"
            SubmitButtonText="Enviar" SuccessText="&lt;b&gt;Sua senha foi enviada para você&lt;/b&gt;, verifique a caixa postal do seu e-mail.<br /><p><a href='Login.aspx' title='Retornar ao login'>Retornar ao login</a></p>"
            UserNameFailureText="Não foi possível acessar suas informações. Por favor, tente novamente."
            UserNameInstructionText="Digite seu nome de usuário para receber sua senha."
            UserNameLabelText="Nome de Usuário:" UserNameRequiredErrorMessage="Nome de usuário é necessário."
            UserNameTitleText="&lt;b&gt;Esqueceu sua senha?&lt;/b&gt;" TextLayout="TextOnTop">
            <MailDefinition BodyFileName="~/HtmlDadosAcesso.html" IsBodyHtml="True" Subject="Envio de Senha">
            </MailDefinition>
            <UserNameTemplate>
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <!--  <tr>
                                   <td align="center">
                                       <strong>Esqueceu sua senha?</strong></td>
                               </tr> 
                               -->
                                <tr>
                                    <td align="center">
                                        Digite seu nome de usuário para receber sua senha.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nome 
                                       de Usuário:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="Nome de usuário é necessário." ToolTip="Nome de usuário é necessário."
                                            ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Enviar" ValidationGroup="PasswordRecovery1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #800000;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </UserNameTemplate>
        </asp:PasswordRecovery>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
