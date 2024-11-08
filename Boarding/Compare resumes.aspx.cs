using BusinessLogic;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;

namespace Boarding
{
    public partial class Compare_resumes : System.Web.UI.Page
    {
        private CommonBL _businessLogic = new CommonBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindResumes();
            }
        }

        private void BindResumes()
        {
            CommonBL BL = new CommonBL();
            List<Resume> scoredResumes = BL.GetScoredResumes();
            scoredResumes.Sort((x, y) => y.Score.CompareTo(x.Score)); // Sort by score in descending order

            GridViewResumes.DataSource = scoredResumes;
            GridViewResumes.DataBind();
        }

    }
}