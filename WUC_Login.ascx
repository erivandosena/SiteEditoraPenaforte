<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Login.ascx.cs" Inherits="WUC_Login" %>
<div id="principalLogin">
    <div id="formWrapper">
        <div id="formCasing">
            <asp:Image ID="Image1" runat="server" 
                AlternateText="Junte-se a nós! IEP - Fluência e Precisão" BorderWidth="0px" 
                ImageUrl="~/images/junte_se.gif" />
            <h1>
                Login de acesso</h1>
            <div id="loginForm">
                <asp:Login ID="Login1" runat="server" FailureText="Informe seus dados corretamente e tente novamente."
                    LoginButtonText="Entrar" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="Senha requerida."
                    TextLayout="TextOnTop" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário requerido."
                    DestinationPageUrl="~/AreaRestrita.aspx">
                    <LayoutTemplate>
                        <dl>
                            <dt>
                                <label for="username">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label></label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="UserName" runat="server" CssClass="input_username" MaxLength="20"
                                    TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="Usuário requerido." ToolTip="Usuário requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </dd>
                            <dt>
                                <label for="password">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label></label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="Password" runat="server" CssClass="input_password" MaxLength="15"
                                    TextMode="Password" TabIndex="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Senha requerida." ToolTip="Senha requerida." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                <span class="ajuda">&nbsp;<a href="LembraSenha.aspx">Esqueci minha senha</a></span>
                            </dd>
                            <dd>
                                <label for="remember_me">
                                    &nbsp;&nbsp;<asp:CheckBox ID="RememberMe" runat="server" Visible="False" CssClass="checkbox"
                                        TabIndex="3" Text="Lembrar de mim neste computador" /></label>
                            </dd>
                            <dd>
                                <asp:ImageButton ID="LoginButton" runat="server" AlternateText="Entrar" CommandName="Login"
                                    ImageUrl="images/login/login.gif" ValidationGroup="Login1" TabIndex="4" />
                            </dd>
                            <p class="error">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></p>
                        </dl>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
        <div id="formFooter">
        </div>
    </div>
</div>
