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
        Int32 intNoCharge = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intResNum = 1;
                if(Session.Contents["TicketID"] != null && Session.Contents["IncidentNo"] != null)
                {
                    txtTicketNum.Text = Session.Contents["TicketID"].ToString();
                    txtProbNum.Text = Session.Contents["IncidentNo"].ToString();
                    txtResNum.Text = intResNum.ToString();
                }
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
            DateTime dtDateFixed;
            DateTime dtDateOnsite;
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
            if (txtDateFixed.Text != "")
            {
                if (DateTime.TryParse(txtDateFixed.Text, out dtDateFixed))
                {
                    blnValid = false;
                    strMessage += "Not a valid Fixed date; ";
                }
            }
            if(txtDateOnsite.Text != "")
            {
                if (DateTime.TryParse(txtDateOnsite.Text, out dtDateOnsite))
                {
                    blnValid = false;
                    strMessage += "Not a valid Onsite date; ";
                }
            }
            if (!IsValidNumber(txtHours.Text))
            {
                blnValid = false;
                strMessage += "Hours not a valid number";
            }
            if (!IsValidNumber(txtMileage.Text))
            {
                blnValid = false;
                strMessage += "Mileage not a valid number";
            }
            if (!IsValidNumber(txtMisc.Text))
            {
                blnValid = false;
                strMessage += "Misc not a valid number";
            }
            if (!IsValidNumber(txtSupplies.Text))
            {
                blnValid = false;
                strMessage += "Supplies not a valid number";
            }
            if (!IsValidNumber(txtCostMile.Text))
            {
                blnValid = false;
                strMessage += "Costmile not a valid number";
            }
            lblError.Text = strMessage;
            return blnValid;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                InsertResolution();
                ResetFields();
                txtResNum.Text = (Convert.ToInt32(txtResNum.Text) + 1).ToString();
            }
        }

        private void InsertResolution()
        {
            Int32 intRetValue;
            Int32 intTicketID = Convert.ToInt32(txtTicketNum.Text);
            Int32 intProbNum = Convert.ToInt32(txtProbNum.Text);
            Int32 intResNum = Convert.ToInt32(txtResNum.Text);
            string strResolution = Convert.ToString(txtResolution.Text);
            Int32 intTechID = Convert.ToInt32(drpTech.SelectedValue);

            intRetValue = clsDatabase.InsertProblemResolution(intTicketID, intProbNum, intResNum, strResolution, txtDateFixed.Text.ToString(), txtDateOnsite.Text.ToString(), intTechID, Convert.ToDecimal(txtHours.Text), txtMileage.Text.ToString(), txtCostMile.Text.ToString(), txtSupplies.Text.ToString(), txtMisc.Text.ToString(), intNoCharge);
            if (intRetValue == 0)
            {
                lblError.Text = "Resolution added successfully";
            }
            else
            {
                lblError.Text = "Error adding Resolution";
            }
        }

        public Boolean IsValidNumber(string strInput)
        {
            int intNumber;
            if (strInput == "")
            {

                return true;
            }
            else
            {
                if (int.TryParse(strInput, out intNumber))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        protected void chkNoCharge_CheckedChanged(object sender, EventArgs e)
        {
            intNoCharge = 0;
        }
    }
}