<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheChatScreenWin.aspx.cs"
    Inherits="TheChatScreenWin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="JavaScript">
  function Down(){
	window.scroll(0,220000)
	}
    </script>

</head>
<body onload="Down()" ms_positioning="GridLayout" topmargin="4" title="Chat Screen"
    bottommargin="4" leftmargin="4" rightmargin="4" bgcolor="#DDF1FF" 
    background="../images/fundo_bp.jpg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    </div>
    </form>
</body>
</html>
