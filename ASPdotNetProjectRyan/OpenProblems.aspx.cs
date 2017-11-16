using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ASPdotNetProjectRyan
{
    public partial class OpenProblems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOpenProblems();
            }
        }

        private void GetOpenProblems()
        {
            DataSet dsData;
            dsData = clsDatabase.GetOpenProblems();
            if(dsData == null)
            {
                lblError.Text = "Error loading Problems";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error loading Problems";
                dsData.Dispose();
            }
            else
            {
                gvOpenProb.DataSource = dsData.Tables[0];
                gvOpenProb.DataBind();
                dsData.Dispose();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}