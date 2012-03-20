<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Impressao.aspx.cs" Inherits="Impressão" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Versão para impressão</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" width="555" border="0" align="center">
            <tr>
                <td>
                    <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Names="Georgia, Times New Roman, Arial, Times, serif"
                        Font-Size="18pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="LabelPublicado" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelAtualizado" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelTexto" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Website:
                    <%= Request.Url.Authority %>
                </td>
            </tr>
        </table>
    </div>

    <script language="javascript">
window.print();
    </script>

    </form>
</body>
</html>
