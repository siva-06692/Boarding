using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class ViewPendingMRFList : System.Web.UI.Page
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




                FillCompany();
                FillCompanyDepartment();
                
                string status = Session["status"].ToString();
                if (status == "S" || status == "J")
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
                    txtremark.Disabled = true;
                    dbostatus.Enabled = false;
                    btnsave.Disabled = true;
                }
                FillMRFDetail(Convert.ToInt32(txtmrfno.Text), Convert.ToInt32(lblmrfcompid.Text));
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
                CDO.mPrepared_By = Convert.ToInt32(Session["EmpCode"]);
                CDO.mPrepared_by_company_Id = Convert.ToInt32(Session["CompanyId"]);
                CDO.mRemarks = txtremark.Value;

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

            string status = Session["status"] != null ? Session["status"].ToString() : "";


            if (!string.IsNullOrEmpty(status))
            {
                Response.Redirect("ViewPendingList.aspx?status=" + status);
            }
            else
            {
                Response.Redirect("ViewPendingList.aspx");
            }



        }

    }
    
}