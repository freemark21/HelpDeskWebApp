﻿using System;
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
    public partial class Technicians : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTechnicianList();
            }
            
    }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        private void LoadTechnicianList()
        {
            DataSet dsData = null;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData != null)
            {
                drpTechID.Items.Clear();
                drpTechID.DataSource = dsData.Tables[0];
                drpTechID.DataTextField = "TechName";
                drpTechID.DataValueField = "TechnicianID";
                drpTechID.Items.Add(new ListItem("---Select Technician---", "0"));
                //append new list item (above), making this the first item in the list
                drpTechID.AppendDataBoundItems = true;
                //add list of products (data table name/value) to drop down list
                drpTechID.DataBind();
                dsData.Dispose();
            }
        }

        private void ShowTehnician()
        {

            int intTechID = Convert.ToInt32(drpTechID.SelectedValue);
            DataSet dsData = null;
            dsData = clsDatabase.GetTechnician(intTechID);
            if (intTechID < 1)
            {
                ResetFields();
            }
            else
            {
                txtLname.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                txtFname.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                txtDept.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                txtEmail.Text = dsData.Tables[0].Rows[0]["Email"].ToString();
                txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                txtHrRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMinit.Text = "";
                }
                else
                {
                    txtMinit.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }
            }
        }

        protected void drpTechID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTehnician();
        }

        private void ResetFields()
        {
            lblError.Text = "";
            txtDept.Text = "";
            txtEmail.Text = "";
            txtFname.Text = "";
            txtHrRate.Text = "";
            txtLname.Text = "";
            txtMinit.Text = "";
            txtPhone.Text = "";

            txtLname.Focus();
            LoadTechnicianList();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void InsertTechnician()
        {
            Int32 intRetValue;
            string strFname = txtFname.Text.ToString();
            string strMinit = txtMinit.Text.ToString();
            string strLname = txtLname.Text.ToString();
            string strEmail = txtEmail.Text.ToString();
            string strDept = txtDept.Text.ToString();
            string strPhone = Regex.Replace(txtPhone.Text, @"\s|\-|'|\(|\)|[A-Za-z]", "");
            decimal decHRate = Convert.ToDecimal(txtHrRate.Text);

            intRetValue = clsDatabase.InsertTechnician(strFname, strMinit, strLname, strEmail, strDept, decHRate, strPhone);
            if(intRetValue == 0)
            {
                lblError.Text = "Technician added successfully";
                LoadTechnicianList();
            }
            else
            {
                lblError.Text = "Error adding Technician";
            }
        }

        private Boolean ValidateFields()
        {
            Boolean blnValid = true;
            string strMessage = "";
            lblError.Text = "";
            if (txtFname.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "First name is a required field ";
            }
            if (txtLname.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "Last name is a required field ";
            }
            if (txtHrRate.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "Hourly rate is a required field ";
            }
            if (Regex.Replace(txtPhone.Text, @"\s|\-|'|\(|\)|[A-Za-z]", "").Trim().Length < 10)
            {
                blnValid = false;
                strMessage += "Phone is a required field ";
            }
            lblError.Text = strMessage;
            return blnValid;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void DeleteTechnician(string strTechID)
        {
            int intTechID = Convert.ToInt32(strTechID);
            clsDatabase.DeleteTechnician(intTechID);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTechnician(drpTechID.SelectedValue);
            ResetFields();
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {

            if (ValidateFields())
            {
                if(drpTechID.SelectedIndex == 0)
                {
                    InsertTechnician();
                }
                else
                {

                }
            }
            LoadTechnicianList();
        }
    }
}