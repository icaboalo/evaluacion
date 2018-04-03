using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluacion
{
    public partial class inicio : System.Web.UI.Page
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
                Label1.Text = ex.Message.ToString();
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
                    String query = "SELECT nombre, apellido FROM trabajador";
                    OdbcCommand command = new OdbcCommand(query, conn);
                    OdbcDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        spNames.Items.Add(reader.GetString(1) + ", " + reader.GetString(0));
                    }
                    conn.Close();
                }
            }
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            String st = spNames.SelectedValue;
            String nombre = st.Split(',')[1];
            String apellido = st.Split(',')[0];

            OdbcConnection conn = openConnection();
            if(conn != null)
            {
                String query = "SELECT idTrabajador FROM trabajador WHERE nombre='" + nombre + "' AND apellido='" + apellido + "'";
                OdbcCommand command = new OdbcCommand(query, conn);
                int idTrabajador = int.Parse(command.ExecuteScalar().ToString());
                if(Application["idEvalNext"] == null)
                {
                    Application["idEvalNext"] = 1;
                } else
                {
                    Application["idEvalNext"] = int.Parse(Application["idEvalNext"].ToString()) + 1;
                }
                int idEval = int.Parse(Application["idEvalNext"].ToString());

                query = "INSERT INTO evaluacion VALUES(" + idEval.ToString() + ", " + idTrabajador.ToString() + ", " + TextBox1.Text + ", " + TextBox2.Text + ", " + TextBox3.Text + ", " + TextBox4.Text + ")";
                command = new OdbcCommand(query, conn);
                int res = command.ExecuteNonQuery();
                conn.Close();

                if(res > 0)
                {
                    Session["idTrabajador"] = idTrabajador;
                    Response.Redirect("evaluacion.aspx");
                }
            }
        }
    }
}