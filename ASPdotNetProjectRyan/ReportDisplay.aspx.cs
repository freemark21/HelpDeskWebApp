using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace ASPdotNetProjectRyan
{
    public partial class ReportDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session.Contents["ButtonClicked"] != null)
                {
                    DataSet dsData;
                    dsData = clsDatabase.GetReport(Session.Contents["ButtonClicked"].ToString());
                    if (dsData == null)
                    {
                        lblError.Text = "Error loading Report";
                    }
                    else if (dsData.Tables.Count < 1)
                    {
                        lblError.Text = "Error loading Report";
                        dsData.Dispose();
                    }
                    else
                    {
                        lblReportTitle.Text = Session.Contents["ReportTitle"].ToString();
                        gvReportDisplay.DataSource = dsData.Tables[0];
                        gvReportDisplay.DataBind();
                        dsData.Dispose();
                    }
                }
                else
                {
                    lblError.Text = "Error getting type of report";
                }
            }
        }

        protected void btnReportsList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ReportsList.aspx");
        }
    }
}