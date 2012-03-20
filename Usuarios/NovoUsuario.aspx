<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NovoUsuario.aspx.cs" Inherits="Adm_Usuarios_NovoUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Usuário</title>
    <style type="text/css">
        .style1
        {
            font-size: xx-small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" Font-Names="Verdana"
        Font-Size="10pt" CompleteSuccessText="A conta foi criada com sucesso!<p></p>"
        UnknownErrorMessage="A conta não foi criada. Por favor, tente novamente." OnCreatedUser="CreateUserWizard1_CreatedUser"
        CancelButtonText="Cancela" CreateUserButtonText="Criar Usuário" DuplicateEmailErrorMessage="O endereço de e-mail que você digitou já está em uso. Por favor, indique um outro endereço de e-mail."
        DuplicateUserNameErrorMessage="Por favor, indique um nome de usuário diferente."
        FinishCompleteButtonText="Concluir" FinishPreviousButtonText="Voltar" InvalidEmailErrorMessage="igite um endereço de e-mail válido."
        InvalidPasswordErrorMessage="Senha deve conter no mínimo {0} caracteres incluindo {1} caractere(s) não-alfanumérico(s)."
        StartNextButtonText="Próximo" StepNextButtonText="Próximo" StepPreviousButtonText="Volta"
        FinishDestinationPageUrl="~/Usuarios/Target.aspx" LoginCreatedUser="False">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="1º Passo -  Infomações do Usuário">
                <ContentTemplate>
                    <table style="font-size: 10pt; font-family: Verdana" border="0" width="400">
                        <tr>
                            <td style="font-weight: bold; color: #333333; background-color: #FFFFFF" align="center"
                                colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="font-weight: bold; color: #FFFFFF; background-color: #595957">
                                <%= CreateUserWizardStep1.Title %>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" 
                                style="font-weight: normal; color: #000000; background-color: #FFFFFF" 
                                class="style1">
                                Criar conta do usuário.</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="font-weight: bold; color: #333333; background-color: #FFFFFF">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nome de Usuário:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ToolTip="Nome de usuário é necessária."
                                    ErrorMessage="Nome de usuário é necessário." ValidationGroup="CreateUserWizard1"
                                    ControlToValidate="UserName">
                                        *</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ToolTip="Senha é necessária."
                                    ErrorMessage="Senha é necessária." ValidationGroup="CreateUserWizard1" ControlToValidate="Password">
                                        *</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar 
                                    Senha:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ToolTip="É necessário confirmar a senha."
                                    ErrorMessage="É necessário confirmar a senha." ValidationGroup="CreateUserWizard1"
                                    ControlToValidate="ConfirmPassword">
                                        *</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ToolTip="E-mail é necessário."
                                    ErrorMessage="E-mail é necessário." ValidationGroup="CreateUserWizard1" ControlToValidate="Email">
                                        *</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="A senha e a confirmação de senha devem corresponder."
                                    ValidationGroup="CreateUserWizard1" ForeColor="Maroon"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:WizardStep runat="server" ID="wsAssignUserToRoles" Title="2º Passo -  Atribuir regras ao usuário"
                OnActivate="AssignUserToRoles_Activate" 
                OnDeactivate="AssignUserToRoles_Deactivate" StepType="Step">
                <table>
                    <tr>
                        <td align="center" colspan="2" style="font-weight: bold; color: #FFFFFF; background-color: #6B696B">
                            <%= wsAssignUserToRoles.Title%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" 
                            style="font-weight: normal; color: #000000; background-color: #FFFFFF" 
                            class="style1">
                            Selecione uma ou mais regras para o usuário.</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="AvailableRoles" runat="server" SelectionMode="Multiple" Height="104px"
                                Width="264px"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title="3º Passo -  Completo">
                <ContentTemplate>
                    <table border="0" style="font-family: Verdana; font-size: 100%;">
                        <tr>
                            <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                                3º Passo - Completo
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                A conta foi criada com sucesso!<p>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                    OnClientClick="" Text="Finalizar" ValidationGroup="CreateUserWizard1" 
                                    PostBackUrl="~/Usuarios/Target.aspx" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
        <MailDefinition BodyFileName="~/HtmlDadosAcesso.html" IsBodyHtml="True" Subject="Seus dados para acesso">
        </MailDefinition>
        <TitleTextStyle Font-Bold="True" BackColor="#6B696B" ForeColor="White"></TitleTextStyle>
    </asp:CreateUserWizard>
    </form>
</body>
</html>
