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
    public partial class ResolutionEntry : System.Web.UI.Page
    {
        Int32 intResNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTechnicianList();
            }
        }

        private void LoadTechnicianList()
        {
            DataSet dsData = null;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData != null)
            {
                drpTech.Items.Clear();
                drpTech.DataSource = dsData.Tables[0];
                drpTech.DataTextField = "TechName";
                drpTech.DataValueField = "TechnicianID";
                drpTech.Items.Add(new ListItem("---Select Technician---", "0"));
                //append new list item (above), making this the first item in the list
                drpTech.AppendDataBoundItems = true;
                //add list of products (data table name/value) to drop down list
                drpTech.DataBind();
                dsData.Dispose();
            }
        }

        private void ResetFields()
        {
            lblError.Text = "";
            txtCostMile.Text = "";
            txtDateFixed.Text = "";
            txtDateOnsite.Text = "";
            txtHours.Text = "";
            txtMileage.Text = "";
            txtMisc.Text = "";
            txtResolution.Text = "";
            txtSupplies.Text = "Add";
            txtResolution.Focus();
            LoadTechnicianList();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        protected void btnReturnOpen_Click(object sender, EventArgs e)
        {
            Response.Redirect("/OpenProblems.aspx");
        }

        private Boolean ValidateFields()
        {
            Boolean blnValid = true;
            string strMessage = "";
            lblError.Text = "";
            if (txtResolution.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "You must enter a resolution; ";
            }
            if (txtHours.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "Amount of hours is required; ";
            }
            if (drpTech.SelectedIndex == 0)
            {
                blnValid = false;
                strMessage += "You must select a Technician; ";
            }
            lblError.Text = strMessage;
            return blnValid;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                intResNum++;
            }
        }
    }
}