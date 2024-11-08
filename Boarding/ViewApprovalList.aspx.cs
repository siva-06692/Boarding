using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Boarding
{
    public partial class ViewApprovalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var url = Request.Url;
                String queryString = url.Query;
                if (queryString != "")
                {
                    string[] queryValue = queryString.Split('=');
                    string status = queryValue[1].Replace("%20", " ");

                    Session["status"] = status;
                    BindGrid(status);

                }
            }
        }
        public void BindGrid(String status)
        {

            CommonBL BL = new CommonBL();

            int CompanyId = Convert.ToInt32(Session["CompanyId"]);
            int EmpCode = Convert.ToInt32(Session["EmpCode"]);

            DataTable dt = new DataTable();


            if (Session["Role"].ToString() == "HOD")
            {
                dt = BL.GetPendingMRFList(status, CompanyId, EmpCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }                
            else if (Session["Role"].ToString() == "HOD")
            {
                DataTable dt1 = new DataTable();
                dt1 = BL.GetApprovedMRFList(status, CompanyId, EmpCode);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            else if (Session["Role"].ToString() == "HR")
            {
                dt = BL.GetPendingMRFList(status, CompanyId, EmpCode);
                dt = BL.GetApprovedMRFList(status, CompanyId, EmpCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            else if (Session["Role"].ToString() == "HRHOD")
            {
                dt = BL.GetPendingMRFList(status, CompanyId, EmpCode);
                dt = BL.GetApprovedMRFList(status, CompanyId, EmpCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string status = Session["status"].ToString();
            BindGrid(status);
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].CssClass = "hide";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].CssClass = "hide";
            }

        }

        protected void GetMrfnodetails(object sender, EventArgs e)
        {
            LinkButton lnk = (sender) as LinkButton;
            GridViewRow row = (GridViewRow)lnk.NamingContainer;
            Session["MRF_NO"] = (row.FindControl("link_MRFNo") as LinkButton).Text;
            Session["MRF_Company_Id"] = (row.FindControl("lblmrfcompid") as Label).Text;
            Response.Redirect("ViewApprovalMRFList.aspx");
        }
    }
}