<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatosCliente.aspx.cs" Inherits="DatosCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            top: -8px;
            left: 290px;
            margin-top: 387px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 346px; top: 64px; position: absolute" Text="Información del Cliente"></asp:Label>
        <asp:DropDownList ID="DdlCli" runat="server" AutoPostBack="True"  style="z-index: 1; left: 576px; top: 63px; position: absolute" OnSelectedIndexChanged="DdlCli_SelectedIndexChanged" Visible="False">
        </asp:DropDownList>
        <asp:Table ID="TblUsuario" runat="server" GridLines="Both" style="z-index: 1; left: 266px; top: 112px; position: absolute; height: 54px; width: 364px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">RFC</asp:TableCell>
                <asp:TableCell runat="server">Nombre</asp:TableCell>
                <asp:TableCell runat="server">Domicilio/Categoria</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 286px; top: 216px; position: absolute" Text="Pedidos:"></asp:Label>
        <asp:DropDownList ID="DdlPedidos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPedidos_SelectedIndexChanged" style="z-index: 1; left: 399px; top: 212px; position: absolute">
        </asp:DropDownList>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx" style="z-index: 1; left: 26px; top: 695px; position: absolute">Volver al Menú</asp:HyperLink>
        <asp:Table ID="TblPedido" runat="server" GridLines="Both" style="z-index: 1; left: 187px; top: 277px; position: absolute; height: 54px; width: 509px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Pedido</asp:TableCell>
                <asp:TableCell runat="server">Fecha</asp:TableCell>
                <asp:TableCell runat="server">Monto</asp:TableCell>
                <asp:TableCell runat="server">Saldo del cliente</asp:TableCell>
                <asp:TableCell runat="server">Saldo en facturas</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:GridView ID="GrdArtículos" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GrdPagos" runat="server" style="position: relative; top: 8px; left: 292px">
                    </asp:GridView>
                </td>
            </tr>
                
        </table>
    
    </div>
    </form>
</body>
</html>
