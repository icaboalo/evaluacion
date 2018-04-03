using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluacion
{
    public partial class recomendaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["promedio"] == null)
                {
                    Response.Redirect("evaluacion.aspx");
                }
                Double average = Double.Parse(Session["promedio"].ToString());
                if (average >= 8)
                {
                    Response.Write("En horabuena! Continua con el buen trabajo");
                }
                else
                {
                    Response.Write("Se un mejor profesor, intenta integrarte más a la clase.");
                }
            }
        }
    }
}