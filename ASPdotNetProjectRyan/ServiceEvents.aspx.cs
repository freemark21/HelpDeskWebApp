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
            txtEventDate.Text = DateTime.Now.ToString("G");
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

        private Boolean ValidateFields()
        {
            Boolean blnValid = true;
            string strMessage = "";
            lblError.Text = "";
            if (txtContact.Text.Trim().Length < 1)
            {
                blnValid = false;
                strMessage += "A contact is required; ";
            }
            if (Regex.Replace(txtPhone.Text, @"\s|\-|'|\(|\)|[A-Za-z]", "").Trim().Length < 10)
            {
                blnValid = false;
                strMessage += "A Phone number is required; ";
            }
            if(drpClientID.SelectedIndex == 0)
            {
                blnValid = false;
                strMessage += "You must select a client; ";
            }
            lblError.Text = strMessage;
            return blnValid;
        }

        private void ResetFields()
        {
            lblError.Text = "";
            txtContact.Text = "";
            txtPhone.Text = "";
            txtContact.Focus();
            LoadClientList();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                InsertServiceEvent();
                Response.Redirect("/ProblemEntry.aspx");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void InsertServiceEvent()
        {
            Int32 intNewTicket;
            Int32 intClientID = Convert.ToInt32(drpClientID.SelectedValue);
            string strContact = txtContact.Text.ToString();
            string strPhone = Regex.Replace(txtPhone.Text, @"\s|\-|'|\(|\)|[A-Za-z]", "");

            intNewTicket = clsDatabase.InsertServiceEvent(intClientID, DateTime.Now, strPhone, strContact);
            
            if (intNewTicket == -1)
            {
                lblError.Text = "Error adding Service Event";
            }
            else
            {
                Session.Contents["NewTicketID"] = intNewTicket;
                lblError.Text = "Service Event added";
            }
        }






    }
}