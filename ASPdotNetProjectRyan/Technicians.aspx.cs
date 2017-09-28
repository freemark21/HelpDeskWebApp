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
                drpTechID.DataSource = dsData.Tables[0];
                drpTechID.DataTextField = "TechnicianID";
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
            txtDept.Text = "";
            txtEmail.Text = "";
            txtFname.Text = "";
            txtHrRate.Text = "";
            txtLname.Text = "";
            txtMinit.Text = "";
            txtPhone.Text = "";

            txtLname.Focus();
        }
    }
}