using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace ASPdotNetProjectRyan
{
    public class clsDatabase
    {
        //AcquireConnection to database ServiceCenter
        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();
                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //Get Technician list
        public static DataSet GetTechnicianList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand()
                {
                    //below is simplified, was cmdSQL.Connection = cnSQL; etc.
                    Connection = cnSQL,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "uspGetTechnicianList"
                };
                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();

                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetTechnician(int TechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            if (TechID < 1)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand()
                {
                    //below 3 lines are simplified, could be cmdSQL.Connection = cnSQL; etc.
                    Connection = cnSQL,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "uspGetTechnicianByID"
                };

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = TechID;


                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();

                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }


        public static int InsertTechnician(string strFname, string strMinit, string strLname, string strEmail, string strDept, decimal decHRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;


                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFname;


                cmdSQL.Parameters.Add(new SqlParameter("@Minit", SqlDbType.NChar));
                cmdSQL.Parameters["@Minit"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Minit"].Value = strMinit;

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLname;

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EMail"].Value = strEmail;

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Dept"].Value = strDept;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.SmallMoney));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = decHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}