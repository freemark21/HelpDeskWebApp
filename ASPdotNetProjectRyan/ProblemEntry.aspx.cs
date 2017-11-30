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
    public partial class ProblemEntry : System.Web.UI.Page
    {
        Int32 intProbNum = 1;
        Int32 intNewTicket;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session.Contents["NewTicketID"] != null)
                {
                    intNewTicket = Convert.ToInt32(Session.Contents["NewTicketID"]);
                    txtTicketNum.Text = intNewTicket.ToString();

                }
                LoadTechnicianList();
                LoadProductList();
            }
        }



        public void LoadTechnicianList()
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
                //add list of technicians (data table name/value) to drop down list
                drpTech.DataBind();
                dsData.Dispose();
            }
        }

        public void LoadProductList()
        {
            DataSet dsData = null;
            dsData = clsDatabase.GetProductList();
            if (dsData != null)
            {
                drpProductList.Items.Clear();
                drpProductList.DataSource = dsData.Tables[0];
                drpProductList.DataTextField = "ProductDesc";
                drpProductList.DataValueField = "ProductID";
                drpProductList.Items.Add(new ListItem("---Select Product---", "0"));
                //append new list item (above), making this the first item in the list
                drpProductList.AppendDataBoundItems = true;
                //add list of products (data table name/value) to drop down list
                drpProductList.DataBind();
                dsData.Dispose();
            }
        }

        private void ResetFields()
        {
            lblError.Text = "";
            txtProblem.Text = "";
            LoadProductList();
            LoadTechnicianList();
        }

        protected void btnReturnServ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServiceEvents.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                InsertProblem();
                txtProblemNum.Text = (Convert.ToInt32(txtProblemNum.Text) + 1).ToString();
                btnReturnServ.Enabled = true;
            }
        }

        private Boolean ValidateFields()
        {
            Boolean blnValid = true;
            string strMessage = "";
            lblError.Text = "";
            if (drpTech.SelectedIndex == 0)
            {
                blnValid = false;
                strMessage += "Technician is required; ";
            }
            if (drpProductList.SelectedIndex == 0)
            {
                blnValid = false;
                strMessage += "You must select a product; ";
            }
            if (txtProblem.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "A problem description is required; ";
            }
            lblError.Text = strMessage;
            return blnValid;
        }

        private void InsertProblem()
        {
            Int32 intRetValue;
            string strProblem = Convert.ToString(txtProblem.Text);
            Int32 intTechID = Convert.ToInt32(drpTech.SelectedValue);
            string strProdID = Convert.ToString(drpProductList.SelectedValue);

            intRetValue = clsDatabase.InsertProblem(intNewTicket, intProbNum, strProblem, intTechID, strProdID);
            if (intRetValue == 0)
            {
                lblError.Text = "Problem added successfully";
            }
            else
            {
                lblError.Text = "Error adding Problem";
            }
        }



    }
}