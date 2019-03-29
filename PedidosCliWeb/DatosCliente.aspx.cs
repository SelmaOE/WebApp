using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DatosCliente : System.Web.UI.Page
{
    //Atributos.
    private DataSet DsGeneral = new DataSet(), DsPedidos = new DataSet(),DsClientes= new DataSet();
    private DataSet DsArtículos = new DataSet(), DsPagos = new DataSet();
    private GestorBD.GestorBD GestorBD;
    private Comunes objCom = new Comunes();
    private DataRow fila;
    private string cadSql, rfc,tipo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Recupera objetos de Session.
            GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
            rfc = Session["rfc"].ToString();


            //Recupera y muestra los datos del cliente.
            cadSql = "select * from PCUsuarios u, PCEmpleados e, PCClientes c where u.rfc='" + rfc +
                "' and (e.rfc = u.rfc or u.rfc=c.rfc)";
            GestorBD.consBD(cadSql, DsGeneral, "Usuario");
            fila = DsGeneral.Tables["Usuario"].Rows[0];
            tipo = fila["tipo"].ToString();
            Session["tipo"] = tipo;

            if (tipo == "Ger") {

                Label3.Visible = true;
                DdlCli.Visible = true;
                Label2.Visible = false;
                DdlPedidos.Visible = false;

                TblUsuario.Rows[1].Cells[0].Text = fila["rfc"].ToString();
                TblUsuario.Rows[1].Cells[1].Text = fila["nombre"].ToString();
                TblUsuario.Rows[1].Cells[2].Text = fila["categoría"].ToString();

                //Carga en el DDL el nombre de los clientes
                cadSql = "select * from PCUSUARIOS where tipo='Cli'";
                GestorBD.consBD(cadSql, DsClientes, "Clientes");
                objCom.cargaDDL(DdlCli, DsClientes, "Clientes", "Nombre");
                Session["DsClientes"] = DsClientes;
            }
            else {

                if (tipo == "Cli") {
                    TblUsuario.Rows[1].Cells[0].Text = fila["rfc"].ToString();
                    TblUsuario.Rows[1].Cells[1].Text = fila["nombre"].ToString();
                    TblUsuario.Rows[1].Cells[2].Text = fila["domicilio"].ToString();

                    //Carga en el DDL el folio de los pedidos del cliente.
                    cadSql = "select * from PCPedidos where rfcc='" + rfc + "'";
                    GestorBD.consBD(cadSql, DsPedidos, "Pedidos");
                    objCom.cargaDDL(DdlPedidos, DsPedidos, "Pedidos", "FolioP");
                    Session["DsPedidos"] = DsPedidos;

                }
                else {

                    TblUsuario.Rows[1].Cells[0].Text = fila["rfc"].ToString();
                    TblUsuario.Rows[1].Cells[1].Text = fila["nombre"].ToString();
                    TblUsuario.Rows[1].Cells[2].Text = fila["categoría"].ToString();

                    //Carga en el DDL el folio de los pedidos del cliente.
                    cadSql = "select * from PCPedidos where rfce='" + rfc + "'";
                    GestorBD.consBD(cadSql, DsPedidos, "Pedidos");
                    objCom.cargaDDL(DdlPedidos, DsPedidos, "Pedidos", "FolioP");
                    Session["DsPedidos"] = DsPedidos;

                }
                
            }
        }
    }

    protected void DdlCli_SelectedIndexChanged(object sender, EventArgs e)
    {
        GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
        DsClientes = (DataSet)Session["DsClientes"];
        fila = DsClientes.Tables["Clientes"].Rows[DdlCli.SelectedIndex-1];

        string rfcc = fila["rfc"].ToString();
        //Carga en el DDL el folio de los pedidos del cliente seleccionado.
        cadSql = "select * from PCPedidos where rfcc='" + rfcc + "'";
        GestorBD.consBD(cadSql, DsPedidos, "Pedidos");
        objCom.cargaDDL(DdlPedidos, DsPedidos, "Pedidos", "FolioP");
        Session["DsPedidos"] = DsPedidos;

        Label2.Visible = true;
        DdlPedidos.Visible = true;
    }

    protected void DdlPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
        DsPedidos = (DataSet)Session["DsPedidos"];

        cadSql = "select * from PCPedidos where foliop = "+DdlPedidos.Text;
        GestorBD.consBD(cadSql, DsPedidos, "Pedidos");
        fila = DsPedidos.Tables["Pedidos"].Rows[0];

        TblPedido.Rows[1].Cells[0].Text = fila["FolioP"].ToString();
        TblPedido.Rows[1].Cells[1].Text = fila["FechaPed"].ToString();
        TblPedido.Rows[1].Cells[2].Text = fila["Monto"].ToString();
        TblPedido.Rows[1].Cells[3].Text = fila["SaldoCli"].ToString();
        TblPedido.Rows[1].Cells[4].Text = fila["SaldoFacs"].ToString();

        //Muestra los artículos que ampara el pedido.
        cadSql = "select Nombre, Precio, CantPed, CantEnt, Precio*CantPed as Total " +
                  "from PCArtículos a, PCDetalle d where FolioP=" +
                  DdlPedidos.Text + " and d.IdArt=a.IdArt";
        GestorBD.consBD(cadSql, DsArtículos, "Artículos");
        GrdArtículos.DataSource = DsArtículos.Tables["Artículos"];  //Muestra resultados.
        GrdArtículos.DataBind();

        //Muestra los pagos realizados para el pedido seleccionado.
        cadSql = "select * from PCPagos where FolioP=" + DdlPedidos.Text;
        GestorBD.consBD(cadSql, DsPagos, "Pagos");
        GrdPagos.DataSource = DsPagos.Tables["Pagos"];  //Muestra resultados.
        GrdPagos.DataBind();

    }

   
}