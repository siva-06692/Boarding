using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace DataAccess
{
    public class TransactionDA
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BoardingConnectionString"].ConnectionString.ToString());
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable dt = new DataTable();
        private SqlTransaction objtrans = null;
        public int InsertDesignation(DesignationBO udo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertDesignation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", udo.mCompany_Id);
                cmd.Parameters.AddWithValue("@Designation_Name", udo.mDesignation_Name);
                cmd.Connection = conn;
                conn.Open();

                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return result;

            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int InsertDepartment(DepartmentBO dbo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertDepartment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Department_Company_Id", dbo.mDepartment_Company_Id);
                cmd.Parameters.AddWithValue("@Department_Name", dbo.mDepartment_Name);
                cmd.Parameters.AddWithValue("@Department_head_Company_id", dbo.mDepartment_Head_Company_id);
                cmd.Parameters.AddWithValue("@Department_head_emp_code", dbo.mDepartment_head_emp_code);
                cmd.Connection = conn;
                conn.Open();

                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return result;

            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }


        }
        public int InsertMRFDetails(MRFBO mrf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertMRFDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", mrf.mCompany_Id);
                cmd.Parameters.Add("@Mrfno", SqlDbType.Int);
                cmd.Parameters["@Mrfno"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Position_title", mrf.mPosition_title);
                cmd.Parameters.AddWithValue("@No_of_vacancies", mrf.mNo_of_vacancies);
                cmd.Parameters.AddWithValue("@Department_Id", mrf.mDepartment_Id);
                cmd.Parameters.AddWithValue("@Reporting_to_Company_Id", mrf.mReporting_to_Company_Id);
                cmd.Parameters.AddWithValue("@Reporting_to_empcode", mrf.mReporting_to_empcode);
                cmd.Parameters.AddWithValue("@Hod_Company_Id", mrf.mHOD_Company_Id);
                cmd.Parameters.AddWithValue("@HOD_Emp_Code", mrf.mHOD_Emp_Code);
                cmd.Parameters.AddWithValue("@Reason_for_recruitment", mrf.mReason_for_recruitment);
                cmd.Parameters.AddWithValue("@replacement_emp_code", mrf.mreplacement_emp_code);
                cmd.Parameters.AddWithValue("@Qualification", mrf.mQualification);
                cmd.Parameters.AddWithValue("@Experience_Years", mrf.mExperience_Years);
                cmd.Parameters.AddWithValue("@Functional_expertise", mrf.mFunctional_expertise);
                cmd.Parameters.AddWithValue("@Job_description", mrf.mJob_description);
                cmd.Parameters.AddWithValue("@Status", mrf.mstatus);
                cmd.Parameters.AddWithValue("@prepared_by", mrf.mPrepared_By);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", mrf.mPrepared_by_company_Id);
                cmd.Parameters.AddWithValue("@Remarks", mrf.mRemarks);
                cmd.Parameters.AddWithValue("@VacancyCode",mrf.mvacancycode);
                cmd.Connection = conn;
                conn.Open();
                objtrans = conn.BeginTransaction();
                cmd.Transaction = objtrans;
                int result = cmd.ExecuteNonQuery();
                int mrfno = Convert.ToInt32(cmd.Parameters["@Mrfno"].Value);
                objtrans.Commit();
                objtrans.Dispose();
                objtrans = null;
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                if (result != 0)
                {
                    return mrfno;
                }
                else
                {
                    return result;
                }


            }
            catch
            {
                if (objtrans != null)
                {
                    objtrans.Rollback();
                    objtrans.Dispose();
                    objtrans = null;
                }


                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int UpdateMRF(MRFBO mrf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateMRF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MRF_No", mrf.mMRFno); 
                cmd.Parameters.AddWithValue("@Company_Id", mrf.mCompany_Id);
                cmd.Parameters.AddWithValue("@Position_title", mrf.mPosition_title);
                cmd.Parameters.AddWithValue("@No_of_vacancies", mrf.mNo_of_vacancies);
                cmd.Parameters.AddWithValue("@Department_Id", mrf.mDepartment_Id);
                cmd.Parameters.AddWithValue("@Reporting_to_Company_Id", mrf.mReporting_to_Company_Id);
                cmd.Parameters.AddWithValue("@Reporting_to_empcode", mrf.mReporting_to_empcode);
                cmd.Parameters.AddWithValue("@Hod_Company_Id", mrf.mHOD_Company_Id);
                cmd.Parameters.AddWithValue("@HOD_Emp_Code", mrf.mHOD_Emp_Code);
                cmd.Parameters.AddWithValue("@Reason_for_recruitment", mrf.mReason_for_recruitment);
                cmd.Parameters.AddWithValue("@replacement_emp_code", mrf.mreplacement_emp_code);
                cmd.Parameters.AddWithValue("@Qualification", mrf.mQualification);
                cmd.Parameters.AddWithValue("@Experience_Years", mrf.mExperience_Years);
                cmd.Parameters.AddWithValue("@Functional_expertise", mrf.mFunctional_expertise);
                cmd.Parameters.AddWithValue("@Job_description", mrf.mJob_description);
                cmd.Parameters.AddWithValue("@Status", mrf.mstatus);
                cmd.Parameters.AddWithValue("@prepared_by", mrf.mPrepared_By);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", mrf.mPrepared_by_company_Id);
                cmd.Parameters.AddWithValue("@Remarks", mrf.mRemarks);
                cmd.Connection = conn;
                conn.Open();
                objtrans = conn.BeginTransaction();
                cmd.Transaction = objtrans;
                int result = cmd.ExecuteNonQuery();
                objtrans.Commit();
                objtrans.Dispose();
                objtrans = null;
                cmd.Dispose();
                conn.Close();
                conn.Dispose();             
                return result;
            }
            catch
            {
                if (objtrans != null)
                {
                    objtrans.Rollback();
                    objtrans.Dispose();
                    objtrans = null;
                }


                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }



    } 

    }

