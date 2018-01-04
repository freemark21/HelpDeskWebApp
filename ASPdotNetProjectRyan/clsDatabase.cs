﻿using System;
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


        public static int InsertTechnician(string strFname, string strMinit, string strLname, string strEmail, string strDept, decimal decHRate, string strPhone)
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
                if (string.IsNullOrWhiteSpace(strMinit))
                {
                    cmdSQL.Parameters["@Minit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Minit"].Value = strMinit;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLname;

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strEmail))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEmail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strDept))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDept;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.SmallMoney));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = decHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;


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

        public static Int32 DeleteTechnician(int intTechID)
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
                cmdSQL.CommandText = "uspDeleteTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = intTechID;

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

        public static Int32 UpdateTechnician(int intTechID, string strFname, string strMinit, string strLname, string strEmail, string strDept, decimal decHRate, string strPhone)
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
                cmdSQL.CommandText = "uspUpdateTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = intTechID;


                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFname;


                cmdSQL.Parameters.Add(new SqlParameter("@Minit", SqlDbType.NChar));
                cmdSQL.Parameters["@Minit"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMinit))
                {
                    cmdSQL.Parameters["@Minit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Minit"].Value = strMinit;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLname;

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strEmail))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEmail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strDept))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDept;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.SmallMoney));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = decHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;


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

        public static Int32 InsertServiceEvent(Int32 intClientID, DateTime dtEventDate, String strPhone, String strContact)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;
            Int32 intNewTicket = 0;

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
                cmdSQL.CommandText = "uspInsertServiceEvent";

                cmdSQL.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
                cmdSQL.Parameters["@ClientID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ClientID"].Value = intClientID;


                cmdSQL.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                cmdSQL.Parameters["@EventDate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EventDate"].Value = dtEventDate;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NChar, 30));
                cmdSQL.Parameters["@Contact"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Contact"].Value = strContact;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTicketID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTicketID"].Direction = ParameterDirection.Output;

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
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

                if (!blnErrorOccurred)
                {
                    try
                    {
                        intNewTicket = Convert.ToInt32(cmdSQL.Parameters["@NewTicketID"].Value);
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                }
                cmdSQL.Parameters.Clear();
                cmdSQL.Dispose();
            }
                if (blnErrorOccurred)
                {
                    return -1;
                }
                else
                {
                    return intNewTicket;
                }
        }

        public static DataSet GetClientList()
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
                    CommandText = "uspGetClientList"
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
        public static DataSet GetProductList()
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
                    CommandText = "uspGetProductList"
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

        public static int InsertProblem(int intNewTicket, int intProbNum,string strProblem, int intTechID, string strProdId)
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
                cmdSQL.CommandText = "uspInsertProblem";


                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intNewTicket;


                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = intProbNum;


                cmdSQL.Parameters.Add(new SqlParameter("@ProbDesc", SqlDbType.NVarChar));
                cmdSQL.Parameters["@ProbDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProbDesc"].Value = strProblem;

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar));
                cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProductID"].Value = strProdId;


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

        public static DataSet GetOpenProblems()
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
                    CommandText = "uspGetOpenProblems"
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

        public static int InsertProblemResolution(int intTicketID, int intIncidentNo, int intResNo, string strResolution, string dtDateFix, string dtDateOnSite, int intTechID, decimal decHours, string decMileage, string decCostMiles, string decSupplies, string decMisc, int intNoCharge)
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
                cmdSQL.CommandText = "uspInsertResolution";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intTicketID;


                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = intIncidentNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ResNo", SqlDbType.Int));
                cmdSQL.Parameters["@ResNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResNo"].Value = intResNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ResDesc", SqlDbType.NVarChar));
                cmdSQL.Parameters["@ResDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResDesc"].Value = strResolution;


                cmdSQL.Parameters.Add(new SqlParameter("@DateFix", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateFix"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(dtDateFix))
                {
                    cmdSQL.Parameters["@DateFix"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Datefix"].Value = dtDateFix;
                }


                cmdSQL.Parameters.Add(new SqlParameter("@DateOnsite", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateOnsite"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(dtDateOnSite))
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = dtDateOnSite;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;


                cmdSQL.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Decimal));
                cmdSQL.Parameters["@Hours"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Hours"].Value = decHours;


                cmdSQL.Parameters.Add(new SqlParameter("@Mileage", SqlDbType.Decimal));
                cmdSQL.Parameters["@Mileage"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decMileage))
                {
                    cmdSQL.Parameters["@Mileage"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Mileage"].Value = decMileage;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@CostMiles", SqlDbType.Money));
                cmdSQL.Parameters["@CostMiles"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decCostMiles))
                {
                    cmdSQL.Parameters["@CostMiles"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@CostMiles"].Value = decCostMiles;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Supplies", SqlDbType.Money));
                cmdSQL.Parameters["@Supplies"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decSupplies))
                {
                    cmdSQL.Parameters["@Supplies"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Supplies"].Value = decSupplies;
                }


                cmdSQL.Parameters.Add(new SqlParameter("@Misc", SqlDbType.Money));
                cmdSQL.Parameters["@Misc"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decMisc))
                {
                    cmdSQL.Parameters["@Misc"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Misc"].Value = decMisc;
                }

                // need NoCharge parameter


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

        public static DataSet GetProblemByTicket(int intTicketID)
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
            if (intTicketID < 1)
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
                    CommandText = "uspGetOpenProblemsByTicket"
                };

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intTicketID;


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

        public static DataSet GetReport(string strReportCalled)
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
                    CommandText = strReportCalled
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

    }
}