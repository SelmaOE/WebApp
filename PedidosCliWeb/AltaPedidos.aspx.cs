using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AltaPedidos : System.Web.UI.Page
{
    //Atributos.
    private DataSet DsGeneral = new DataSet(), DsClientes = new DataSet();
    private DataSet DsArticulos = new DataSet(), DsPedidos= new DataSet();
    private GestorBD.GestorBD GestorBD;
    private Comunes objCom = new Comunes();
    private DataRow fila;
    private string cadSql, rfc, tipo;
    private const int OK = 1;

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Recupera objetos de Session.
            GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
            rfc = Session["rfc"].ToString();

            List<String> arts = new List<String>();
            List<int> Narts = new List<int>();
            Session["miLista"] = arts;
            Session["miNLista"] = Narts;

            //Recupera y muestra los datos del cliente.
            cadSql = "select * from PCUsuarios u, PCEmpleados e, PCClientes c where u.rfc='" + rfc +
                "' and (e.rfc = u.rfc or u.rfc=c.rfc)";
            GestorBD.consBD(cadSql, DsGeneral, "Usuario");
            fila = DsGeneral.Tables["Usuario"].Rows[0];
            tipo = fila["tipo"].ToString();
            Session["tipo"] = tipo;

            //Carga en el DDL el nombre de los articulos
            cadSql = "select * from PCArtículos";
            GestorBD.consBD(cadSql, DsArticulos, "Articulos");
            objCom.cargaDDL(DdlArt, DsArticulos, "Articulos", "nombre");
            Session["DsArticulos"] = DsArticulos;

            if (tipo == "Emp")
            {
                DdlClientes.Visible = true;
                Label5.Visible = true;

                //Carga en el DDL el rfc de los clientes
                cadSql = "select * from PCClientes";
                GestorBD.consBD(cadSql, DsClientes, "Clientes");
                objCom.cargaDDL(DdlClientes, DsClientes, "Clientes", "RFC");
                Session["DsClientes"] = DsClientes;
            }
        }

    }

    protected void BtnArt_Click(object sender, EventArgs e)
    {
        //Console.WriteLine(DdlArt.Text);
        int id;
        bool pudeConvertir = int.TryParse(TxtMonto.Text, out id);
        if (pudeConvertir)
        {

            if (DdlArt.Text != "" && TxtMonto.Text != "" && id > 0)
            {
                List<String> arts = (List<String>)Session["miLista"];
                List<int> Narts = (List<int>)Session["miNLista"];

                
                arts.Add(DdlArt.SelectedItem.Text);
                Narts.Add(id);
                BtnAlta.Visible = true;

                Session["miLista"] = arts;
                Session["miNLista"] = Narts;
            }
        }
        
        

    }



    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        //Recupera a GestorBD
        GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
        rfc = Session["rfc"].ToString();
        tipo = Session["tipo"].ToString();

        if (checar(tipo))
        {
            List<String> arts = (List<String>)Session["miLista"];
            List<int> Narts = (List<int>)Session["miNLista"];
            //Saca el folio nuevo
            cadSql = "select max(foliop) from PCPEDIDOS";
            GestorBD.consBD(cadSql, DsGeneral, "Pedidos");
            fila = DsGeneral.Tables["Pedidos"].Rows[0];
            int folio = Convert.ToInt16(fila["max(foliop)"].ToString()) + 1;

            //FechaPedido

            string fecha = "date '" + System.DateTime.Today.Year + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Day + "'";

            //Checar todos los articulos que estan en la lista
            int i = 0;
            int monto = 0;
            List<int> idarts = new List<int>();
            List<int> cantact = new List<int>();
            while (arts.Count > i)
            {
                //Todos los datos del artículo
                cadSql = "select * from PCArtículos where nombre='" + arts[i] + "'";
                GestorBD.consBD(cadSql, DsArticulos, "Articulo");
                fila = DsArticulos.Tables["Articulo"].Rows[0];
                //Monto Total
                int id;
                bool pudeConvertir = int.TryParse(fila["precio"].ToString(), out id);
                if (pudeConvertir)
                {
                    monto = Narts[i] *id +monto;
                }
                
                idarts.Add(Convert.ToInt16(fila["idart"].ToString()));
                cantact.Add(Convert.ToInt16(fila["cantact"].ToString()));

                i += 1;
            }
            

            if (tipo == "Cli")
            {
                cadSql = "insert into PCPedidos values (" + folio + ", " + fecha + ", null, " +
                  monto + ", 0, 0,'" + rfc + "',null )";
            }
            else
            {
                cadSql = "insert into PCPedidos values (" + folio + ", " + fecha + ", null, " +
                  monto + ", 0,0,'" + DdlClientes.SelectedItem + "', '" + rfc + "' )";
            }

            //GestorBD.altaBD(cadSql);
            
            if (GestorBD.altaBD(cadSql) == OK)
            {
                int entrega = 0;
                for (int f = 0; idarts.Count > f; f++)
                {
                    //Alta de Detalles
                    if (Narts[f] <= cantact[f])
                        entrega = Narts[f];
                    else
                        entrega = cantact[f];

                    cadSql = "insert into PCDetalle values (" + folio + "," + idarts[f] + "," + Narts[f] + ","+entrega +")";
                    var v = GestorBD.altaBD(cadSql);
                    LblMensaje.Text = "Alta exitosa";
                    //Actualizar cantidad
                    cadSql = "update PCArtículos p set p.cantAct = (p.cantAct - " + entrega + ") where idArt = " + idarts[f];
                    GestorBD.altaBD(cadSql);
                }

                cadSql = "select * from PCPedidos where foliop = " + folio;
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
                          folio + " and d.IdArt=a.IdArt";
                GestorBD.consBD(cadSql, DsArticulos, "Artículos");
                GrdArtículos.DataSource = DsArticulos.Tables["Artículos"];  //Muestra resultados.
                GrdArtículos.DataBind();

            }
            else
                LblMensaje.Text = "Error de inserción en la tabla";

        }
        else
        {
            LblMensaje.Text = "Faltan datos";
        }

        

    }
   
    protected bool checar(string tipo)
    {
        
        bool res = true;
        List<String> arts = (List<String>)Session["miLista"];
        List<int> Narts = (List<int>)Session["miNLista"];
        if (tipo == "Emp" && DdlClientes.Text != "" && arts.Count < 0) {
            res = false;
        }else
            if (tipo=="Cli" && arts.Count<0)
            {
            res = false;
            }
       
        return res;
    }

}