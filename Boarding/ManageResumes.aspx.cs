using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Boarding
{
    public partial class ManageResumes : System.Web.UI.Page
    {
        protected string CandidateIdToBlock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindEmptyGrid(); 
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            LoadCandidates(txtskill.Text.Trim());
        }
        protected void LoadCandidates(string skills)
        {
            CommonBL BL = new CommonBL();
            DataTable candidates = BL.SearchCandidates(skills);

            if (candidates.Rows.Count > 0)
            {
                candidateGrid.DataSource = candidates;
                candidateGrid.DataBind();
                ViewState["CandidateData"] = candidates; // Store data for paging
            }
            else
            {
                BindEmptyGrid();
            }
        }

        protected void BindEmptyGrid()
        {
            
            candidateGrid.DataSource = new DataTable();
            candidateGrid.DataBind();
        }

        protected void candidateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page index
            candidateGrid.PageIndex = e.NewPageIndex;

            // Re-bind the data to reflect the new page
            if (ViewState["CandidateData"] != null)
            {
                candidateGrid.DataSource = ViewState["CandidateData"];
                candidateGrid.DataBind();
            }
            else
            {
                LoadCandidates(txtskill.Text.Trim()); // Load data again if ViewState is null
            }
        }
        protected void candidateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Block")
            {
                
                CandidateIdToBlock = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "document.getElementById('blockModal').style.display='block';", true);
            }
        }

        protected void btnConfirmBlock_Click(object sender, EventArgs e)
        {
            lblReason.Text = string.Empty;
            string reason = txtReason.Text;
            DateTime blockedUntil;
            string candidateId = CandidateIdToBlock;
            string prep_by = Convert.ToString(Session["EmpName"]);

            if (DateTime.TryParse(blockedUntilDate.Text, out blockedUntil))
            {
                BlockUpCandidate(candidateId, blockedUntil, reason, prep_by);
            }
            else
            {
                BlockCandidate(candidateId, reason, prep_by);
            }
            txtReason.Text = string.Empty;
            blockedUntilDate.Text = string.Empty;
            ViewState["CandidateIdToBlock"] = null;
        }

        private void BlockCandidate(string candidateId, string reason, string prep_by)
        {
            CommonBL BL = new CommonBL();
            int id = Convert.ToInt32(candidateId);
            BL.BlockCandidate(id, reason, prep_by);
            lblMessage.Text = "Candidate blocked successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            LoadCandidates(txtskill.Text.Trim());
        }

        private void BlockUpCandidate(string candidateId, DateTime blockedUntil,string reason, string prep_by)
        {
            CommonBL BL = new CommonBL();
            int id = Convert.ToInt32(candidateId);
            BL.BlockUpCandidate(id, blockedUntil, lblReason.Text, prep_by);
            lblMessage.Text = $"Candidate blocked until {blockedUntil.ToShortDateString()}.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            LoadCandidates(txtskill.Text.Trim());
        }

        protected void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resumesearch.aspx");
        }

        








    }



}