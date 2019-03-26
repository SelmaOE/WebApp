<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeUsers.aspx.cs" Inherits="HomeUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" style="z-index: 1; left: 261px; top: 101px; position: absolute; height: 147px; width: 342px">
        </asp:Login>
    </div>
    </form>
</body>
</html>
