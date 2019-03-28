<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
    </div>
        <p>
            <asp:Button ID="BtnDatosCli" runat="server" OnClick="BtnDatosCli_Click" style="position: relative; top: 1px; left: 277px" Text="Datos Cliente" />
            <asp:Button ID="BtnAlta" runat="server" style="position: relative; top: 1px; left: 515px" Text="Alta Pedido" OnClick="BtnAlta_Click" />
        </p>
    </form>
</body>
</html>
