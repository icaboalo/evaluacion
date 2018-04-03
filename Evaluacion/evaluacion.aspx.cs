using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluacion
{
    public partial class evaluacion : System.Web.UI.Page
    {

        protected OdbcConnection openConnection()
        {
            String connectionString = "Driver={SQL Server Native Client 11.0};Server={localhost};Trusted_Connection={Yes};Database={trabajadores};";
            try
            {
                OdbcConnection connection = new OdbcConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                lbAverage.Text = ex.Message.ToString();
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["idTrabajador"] == null)
            {
                Response.Redirect("inicio.aspx");
            }
            if (!IsPostBack)
            {
                OdbcConnection conn = openConnection();
                if (conn != null)
                {
                    String query = "select * from evaluacion where idTrabajador = " + Session["idTrabajador"].ToString();
                    OdbcCommand command = new OdbcCommand(query, conn);
                    OdbcDataReader rd = command.ExecuteReader();
                    Double suma = 0;
                    Double cont = 0;
                    while (rd.Read())
                    {
                        suma += rd.GetInt32(2) + rd.GetInt32(3) + rd.GetInt32(4) + rd.GetInt32(5);
                        cont += 4;
                    }
                    lbAverage.Text = (suma / cont).ToString();
                }
            }
        }

        protected void btnRecomendations_Click(object sender, EventArgs e)
        {
            Session["Promedio"] = lbAverage.Text;
            Response.Redirect("recomendaciones.aspx");
        }
    }
}