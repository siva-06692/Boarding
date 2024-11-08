using System;
using System.IO;
using System.Text.RegularExpressions;
using PdfiumViewer;
using BusinessLogic;
using BusinessObject;
using System.Collections.Generic;
using System.Web.UI;

namespace Boarding
{
    public partial class UploadResume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //if (Session["Role"].ToString() == "HR")
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string tempFolder = Server.MapPath("~/temp");
                        if (!Directory.Exists(tempFolder))
                        {
                            Directory.CreateDirectory(tempFolder);
                        }
                        string tempFilePath = Path.Combine(tempFolder, FileUpload1.FileName);
                        FileUpload1.SaveAs(tempFilePath);

                        string pdfText = ExtractTextFromPdf(tempFilePath);

                        ParseResumeData(pdfText);

                        lblResumeFileName.Text = FileUpload1.FileName;
                        lblMessage.Text = "Resume uploaded successfully!";
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"Error: {ex.Message}");
                    }
                }
            }

        }

        private string ExtractTextFromPdf(string path)
        {
            using (var document = PdfiumViewer.PdfDocument.Load(path))
            {
                StringWriter text = new StringWriter();
                for (int i = 0; i < document.PageCount; i++)
                {
                    var pageText = document.GetPdfText(i);
                    text.WriteLine(pageText);
                }
                return text.ToString();
            }
        }

        private string ExtractName(string text)
        {

            string namePattern = @"(?i)(?:Name|Full Name)[\s:]*([A-Za-z\s]+)";

            Match match = Regex.Match(text, namePattern);
            return match.Success ? match.Groups[1].Value.Trim() : "Not found";
        }
        private string ExtractDOB(string text)
        {
            string dobPattern = @"(?i)(Date of Birth|DOB|Birthdate|Birth Date)[\s:]*([\d]{1,2}/[\d]{1,2}/[\d]{2,4}|\d{1,2}-\d{1,2}-\d{2,4}|\d{1,2}.\d{1,2}.\d{2,4})";
            Match match = Regex.Match(text, dobPattern);

            return match.Success ? match.Groups[2].Value.Trim() : "Not found";
        }


        private string ExtractEmail(string text)
        {
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            Match match = Regex.Match(text, emailPattern);
            return match.Success ? match.Value.Trim() : "Not found";
        }

        private string ExtractContactNumber(string text)
        {
            string phonePattern = @"\b\d{10}\b";
            Match match = Regex.Match(text, phonePattern);
            return match.Success ? match.Value.Trim() : "Not found";
        }

        private string ExtractSkills(string text)
        {
            CommonBL BL = new CommonBL();
            
            List<string> skillKeywords = BL.GetKeywordsForCategory("Skills");
            string skillsPattern = @"(?i)(" + string.Join("|", skillKeywords.ConvertAll(Regex.Escape)) + @")" +
                                   @"[\s]*\n?([\w\s,#+\-.]+(?:\n[\s]*[\w\s,#+\-.]+)*)?";

            Match match = Regex.Match(text, skillsPattern);
            return match.Success ? match.Groups[2].Value.Trim() : "Not found";
        }

        
        private string ExtractExperience(string text)
        {
            CommonBL BL = new CommonBL();
            List<string> experienceKeywords = BL.GetKeywordsForCategory("Experience");
            string experiencePattern = @"(?i)(" + string.Join("|", experienceKeywords.ConvertAll(Regex.Escape)) + @")" +
                                       @"[\s:]*([\s\S]*?)(?=(Skills|Qualification|----------|\n\n|$))";

            Match match = Regex.Match(text, experiencePattern);
            return match.Success ? match.Groups[2].Value.Trim() : "Not found";
        }

        
        private string ExtractQualification(string text)
        {
            CommonBL BL = new CommonBL();
            List<string> qualificationKeywords = BL.GetKeywordsForCategory("Qualification");
            string qualificationPattern = @"(?i)(" + string.Join("|", qualificationKeywords.ConvertAll(Regex.Escape)) + @")" +
                                          @"[\s:]*([\s\S]*?)(?=(\n\s*[-–—]+\s*\n|Experience|Skills|Projects|\n\n|$))";

            Match match = Regex.Match(text, qualificationPattern);
            return match.Success ? match.Groups[2].Value.Trim() : "Not found";
        }

        private void ParseResumeData(string text)
        {
            txtName.Text = ExtractName(text);
            TxtDOB.Text = ExtractDOB(text);
            txtEmail.Text = ExtractEmail(text);
            txtPhone.Text = ExtractContactNumber(text);
            txtSkills.Text = ExtractSkills(text);
            txtExperience.Text = ExtractExperience(text);
            txtQualification.Text = ExtractQualification(text);
        }
        

        protected void Submit_Click(object sender, EventArgs e)
        {

            ResumeDetailsBO RDO = new ResumeDetailsBO();
            RDO.mname = txtName.Text;
            DateTime dob;
            if (DateTime.TryParse(TxtDOB.Text, out dob))
            {
                RDO.mDOB = dob; // Assign the converted DateTime to RDO.mDOB
            }
            RDO.mPhone = txtPhone.Text;
            RDO.mEmail = txtEmail.Text;
            RDO.mExperience = txtExperience.Text;
            RDO.mSkills = txtSkills.Text;
            RDO.mqualification = txtQualification.Text;

            CommonBL commonBL = new CommonBL();
            int candidateId = commonBL.SaveCandidateDetails(RDO, null);

            if (candidateId > 0)
            {
                try
                {

                    string uploadedResumesFolder = Server.MapPath("~/Resume");
                    if (!Directory.Exists(uploadedResumesFolder))
                    {
                        Directory.CreateDirectory(uploadedResumesFolder);
                    }

                    
                    string fileExtension = Path.GetExtension(lblResumeFileName.Text);

                    
                    string resumeFileName = $"{candidateId}_{txtName.Text}{fileExtension}";
                    string finalFilePath = Path.Combine(uploadedResumesFolder, resumeFileName);

                    
                    string tempFolder = Server.MapPath("~/temp");
                    string tempFilePath = Path.Combine(tempFolder, lblResumeFileName.Text);


                    if (File.Exists(tempFilePath))
                    {
                        File.Copy(tempFilePath, finalFilePath, true);

                        
                        File.Delete(tempFilePath);

                        
                        commonBL.UpdateResumeFileName(candidateId, resumeFileName);

                        lblMessage.Text += $"<br/> Candidate details saved successfully with Resume: {resumeFileName}";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error while moving file: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Error saving candidate details!";
            }


        }




    }
}
