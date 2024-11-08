using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Boarding
{
    public partial class ViewApprovalMRFList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                requestdate.ReadOnly = true;
                txtmrfno.Text = Session["MRF_NO"].ToString();
                lblmrfcompid.Text = Session["MRF_Company_Id"].ToString();
                lblmrfno.Text = Session["MRF_NO"].ToString();
                txtmrfno.ReadOnly = true;
                cbodepartment.Enabled = false;
                
                cbocompany.SelectedValue = "0";
                cboreportcompname.SelectedValue = "0";
                cboreportempcode.SelectedValue = "0";
                cbodepartment.SelectedValue = "0";
                txtrecruitment.Value = "0";

                cbocompany1.SelectedValue = "0";
                cbocompany2.SelectedValue = "0";
                cbocompany3.SelectedValue = "0";
                cbocompany4.SelectedValue = "0";
                cbocompany5.SelectedValue = "0";

                cboempname1.SelectedValue = "0";
                cboempname2.SelectedValue = "0";
                cboempname3.SelectedValue = "0";
                cboempname4.SelectedValue = "0";
                cboempname5.SelectedValue = "0";

                txtEmpCode1.Text = "";
                txtEmpCode2.Text = "";
                txtEmpCode3.Text = "";
                txtEmpCode4.Text = "";
                txtEmpCode5.Text = "";

                txtdesignation1.Text = "";
                txtdesignation2.Text = "";
                txtdesignation3.Text = "";
                txtdesignation4.Text = "";
                txtdesignation5.Text = "";

                FillCompany();
                FillCompanyDepartment();
                string status = Session["status"].ToString();
                if (status == "S")
                {
                    txtpositiontitle.Disabled = true;
                    txtnoofvacancies.Enabled = false;
                    cboreportcompname.Enabled = false;
                    cboreportempcode.Enabled = false;
                    ddlhod_comp_id.Enabled = false;
                    ddlhodemp_code.Enabled = false;
                    cdorecruitment.Enabled = false;
                    txtrecruitment.Disabled = true;
                    txtqualification.Disabled = true;
                    txtExperiance.Enabled = false;
                    txttechexpertise.Disabled = true;
                    jobdescription.Disabled = true;
                    
                }
                FillMRFDetail(Convert.ToInt32(txtmrfno.Text), Convert.ToInt32(lblmrfcompid.Text));
                LoadTobeapproved();
            }
        }

        
        protected void FillCompany()
        {
            CommonBL BL = new CommonBL();
            cbocompany.DataSource = BL.ListCompany();
            cbocompany.DataTextField = "Company_Name";
            cbocompany.DataValueField = "Company_id";
            cbocompany.DataBind();

            BL = new CommonBL();
            cboreportcompname.DataSource = BL.ListCompany();
            cboreportcompname.DataTextField = "Company_Name";
            cboreportcompname.DataValueField = "Company_id";
            cboreportcompname.DataBind();

            BL = new CommonBL();
            ddlhod_comp_id.DataSource = BL.ListCompany();
            ddlhod_comp_id.DataTextField = "Company_Name";
            ddlhod_comp_id.DataValueField = "Company_id";
            ddlhod_comp_id.DataBind();
        }
        protected void FillCompanyDepartment()
        {
            CommonBL BL = new CommonBL();
            cbodepartment.DataSource = BL.ListDepartment(Convert.ToInt32(cbocompany.SelectedValue));
            cbodepartment.DataTextField = "Department_Name";
            cbodepartment.DataValueField = "Department_Id";
            cbodepartment.DataBind();
        }
        protected void FillReportingtoEmployees(int companyId)
        {
            CommonBL CBL = new CommonBL();
            cboreportempcode.DataSource = CBL.ListEmployee(companyId);
            cboreportempcode.DataTextField = "Employee_Name";
            cboreportempcode.DataValueField = "Employee_id";
            cboreportempcode.DataBind();
        }
        protected void FillHOD(int companyId)
        {
            CommonBL CBL = new CommonBL();
            ddlhodemp_code.DataSource = CBL.ListHOD(Convert.ToInt32(ddlhod_comp_id.SelectedValue));
            ddlhodemp_code.DataTextField = "Employee_Name";
            ddlhodemp_code.DataValueField = "Employee_id";
            ddlhodemp_code.DataBind();
        }

        protected void FillMRFDetail(int mrfno, int compid)
        {

            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetMRFNODetails(mrfno, compid);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtmrfno.Text = dr["MRF_No"].ToString();
                    requestdate.Text = dr["MRF_Date"].ToString();
                    cbocompany.SelectedValue = dr["Company_Id"].ToString();
                    cbocompany.Enabled = false;
                    txtpositiontitle.Value = dr["Position_title"].ToString();
                    txtnoofvacancies.Text = dr["No_of_vacancies"].ToString();
                    FillCompanyDepartment();
                    cbodepartment.SelectedValue = dr["Department_Id"].ToString();
                    cbodepartment.Enabled = false;
                    cboreportcompname.SelectedValue = dr["Reporting_to_Company_Id"].ToString();
                    FillReportingtoEmployees(Convert.ToInt32(cboreportcompname.SelectedValue));
                    cboreportempcode.SelectedValue = dr["Reporting_to_empcode"].ToString();
                    FillCompany();
                    ddlhod_comp_id.SelectedValue = dr["HOD_Company_Id"].ToString();
                    FillHOD(Convert.ToInt32(ddlhod_comp_id.SelectedValue));
                    ddlhodemp_code.SelectedValue = dr["HOD_Emp_Code"].ToString();
                    cdorecruitment.SelectedValue = dr["Reason_for_recruitment"].ToString();
                    txtrecruitment.Value = dr["replacement_emp_code"].ToString();
                    txtqualification.Value = dr["Qualification"].ToString();
                    txtExperiance.Text = dr["Experience_Years"].ToString();
                    txttechexpertise.Value = dr["Functional_expertise"].ToString();
                    jobdescription.Value = dr["Job_description"].ToString();
                    txtremark.Value = dr["Job_description"].ToString();
                    dbostatus.Text = dr["status"].ToString();
                    //txtvacancycode.Text = dr["vacancycode"].ToString();
                    LoadMRFLog(mrfno, compid);
                    
                    break;
                }
            }
            else
            {
                err.Text = "No Record Found !";
                return;
            }
        }

        protected void cbocompany_id_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void cbodept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbodepartment.Enabled = false;
        }
        protected void cboreport_compname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboreportcompname.SelectedValue == "0")
            {
                return;
            }

            cboreportempcode.Items.Clear();
            cboreportempcode.Items.Add(new ListItem("--Select Employee--", "0"));



            CommonBL CBL = new CommonBL();
            cboreportempcode.DataSource = CBL.ListEmployee(Convert.ToInt32(cboreportcompname.SelectedValue));
            cboreportempcode.DataTextField = "Employee_Name";
            cboreportempcode.DataValueField = "Employee_id";
            cboreportempcode.DataBind();

        }

        protected void cbofirst_level_approval_CompId_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlhod_comp_id.SelectedValue == "0")
            {
                return;
            }

            ddlhodemp_code.Items.Clear();
            ddlhodemp_code.Items.Add(new ListItem("--Select Employee--", "0"));

            CommonBL CBL = new CommonBL();
            ddlhodemp_code.DataSource = CBL.ListHOD(Convert.ToInt32(ddlhod_comp_id.SelectedValue));
            ddlhodemp_code.DataTextField = "Employee_Name";
            ddlhodemp_code.DataValueField = "Employee_id";
            ddlhodemp_code.DataBind();
        }

        protected void cbofirst_level_approval_empcode_SelectedIndexChanged(Object o, EventArgs e)
        {

        }


        protected void cdorecruitment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cdorecruitment.SelectedValue == "R")
            {
                txtrecruitment.Disabled = false;
            }
            else
            {

                txtrecruitment.Value = "0";
                txtrecruitment.Disabled = true;
            }


        }
        protected void cboreport_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void LoadMRFLog(int mrfno, int compid)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetMRFLog(mrfno, compid);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        
        protected void LoadTobeapproved()
        {
            CommonBL BL = new CommonBL();
            cbocompany1.DataSource = BL.ListCompany();
            cbocompany1.DataTextField = "Company_Name";
            cbocompany1.DataValueField = "Company_id";
            cbocompany1.DataBind();

            BL = new CommonBL();
            cbocompany2.DataSource = BL.ListCompany();
            cbocompany2.DataTextField = "Company_Name";
            cbocompany2.DataValueField = "Company_id";
            cbocompany2.DataBind();

            BL = new CommonBL();
            cbocompany3.DataSource = BL.ListCompany();
            cbocompany3.DataTextField = "Company_Name";
            cbocompany3.DataValueField = "Company_id";
            cbocompany3.DataBind();

            BL = new CommonBL();
            cbocompany4.DataSource = BL.ListCompany();
            cbocompany4.DataTextField = "Company_Name";
            cbocompany4.DataValueField = "Company_id";
            cbocompany4.DataBind();

            BL = new CommonBL();
            cbocompany5.DataSource = BL.ListCompany();
            cbocompany5.DataTextField = "Company_Name";
            cbocompany5.DataValueField = "Company_id";
            cbocompany5.DataBind();

        }
        protected void cbocompany1_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboempname1.Items.Clear();
            cboempname1.Items.Add(new ListItem("--Select Employee--", "0"));
            CommonBL CBL = new CommonBL();
            cboempname1.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany1.SelectedValue));
            cboempname1.DataTextField = "Employee_Name";
            cboempname1.DataValueField = "Employee_id";
            cboempname1.DataBind();

        }
        protected void cbocompany2_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboempname2.Items.Clear();
            cboempname2.Items.Add(new ListItem("--Select Employee--", "0"));
            CommonBL CBL = new CommonBL();
            cboempname2.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany2.SelectedValue));
            cboempname2.DataTextField = "Employee_Name";
            cboempname2.DataValueField = "Employee_id";
            cboempname2.DataBind();
        }
        protected void cbocompany3_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboempname3.Items.Clear();
            cboempname3.Items.Add(new ListItem("--Select Employee--", "0"));
            CommonBL CBL = new CommonBL();
            cboempname3.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany3.SelectedValue));
            cboempname3.DataTextField = "Employee_Name";
            cboempname3.DataValueField = "Employee_id";
            cboempname3.DataBind();
        }

        protected void cbocompany4_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboempname4.Items.Clear();
            cboempname4.Items.Add(new ListItem("--Select Employee--", "0"));
            CommonBL CBL = new CommonBL();
            cboempname4.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany4.SelectedValue));
            cboempname4.DataTextField = "Employee_Name";
            cboempname4.DataValueField = "Employee_id";
            cboempname4.DataBind();
        }
        protected void cbocompany5_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboempname5.Items.Clear();
            cboempname5.Items.Add(new ListItem("--Select Employee--", "0"));
            CommonBL CBL = new CommonBL();
            cboempname5.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany5.SelectedValue));
            cboempname5.DataTextField = "Employee_Name";
            cboempname5.DataValueField = "Employee_id";
            cboempname5.DataBind();
        }

        protected void cboempname1_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetDesignation(Convert.ToInt32(cbocompany1.SelectedValue), (cboempname1.SelectedItem.Text));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtEmpCode1.Text = dr["Employee_Id"].ToString();
                    txtdesignation1.Text = dr["Designation_Name"].ToString();
                    break;
                }
            }
        }
        protected void cboempname2_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetDesignation(Convert.ToInt32(cbocompany2.SelectedValue), (cboempname2.SelectedItem.Text));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtEmpCode2.Text = dr["Employee_Id"].ToString();
                    txtdesignation2.Text = dr["Designation_Name"].ToString();
                    break;
                }
            }

        }
        protected void cboempname3_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetDesignation(Convert.ToInt32(cbocompany3.SelectedValue), (cboempname3.SelectedItem.Text));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtEmpCode3.Text = dr["Employee_Id"].ToString();
                    txtdesignation3.Text = dr["Designation_Name"].ToString();
                    break;
                }
            }

        }
        protected void cboempname4_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetDesignation(Convert.ToInt32(cbocompany4.SelectedValue), (cboempname4.SelectedItem.Text));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtEmpCode4.Text = dr["Employee_Id"].ToString();
                    txtdesignation4.Text = dr["Designation_Name"].ToString();
                    break;
                }
            }

        }
        protected void cboempname5_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonBL CBL = new CommonBL();
            DataTable dt = CBL.GetDesignation(Convert.ToInt32(cbocompany5.SelectedValue), (cboempname5.SelectedItem.Text));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtEmpCode5.Text = dr["Employee_Id"].ToString();
                    txtdesignation5.Text = dr["Designation_Name"].ToString();
                    break;
                }
            }
        }


        protected void ddlcompany_id_SelectedIndexChanged(object sender, EventArgs e)
         {
            CommonBL CBL = new CommonBL();
            cboreportempcode.DataSource = CBL.ListEmployee(Convert.ToInt32(cbocompany.SelectedValue));
            cboreportempcode.DataTextField = "Employee_Name";
            cboreportempcode.DataValueField = "Employee_id";
            cboreportempcode.DataBind();
        }
        protected void ddlemp_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       

        protected void SaveApproverDetails()
        {
           
                CommonBL CBL = new CommonBL();
                int result;

            int SafeConvertToInt(string value)
                {
                    return int.TryParse(value, out result) ? result : 0;
                }

                int mrfNo = SafeConvertToInt(txtmrfno.Text);
                int companyId = SafeConvertToInt(cbocompany.SelectedValue);
                int companyId1 = SafeConvertToInt(cbocompany1.SelectedValue);
                int empCode1 = SafeConvertToInt(txtEmpCode1.Text);
                int companyId2 = SafeConvertToInt(cbocompany2.SelectedValue);
                int empCode2 = SafeConvertToInt(txtEmpCode2.Text);
                int companyId3 = SafeConvertToInt(cbocompany3.SelectedValue);
                int empCode3 = SafeConvertToInt(txtEmpCode3.Text);
                int companyId4 = SafeConvertToInt(cbocompany4.SelectedValue);
                int empCode4 = SafeConvertToInt(txtEmpCode4.Text);
                int companyId5 = SafeConvertToInt(cbocompany5.SelectedValue);
                int empCode5 = SafeConvertToInt(txtEmpCode5.Text);

                result = CBL.MRFApproverDetails(mrfNo, companyId, companyId1, empCode1,
                                                    companyId2, empCode2, companyId3, empCode3,
                                                    companyId4, empCode4, companyId5, empCode5);
            

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtpositiontitle.Value == "")
                {
                    err.Text = "Enter Position!";
                    return;
                }
                if (txtnoofvacancies.Text == "")
                {
                    err.Text = "Enter Vacancies!";
                    return;
                }
                if (cboreportcompname.SelectedValue == "0")
                {
                    err.Text = "Select Company!";
                    return;
                }
                if (cbodepartment.SelectedValue == "0")
                {
                    err.Text = "Select Department!";
                    return;
                }
                if (cboreportempcode.SelectedValue == "0")
                {
                    err.Text = "Select EmpCode!";
                    return;
                }
                if (ddlhod_comp_id.SelectedValue == "")
                {
                    err.Text = "Enter HOD_Company_ID!";
                    return;
                }
                if (ddlhodemp_code.SelectedValue == "")
                {
                    err.Text = "HOD_Empcode!";
                    return;
                }
                if (cdorecruitment.SelectedValue == "0")
                {
                    err.Text = "Select Reason!";
                    return;
                }
                if (txtqualification.Value == "")
                {
                    err.Text = "Enter Qualification!";
                    return;
                }
                if (txtExperiance.Text == "")
                {
                    err.Text = "Enter Experience!";
                    return;
                }
                if (txttechexpertise.Value == "")
                {
                    err.Text = "Enter  Technical/Functional Expertise!";
                    return;
                }
                if (jobdescription.Value == "")
                {
                    err.Text = "Enter Brief Job Description!";
                    return;
                }
                if (dbostatus.SelectedValue == "0")
                {
                    err.Text = "Select Status!";
                    return;
                }
                if (txtremark.Value == "")
                {
                    err.Text = "Enter Remarks!";
                    return;
                }
                if(txtvacancycode.Text == "")
                {
                    err.Text = "Enter Vacancy!";
                    return;
                }

                MRFBO CDO = new MRFBO();
                CDO.mMRFno = Convert.ToInt32(Session["MRF_NO"].ToString());
                CDO.mCompany_Id = Convert.ToInt32(Session["CompanyId"]);
                CDO.mPosition_title = txtpositiontitle.Value;
                CDO.mNo_of_vacancies = Convert.ToInt32(txtnoofvacancies.Text);
                CDO.mDepartment_Id = Convert.ToInt32(Session["Department_Id"]);
                CDO.mReporting_to_Company_Id = Convert.ToInt32(cboreportcompname.SelectedValue);
                CDO.mReporting_to_empcode = Convert.ToInt32(cboreportempcode.Text);
                CDO.mHOD_Company_Id = Convert.ToInt32(ddlhod_comp_id.SelectedValue);
                CDO.mHOD_Emp_Code = Convert.ToInt32(ddlhodemp_code.SelectedValue);
                CDO.mReason_for_recruitment = cdorecruitment.SelectedValue;
                CDO.mreplacement_emp_code = Convert.ToInt32(txtrecruitment.Value);
                CDO.mQualification = txtqualification.Value;
                CDO.mExperience_Years = Convert.ToDouble(txtExperiance.Text);
                CDO.mFunctional_expertise = txttechexpertise.Value;
                CDO.mJob_description = jobdescription.Value;
                CDO.mstatus = dbostatus.Text;
                CDO.mvacancycode = Convert.ToInt32(txtvacancycode.Text);
                CDO.mPrepared_By = Convert.ToInt32(Session["EmpCode"]);
                CDO.mPrepared_by_company_Id = Convert.ToInt32(Session["CompanyId"]);
                CDO.mRemarks = txtremark.Value;
                SaveApproverDetails();

                TransactionBL CBL = new TransactionBL();
                int result = CBL.UpdateMRF(CDO);


                if (result != 0)
                {
                    string message = "MRF No- " + result.ToString() + " Updated successfully";

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<Script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    LoadMRFLog(Convert.ToInt32(txtmrfno.Text), Convert.ToInt32(lblmrfcompid.Text));
                    return;
                }
                else
                {
                    err.Text = "Error occured Contact Administrator!";
                    return;
                }
            }
            catch (Exception ex)
            {
                err.Text = ex.Message.ToString();
                return;

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


        }


        protected void Reset_Click(object sender, EventArgs e)
{
    string status = Session["status"] != null ? Session["status"].ToString() : string.Empty;
    Response.Redirect("ViewApprovalList.aspx" + (!string.IsNullOrEmpty(status) ? "?status=" + status : ""));
}

    }
}
    