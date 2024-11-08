using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;

namespace Boarding
{
    public partial class Resumesearch : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SearchResults"] != null)
                {
                    DataTable dt = (DataTable)Session["SearchResults"];
                    gvResumes.DataSource = dt;
                    gvResumes.DataBind();
                }

            }

        }
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int? minAge = string.IsNullOrEmpty(txtMinAge.Value) ? (int?)null : int.Parse(txtMinAge.Value);
            int? maxAge = string.IsNullOrEmpty(txtMaxAge.Value) ? (int?)null : int.Parse(txtMaxAge.Value);
            string qualification = txtQualification.Text;
            string skills = txtSkills.Text;
            string experience = txtExperience.Text;

            bool includeBlocked = chkIncludeBlocked.Checked;

            CommonBL commonBL = new CommonBL();
            DataTable dt = commonBL.GetResumes(minAge, maxAge, qualification, skills, experience, includeBlocked);
         
            if (dt != null && dt.Rows.Count > 0)
            {
                
                gvResumes.DataSource = dt;
                gvResumes.DataBind();
                Session["SearchResults"] = dt;
            }
            else
            {
                gvResumes.DataSource = null;
                gvResumes.DataBind();
                Session["SearchResults"] = null;
            }
        }
        
        protected void lnkfilename_Click(object sender, EventArgs e)
        {

            LinkButton lnkButton = (LinkButton)sender; 
            string fpath = ConfigurationManager.AppSettings["Resume"].ToString();
            string Specfile1 = Server.MapPath(fpath + lnkButton.Text); 
            Filedownload(Specfile1);
        }
        private void Filedownload(string filename)
        {
            string strURL = filename;
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition","attachment;filename= " + Path.GetFileName(strURL));
            byte[] data = req.DownloadData(strURL);
            response.BinaryWrite(data);
            response.End();    
        }

        

        

        

        protected void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resumesearch.aspx");
        }


        private void LoadCandidates()
        {
            // Code to load data from the database and bind to GridView
        }

        protected void candidateGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add logic here if needed in the future
        }



    }

}