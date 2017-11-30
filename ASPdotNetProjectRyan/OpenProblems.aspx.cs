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

        protected void gvOpenProb_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Boolean blnErrorOccurred = false;
            lblError.Text = "";
            string strTicketID = "";
            string strProbNum = "";
            if(e.CommandName.Trim() == "Select")
            {
                try
                {
                    strTicketID = gvOpenProb.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
                    strProbNum = gvOpenProb.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
                }
                catch(Exception ex)
                {
                    blnErrorOccurred = true;
                    lblError.Text = "Unable to get ticket ID";
                }
            }

            if (!blnErrorOccurred)
            {
                Session.Contents["TicketID"] = strTicketID;
                Session.Contents["IncidentNo"] = strProbNum;
                Response.Redirect("/ResolutionEntry.aspx");
            }
        }
    }
}