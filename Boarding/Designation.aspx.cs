using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class Designation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtDesigName.Text = "";
                FillCompany();
                cboCompany.SelectedValue = "0";

            }

        }

        protected void FillCompany()
        {
            CommonBL BL = new CommonBL();
            cboCompany.DataSource = BL.ListCompany();
            cboCompany.DataTextField = "Company_Name";
            cboCompany.DataValueField = "company_id";
            cboCompany.DataBind();

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


                if (TxtDesigName.Text.Length == 0)
                {
                    err.Text = "Enter Designation Name!";
                    return;
                }


                DesignationBO DAE = new DesignationBO();

                DAE.mCompany_Id = Convert.ToInt32(cboCompany.SelectedValue);
                DAE.mDesignation_Name = TxtDesigName.Text;

                CommonBL DA = new CommonBL();
                int result = DA.CheckDesignationNameExists(DAE);

                if (result == 1)
                {
                    err.Text = "Already Exists";
                    return;
                }


                DesignationBO CDO = new DesignationBO();
                CDO.mCompany_Id = Convert.ToInt32(cboCompany.SelectedValue);
                CDO.mDesignation_Name = TxtDesigName.Text;

                TransactionBL CBL = new TransactionBL();
                result = CBL.InsertDesignation(CDO);


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
                    TxtDesigName.Text = "";
                    err.Text = "";
                   
                }
                else
                {
                    err.Text = "Record Not Saved! Contact Administrator";
                    cboCompany.SelectedValue = "0";
                    TxtDesigName.Text = "";
                    return;
                }
            }


            catch (Exception ex)
            {
                err.Text = ex.Message.ToString();
                return;

            }

        }
        protected void reset_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx");
        }
    }
}