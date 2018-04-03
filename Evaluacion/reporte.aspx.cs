using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluacion
{
    public partial class reporte : System.Web.UI.Page
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
                Response.Write(ex.Message.ToString());
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OdbcConnection conn = openConnection();
                if (conn != null)
                {
                    String query = "select nombre, apellido from trabajador";
                    OdbcCommand command = new OdbcCommand(query, conn);
                    OdbcDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        spNames.Items.Add(rd.GetString(1) + ',' + rd.GetString(0));
                    }
                    conn.Close();
                }

                if(spNames.SelectedValue != null)
                {
                    this.spNames_SelectedIndexChanged(null, null);
                }
            }
        }

        protected void spNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            String st = spNames.SelectedValue;
            String nombre = st.Split(',')[1];
            String apellido = st.Split(',')[0];

            OdbcConnection conn = openConnection();
            if (conn != null)
            {
                String query = "select idTrabajador from trabajador where nombre='" + nombre + "' and apellido='" + apellido + "'";
                OdbcCommand command = new OdbcCommand(query, conn);
                int idTrabajador = int.Parse(command.ExecuteScalar().ToString());

                query = "select * from evaluacion where idTrabajador=" + idTrabajador.ToString();
                command = new OdbcCommand(query, conn);
                OdbcDataReader rd = command.ExecuteReader();
                if (!rd.HasRows)
                { 
                    Response.Write("No hay evaluaciones de este trabajador.");
                }
                gvWorker.DataSource = rd;
                gvWorker.DataBind();
                conn.Close();
            }
        }
    }
}