using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Menu : System.Web.UI.Page
{
    //Atributos.
    private GestorBD.GestorBD GestorBD;
    private string cadSql,rfc;
    private DataSet DsGeneral = new DataSet();
    private DataRow fila;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Recupera objetos de Session.
            GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
            rfc = Session["rfc"].ToString();

            //Recupera y muestra los datos del cliente.
            cadSql = "select * from PCUsuarios u, PCClientes c where u.rfc='" +
              rfc + "' and u.rfc=c.rfc";
            GestorBD.consBD(cadSql, DsGeneral, "Usuario");
            fila = DsGeneral.Tables["Usuario"].Rows[0];
            string tipo = fila["tipo"].ToString();
            /*if (tipo == "Cli")
            {
                BtnDatosCli.Visible = false;
            }*/
        }
    }

    protected void BtnDatosCli_Click(object sender, EventArgs e)
    {
        Server.Transfer("DatosCliente.aspx");
    }
}