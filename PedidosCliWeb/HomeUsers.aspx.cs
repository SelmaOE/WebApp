using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeUsers : System.Web.UI.Page
{
    //Atributos.
    private GestorBD.GestorBD GestorBD;
    private string cadSql;
    private DataSet DsGeneral = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        //La propiedad IsPostBack, de cada página, tiene valor false
        //la 1a. vez que se carga la página; da true, las veces subsecuentes.
        if (!IsPostBack)
        {
            GestorBD = new GestorBD.GestorBD("MSDAORA", "bd01", "linesp", "oracle");
            Session["GestorBD"] = GestorBD;
        }

    }

    //Valida usuario y contraseña en la BD.
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

        cadSql = "select * from PCUsuarios where RFC='" + Login1.UserName +
          "' and Passw='" + Login1.Password + "'";
        //Recupera la conexión a la BD.
        GestorBD = (GestorBD.GestorBD)Session["GestorBD"];

        //Ejecuta la consulta y valida al usuario.
        GestorBD.consBD(cadSql, DsGeneral, "Temp");
        if (DsGeneral.Tables["Temp"].Rows.Count != 0)
        {
            Session["rfc"] = Login1.UserName;
            Server.Transfer("Menu.aspx");
        }
    }
}