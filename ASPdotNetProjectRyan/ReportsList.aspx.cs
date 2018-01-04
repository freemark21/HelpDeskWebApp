using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPdotNetProjectRyan
{
    public partial class ReportsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void btnInstitutionProb_Click(object sender, EventArgs e)
        {
            Session.Contents["ButtonClicked"] = "uspProblemsByInstitution";
            Session.Contents["ReportTitle"] = "Problems by Institution";
            Response.Redirect("/ReportDisplay.aspx");
        }

        protected void btnClientProb_Click(object sender, EventArgs e)
        {
            Session.Contents["ButtonClicked"] = "uspProblemsByClient";
            Session.Contents["ReportTitle"] = "Problems by Client";
            Response.Redirect("/ReportDisplay.aspx");
        }

        protected void btnProductProb_Click(object sender, EventArgs e)
        {
            Session.Contents["ButtonClicked"] = "uspProblemsByProduct";
            Session.Contents["ReportTitle"] = "Problems by Product";
            Response.Redirect("/ReportDisplay.aspx");
        }

        protected void btnTechProb_Click(object sender, EventArgs e)
        {
            Session.Contents["ButtonClicked"] = "uspProblemsByTechnician";
            Session.Contents["ReportTitle"] = "Problems by Technician";
            Response.Redirect("/ReportDisplay.aspx");
        }
    }
}