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

        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 107px; top: 137px; position: absolute" Text="Artículo:"></asp:Label>
        <asp:DropDownList ID="DdlArt" runat="server" AutoPostBack="True"  style="z-index: 1; left: 164px; top: 131px; position: absolute">
        </asp:DropDownList>
        <asp:Button ID="BtnArt" runat="server" style="position: relative; top: 228px; left: 87px" Text="Agregar Artículo" OnClick="BtnArt_Click" />

        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 163px; top: 165px; position: absolute" Text="Solo números enteros"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 78px; top: 193px; position: absolute" Text="No. Artículo:"></asp:Label>

        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 78px; top: 295px; position: absolute; right: 1124px;" Text="RFC Cliente:" Visible="False"></asp:Label>

        <asp:Button ID="BtnAlta" runat="server" style="position: relative; top: 341px; left: -36px" Text="Dar de Alta" OnClick="BtnAlta_Click" Visible="False" />
        <asp:Label ID="LblMensaje" runat="server" style="z-index: 1; left: 123px; top: 384px; position: absolute"></asp:Label>
       

        <asp:TextBox ID="TxtMonto" runat="server" style="z-index: 1; left: 164px; top: 188px; position: absolute; right: 994px;" >No. Artículo</asp:TextBox>

         <asp:DropDownList ID="DdlClientes" runat="server" AutoPostBack="True"  style="z-index: 1; left: 167px; top: 291px; position: absolute" Visible="False">
        </asp:DropDownList>

        
        <asp:Table ID="TblPedido" runat="server" GridLines="Both" style="z-index: 1; left: 422px; top: 126px; position: absolute; height: 54px; width: 509px; margin-top: 0px;">
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
                    <asp:GridView ID="GrdArtículos" runat="server" style="z-index: 1; left: 551px; top: 213px; position: absolute; height: 133px; width: 187px">
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
                
        </table>

    </div>
        
    </form>
</body>
</html>
