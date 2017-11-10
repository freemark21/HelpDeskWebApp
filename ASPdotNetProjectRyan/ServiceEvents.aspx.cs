using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ASPdotNetProjectRyan;
using System.Text.RegularExpressions;

namespace ASPdotNetProject
{
    public partial class ServiceEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClientList();
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        private void LoadClientList()
        {
            DataSet dsData = null;
            dsData = clsDatabase.GetClientList();
            if (dsData != null)
            {
                drpClientID.Items.Clear();
                drpClientID.DataSource = dsData.Tables[0];
                drpClientID.DataTextField = "ClientName";
                drpClientID.DataValueField = "ClientID";
                drpClientID.Items.Add(new ListItem("---Client---", "0"));
                //append new list item (above), making this the first item in the list
                drpClientID.AppendDataBoundItems = true;
                //add list of clients (data table name/value) to drop down list
                drpClientID.DataBind();
                dsData.Dispose();
            }
        }
    }
}