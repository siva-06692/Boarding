using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                txtuserid.Value = "";
                txtpassword.Value = "";
            }

         


        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtuserid.Value.Length == 0)
                {
                    lblerr.Text = "Enter Valid User Name!";
                    return;
                }

                if (txtpassword.Value.Length == 0)
                {
                    lblerr.Text = "Enter Password!";
                    return;
                }

                UserBO UBO = new UserBO();

                UBO.mUserId = txtuserid.Value;
                UBO.mPassword = txtpassword.Value;

                CommonBL CBL = new CommonBL();
                int result = CBL.ValidateUser(UBO);

                

                if (result == 0)
                {
                    lblerr.Text = "Invalid User!";
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    UBO.mUserId = txtuserid.Value;
                    dt = CBL.GetLoginUser(UBO);
                    int Company_Id=0;
                    int Emp_Code=0;
                    string Role = "0";
                    string Employee_Name ="0";
                    string Department_Name = "0";
                    int Department_Id = 0;
                    if (dt.Rows.Count != 0)
                    {
                        Company_Id = dt.Rows[0].Field<int>(0);
                        Emp_Code = dt.Rows[0].Field<int>(1);
                        Role = dt.Rows[0].Field<string>(2);
                        Employee_Name=dt.Rows[0].Field<string>(3);
                        Department_Name = dt.Rows[0].Field<string>(4);
                        Department_Id = dt.Rows[0].Field<int>(5);
                    }
                    Session["UserId"] = Convert.ToString(txtuserid.Value);
                    Session["CompanyId"] = Company_Id;
                    Session["EmpCode"] = Emp_Code;
                    Session["Role"] = Role;
                    Session["EmpName"] = Employee_Name;
                    Session["DepartmentName"] = Department_Name;
                    Session["Department_Id"]=Department_Id;
                    Response.Redirect("Home.aspx");
                    return;

                }


            }

            catch(Exception ex)
            {
                lblerr.Text = ex.Message.ToString();
                return;

            }
        }
        
    }
}