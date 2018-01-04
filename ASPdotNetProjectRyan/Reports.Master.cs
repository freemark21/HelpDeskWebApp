using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ASPdotNetProjectRyan
{
    public partial class Reports : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblDateTime.Text = DateTime.Now.ToString("hh mm yyyy");
            Page.Title = ConfigurationManager.AppSettings["PageTitle"].ToString();
        }
    }
}