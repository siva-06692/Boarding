using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class MRF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                requestdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                requestdate.ReadOnly = true;

                cbocompany.SelectedValue = "0";
                cboreportcompname.SelectedValue = "0";
                cboreportempcode.SelectedValue = "0";
                cbodepartment.SelectedValue = "0";
                lblrecruitment.Value = "0";
                FillCompany();

                cbocompany.SelectedValue = Session["CompanyId"].ToString();
                cbocompany.Enabled = false;

                if (Session["CompanyId"] != null)
                {
                    FillCompanyDepartment();
                    string yy = Session["Department_Id"].ToString();
                    cbodepartment.SelectedValue = Session["Department_Id"].ToString();
                    cbodepartment.Enabled = false;
                }
            }
        }

        protected void Valuesclear()
        {
            
            txtpositiontitle.Value = "";
            txtnoofvacancies.Text = "";
            
            cboreportcompname.SelectedValue = "0";
            cboreportempcode.SelectedValue = "0";
            ddlhod_comp_id.SelectedValue = "0";
            ddlhodemp_code.SelectedValue = "0";
            cdorecruitment.SelectedValue = "0";
            
            txtqualification.Value = "";
            txtExperiance.Text = "";
            txttechexpertise.Value = "";
            jobdescription.Value = "";
            txtremark.Value = "";  
            status.Text = "0";
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
        protected  void FillCompanyDepartment()
        {
            
            CommonBL BL = new CommonBL();
            cbodepartment.DataSource = BL.ListDepartment(Convert.ToInt32(cbocompany.SelectedValue));
            cbodepartment.DataTextField = "Department_Name";
            cbodepartment.DataValueField = "Department_Id";
            cbodepartment.DataBind();
            
        }
        protected void cbocompany_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void cbodept_SelectedIndexChanged(object sender,EventArgs e)
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
        protected void cdorecruitment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cdorecruitment.SelectedValue == "R")
            {
                lblrecruitment.Disabled = false;
            }
            else
            {
                lblrecruitment.Disabled = true;
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
                if(txtnoofvacancies.Text == "")
                {
                    err.Text = "Enter Vacancies!";
                    return;
                }
                if (cboreportcompname.SelectedValue == "0")
                {
                    err.Text = "Select Company!";
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
                if (status.SelectedValue == "0")
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
                CDO.mCompany_Id = Convert.ToInt32(Session["CompanyId"]);
                CDO.mPosition_title = txtpositiontitle.Value;
                CDO.mNo_of_vacancies = Convert.ToInt32(txtnoofvacancies.Text);
                CDO.mDepartment_Id = Convert.ToInt32(Session["Department_Id"]);
                CDO.mReporting_to_Company_Id = Convert.ToInt32(cboreportcompname.SelectedValue);
                CDO.mReporting_to_empcode = Convert.ToInt32(cboreportempcode.Text);
                CDO.mHOD_Company_Id = Convert.ToInt32(ddlhod_comp_id.SelectedValue);
                CDO.mHOD_Emp_Code = Convert.ToInt32(ddlhodemp_code.SelectedValue);
                CDO.mReason_for_recruitment = cdorecruitment.SelectedValue;
                CDO.mreplacement_emp_code = Convert.ToInt32(lblrecruitment.Value); 
                CDO.mQualification = txtqualification.Value;
                CDO.mExperience_Years = Convert.ToDouble(txtExperiance.Text);
                CDO.mFunctional_expertise = txttechexpertise.Value;
                CDO.mJob_description = jobdescription.Value;
                CDO.mstatus = status.Text;
                CDO.mPrepared_By = Convert.ToInt32(Session["EmpCode"]);
                CDO.mPrepared_by_company_Id = Convert.ToInt32(Session["CompanyId"]);
                CDO.mRemarks = txtremark.Value;
            
                TransactionBL CBL = new TransactionBL();
                int result = CBL.InsertMRFDetails(CDO);


                if (result != 0)
                {
                    string message = "MRF No- " + result.ToString()   + " Generated successfully";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<Script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    Valuesclear();
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
    }
}
