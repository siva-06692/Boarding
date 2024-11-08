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
    public class CommonDA
    {

        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BoardingConnectionString"].ConnectionString.ToString());
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable dt = new DataTable();
        private SqlTransaction objtrans = null;
        public int ValidateUser(UserBO ubo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Validateuser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Id", ubo.mUserId);
                cmd.Parameters.AddWithValue("@Password", ubo.mPassword);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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
        public DataTable GetLoginUser(UserBO ubo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetLoginUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_Id", ubo.mUserId);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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

        public DataTable ListCompany()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ListCompany", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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

        public int CheckDesignationNameExists(DesignationBO udo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckDesignationNameExists", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", udo.mCompany_Id);
                cmd.Parameters.AddWithValue("@Designation_Name", udo.mDesignation_Name);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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
        public DataTable ListEmployee(int compid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ListEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", compid);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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

        public DataTable ListHOD(int compid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ListHOD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", compid);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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


        public int CheckDepartmentNameExists(DepartmentBO dbo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckDepartmentNameExists", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Department_Name", dbo.mDepartment_Name);
                cmd.Parameters.AddWithValue("@Department_Company_Id", dbo.mDepartment_Company_Id);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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
        public DataTable ListDepartment(int compid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ListDepartment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Id", compid);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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

        public int ReturnStatusCount(string status, int prepared_by, int prepared_by_Company_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ReturnStatusCount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Prepared_by", prepared_by);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", prepared_by_Company_id);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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





        public DataTable GetMRFList(string status, int prepared_by, int prepared_by_company_Id)

        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetMRFList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Prepared_by", prepared_by);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", prepared_by_company_Id);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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
        public DataTable GetMRFNODetails(int MRF_NO, int compid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetMRFNODetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MRF_NO", MRF_NO);
                cmd.Parameters.AddWithValue("@Company_Id", compid);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;
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

        public int ReturnPendingCount(string status, int To_be_Approved_by_emp_code, int To_be_Approved_by_Company_Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ReturnPendingCount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@To_be_Approved_by_emp_code", To_be_Approved_by_emp_code);
                cmd.Parameters.AddWithValue("@To_be_Approved_by_Company_Id", To_be_Approved_by_Company_Id);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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

        public DataTable GetPendingMRFList(string status, int To_be_Approved_by_Company_Id, int To_be_Approved_by_emp_code)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetPendingMRFList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@To_be_Approved_by_Company_Id", To_be_Approved_by_Company_Id);
                cmd.Parameters.AddWithValue("@To_be_Approved_by_emp_code", To_be_Approved_by_emp_code);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;
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
        public DataTable GetMRFLog(int MRF_NO, int compid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetMRFLog", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MRF_NO", MRF_NO);
                cmd.Parameters.AddWithValue("@Company_Id", compid);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;
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



        public int ReturnApprovedCount(string status, int prepared_by, int prepared_by_company_Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ReturnApprovedCount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@prepared_by", prepared_by);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", prepared_by_company_Id);
                cmd.Connection = conn;
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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

        public DataTable GetApprovedMRFList(string status, int prepared_by_company_Id, int prepared_by)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetApprovedMRFList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@prepared_by_company_Id", prepared_by_company_Id);
                cmd.Parameters.AddWithValue("@Prepared_By", prepared_by);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;
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

        public DataTable GetDesignation(int companyId, string EmpName)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("GetDesignation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

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

        public int MRFApproverDetails(int MRFNo, int MRFCompanyId, int ApproverCompanyId1, int ApproverEmpCode1, int ApproverCompanyId2, int ApproverEmpCode2, int ApproverCompanyId3, int ApproverEmpCode3, int ApproverCompanyId4, int ApproverEmpCode4, int ApproverCompanyId5, int ApproverEmpCode5)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SaveMRFApproverDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MRFNo", MRFNo);
                cmd.Parameters.AddWithValue("@MRFCompanyId", MRFCompanyId);
                cmd.Parameters.AddWithValue("@ApproverCompanyId1", ApproverCompanyId1);
                cmd.Parameters.AddWithValue("@ApproverEmpCode1", ApproverEmpCode1);
                cmd.Parameters.AddWithValue("@ApproverCompanyId2", ApproverCompanyId2);
                cmd.Parameters.AddWithValue("@ApproverEmpCode2", ApproverEmpCode2);
                cmd.Parameters.AddWithValue("@ApproverCompanyId3", ApproverCompanyId3);
                cmd.Parameters.AddWithValue("@ApproverEmpCode3", ApproverEmpCode3);
                cmd.Parameters.AddWithValue("@ApproverCompanyId4", ApproverCompanyId4);
                cmd.Parameters.AddWithValue("@ApproverEmpCode4", ApproverEmpCode4);
                cmd.Parameters.AddWithValue("@ApproverCompanyId5", ApproverCompanyId5);
                cmd.Parameters.AddWithValue("@ApproverEmpCode5", ApproverEmpCode5);
                cmd.Connection = conn;
                conn.Open();
                objtrans = conn.BeginTransaction();
                cmd.Transaction = objtrans;
                int result = Convert.ToInt32(cmd.ExecuteScalar());
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
        public List<string> GetKeywords(string category)
        {
            List<string> keywords = new List<string>();
            string query = "SELECT Keyword FROM KeywordPatterns WHERE Category = @Category";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            keywords.Add(reader["Keyword"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving keywords", ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return keywords;
        }

        public int SaveCandidateDetails(ResumeDetailsBO RDO, string resumeFileName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SaveCandidateDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@candidateid", SqlDbType.Int);
                cmd.Parameters["@candidateid"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Name", RDO.mname);
                cmd.Parameters.AddWithValue("@DOB", RDO.mDOB);
                cmd.Parameters.AddWithValue("@Phone", RDO.mPhone);
                cmd.Parameters.AddWithValue("@Email", RDO.mEmail);
                cmd.Parameters.AddWithValue("@Experience", RDO.mExperience);
                cmd.Parameters.AddWithValue("@Skills", RDO.mSkills);
                cmd.Parameters.AddWithValue("@Qualification", RDO.mqualification);
                cmd.Parameters.AddWithValue("@ResumeFileName", resumeFileName ?? (object)DBNull.Value);



                conn.Open();
                objtrans = conn.BeginTransaction();
                cmd.Transaction = objtrans;

                int result = cmd.ExecuteNonQuery();
                int candidateid = Convert.ToInt32(cmd.Parameters["@candidateid"].Value);

                objtrans.Commit();
                objtrans.Dispose();
                objtrans = null;

                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return candidateid;

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
        public void UpdateResumeFileName(int candidateId, string resumeFileName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateResumeFileName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CandidateID", candidateId);
                cmd.Parameters.AddWithValue("@ResumeFileName", resumeFileName);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
                throw;
            }
        }
        public DataTable SearchResumes(int? minAge, int? maxAge, string qualification, string skills, string experience, bool includeBlocked)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SearchResumes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MinAge", minAge.HasValue ? (object)minAge.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxAge", maxAge.HasValue ? (object)maxAge.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Qualification", string.IsNullOrEmpty(qualification) ? (object)DBNull.Value : qualification);
                cmd.Parameters.AddWithValue("@Skills", string.IsNullOrEmpty(skills) ? (object)DBNull.Value : skills);
                cmd.Parameters.AddWithValue("@Experience", string.IsNullOrEmpty(experience) ? (object)DBNull.Value : experience);
                cmd.Parameters.AddWithValue("@IncludeBlocked", includeBlocked);
                cmd.Connection = conn;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving resumes: " + ex.Message);
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

        public DataTable GetCandidatesByskill(string skills)
        {

            SqlCommand cmd = new SqlCommand("SearchCandidates", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Skills", skills);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void BlockCandidate(int candidateId, string reason, string prepared_by)
        {


            SqlCommand cmd = new SqlCommand("BlockResume", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CandidateId", candidateId);
            cmd.Parameters.AddWithValue("@Blockedby", prepared_by);
            cmd.Parameters.AddWithValue("@Reason", reason);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void BlockUpCandidate(int candidateId, DateTime blockedUntil, string reason, string prepared_by)
        {

            SqlCommand cmd = new SqlCommand("BlockResume", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CandidateId", candidateId);
            cmd.Parameters.AddWithValue("@BlockedUntil", blockedUntil);
            cmd.Parameters.AddWithValue("Blockedby", prepared_by);
            cmd.Parameters.AddWithValue("@Reason", reason);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public List<Resume> GetResumes()
        {
            var resumes = new List<Resume>();
            using (var cmd = new SqlCommand("GetResumes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resumes.Add(new Resume
                        {
                            ResumeID = (int)reader["ResumeID"],
                            ResumeText = reader["ResumeText"].ToString()
                        });
                    }
                }
            }
            return resumes;
        }


    }
}








          