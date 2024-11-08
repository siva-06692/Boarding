using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatusCounts();
            }  

        }
        private void LoadStatusCounts()
        {
            CommonBL DA = new CommonBL();

            int empCode = Convert.ToInt32(Session["EmpCode"]);
            int companyId = Convert.ToInt32(Session["CompanyId"]);

            lbl_Draft_Count.Text = DA.ReturnStatusCount("D", empCode, companyId).ToString();
            lbl_Submit_Count.Text = DA.ReturnStatusCount("S", empCode, companyId).ToString();
            lbl_Rejected_Count.Text = DA.ReturnStatusCount("J", empCode, companyId).ToString();
            lbl_Closed_Count.Text = DA.ReturnStatusCount("C", empCode, companyId).ToString();
            lbl_Pending_to_be_approved_Count.Text = DA.ReturnPendingCount("S", empCode, companyId).ToString();
            lbl_approved_count.Text = DA.ReturnPendingCount("A",empCode, companyId).ToString();
            lbl_approver_rejected_Count.Text = DA.ReturnPendingCount("J", empCode, companyId).ToString();

        }
        

    }
}