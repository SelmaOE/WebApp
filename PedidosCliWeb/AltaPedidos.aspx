<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaPedidos.aspx.cs" Inherits="AltaPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 489px">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 346px; top: 64px; position: absolute" Text="Alta de un Pedido"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 171px; top: 107px; position: absolute" Text="Fecha del Pedido"></asp:Label>
        <asp:Calendar ID="FechaPed" runat="server" style="position: relative; top: 115px; left: 83px"></asp:Calendar>

        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 458px; top: 149px; position: absolute" Text="Monto:"></asp:Label>
        <asp:TextBox ID="TxtMonto" runat="server" style="z-index: 1; left: 530px; top: 150px; position: absolute" >Monto</asp:TextBox>

        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 437px; top: 204px; position: absolute" Text="Saldo Cliente:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 527px; top: 204px; position: absolute" >Saldo Cliente</asp:TextBox>

        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 439px; top: 253px; position: absolute" Text="RFC Cliente:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 527px; top: 252px; position: absolute" >RFC</asp:TextBox>

        <asp:Button ID="BtnAlta" runat="server" style="position: relative; top: 163px; left: 333px" Text="Dar de Alta" />

    </div>
        
    </form>
</body>
</html>
