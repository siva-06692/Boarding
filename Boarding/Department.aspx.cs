using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillCompany();
                cboCompany.SelectedValue = "0";
                ddl_dept_head_comp_name.SelectedValue = "0";

            }

        }

        protected void FillCompany()
        {
            CommonBL BL = new CommonBL();
            cboCompany.DataSource = BL.ListCompany();
            cboCompany.DataTextField = "Company_Name";
            cboCompany.DataValueField = "Company_id";
            cboCompany.DataBind();

            BL = new CommonBL();
            ddl_dept_head_comp_name.DataSource = BL.ListCompany();
            ddl_dept_head_comp_name.DataTextField = "Company_Name";
            ddl_dept_head_comp_name.DataValueField = "Company_id";
            ddl_dept_head_comp_name.DataBind();

        }

        protected void ddl_dept_head_comp_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_dept_head_comp_name.SelectedValue == "0")
            {
                return;
            }

            ddl_dept_head_empname.Items.Clear();
            ddl_dept_head_empname.Items.Add(new ListItem("--Select Employee--", "0"));

            CommonBL CBL = new CommonBL();
            ddl_dept_head_empname.DataSource = CBL.ListEmployee(Convert.ToInt32(ddl_dept_head_comp_name.SelectedValue));
            ddl_dept_head_empname.DataTextField = "Employee_Name";
            ddl_dept_head_empname.DataValueField = "Employee_id";
            ddl_dept_head_empname.DataBind();

        }
        protected void ddl_dept_head_empname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboCompany.SelectedValue) == 0)
                {
                    err.Text = "Select Company Name!";
                    return;
                }
                if (Deptname.Text.Length == 0)
                {
                    err.Text = "Enter Department Name!";
                    return;
                }
                if(ddl_dept_head_comp_name.SelectedValue == "0")
                {
                    err.Text = "Select Department_Head_Company_Name";
                    return;
                }
                if (ddl_dept_head_empname.SelectedValue == "0")
                {
                    err.Text = "Select Department_Head_Emp_Code";
                    return;
                }

                DepartmentBO DNE = new DepartmentBO();

                DNE.mDepartment_Company_Id = Convert.ToInt32(cboCompany.SelectedValue);
                DNE.mDepartment_Name = Deptname.Text;
                

                CommonBL DA = new CommonBL();
                int result = DA.CheckDepartmentNameExists(DNE);

                if (result == 1)
                {
                    err.Text = "Already Exists";
                    return;
                }


                DepartmentBO DAE = new DepartmentBO();

                DAE.mDepartment_Company_Id = Convert.ToInt32(cboCompany.SelectedValue);
                DAE.mDepartment_Name = Deptname.Text;
                DAE.mDepartment_Head_Company_id = Convert.ToInt32(ddl_dept_head_comp_name.SelectedValue);
                DAE.mDepartment_head_emp_code = Convert.ToInt32(ddl_dept_head_empname.SelectedValue);

                TransactionBL CBL = new TransactionBL();
                result = CBL.InsertDepartment(DAE);
                


                if (result != 0)
                {
                    string message = "Record saved successfully";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<Script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    
                    cboCompany.SelectedValue = "0";
                    Deptname.Text = "";
                    ddl_dept_head_comp_name.SelectedValue = "0";
                    ddl_dept_head_empname.SelectedValue = "0";
                    return;
                }
                
            }


            catch (Exception ex)
            {
                err.Text = ex.Message.ToString();
                return;

            }

        }
        protected void Reset_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx");
        }

    }
}