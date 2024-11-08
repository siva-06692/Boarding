using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObject;
using System.Data;
using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;


namespace BusinessLogic
{
    public class CommonBL
    {
        private MLContext _mlContext;
        private ITransformer _model;



        public int ValidateUser(UserBO ubo)
        {

            try
            {
                CommonDA DA = new CommonDA();
                return DA.ValidateUser(ubo);
            }

            catch
            {
                throw;
            }
        }
        public DataTable GetLoginUser(UserBO ubo)
        {

            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetLoginUser(ubo);
            }

            catch
            {
                throw;
            }
        }

        public DataTable ListCompany()
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ListCompany();
            }
            catch
            {
                throw;
            }
        }
        public int CheckDesignationNameExists(DesignationBO udo)
        {

            try
            {
                CommonDA DA = new CommonDA();
                return DA.CheckDesignationNameExists(udo);
            }

            catch
            {
                throw;
            }
        
        }
        public DataTable ListEmployee(int companyid)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ListEmployee(companyid);
            }
            catch
            {
                throw;
            }

        }

        public DataTable ListHOD(int companyid)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ListHOD(companyid);
            }
            catch
            {
                throw;
            }

        }
        public int CheckDepartmentNameExists(DepartmentBO dbo)
        {

            try
            {
                CommonDA DA = new CommonDA();
                return DA.CheckDepartmentNameExists(dbo);
            }

            catch
            {
                throw;
            }

        }
        public DataTable ListDepartment(int companyid)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ListDepartment(companyid);
            }
            catch
            {
                throw;
            }
        }
        public int ReturnStatusCount(string status,int prepared_by,int prepared_by_Company_id)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ReturnStatusCount(status,prepared_by,prepared_by_Company_id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetMRFList(string status, int prepared_by, int prepared_by_company_Id)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetMRFList(status, prepared_by, prepared_by_company_Id);
            }
            catch
            {
                throw;
            }
        }

        public int ReturnPendingCount(string status,  int To_be_Approved_by_emp_code, int To_be_Approved_by_Company_Id)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ReturnPendingCount(status, To_be_Approved_by_emp_code, To_be_Approved_by_Company_Id);
            }
            catch
            {
                throw;
            }
        }


        
        public DataTable GetMRFNODetails(int MRF_NO,int compid)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetMRFNODetails(MRF_NO,compid);
            }
            catch
            {
                throw;
            }

        }
        public DataTable GetMRFLog(int MRF_NO,int compid)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetMRFLog(MRF_NO,compid);
            }
            catch
            {
                throw;
            }

        }

        public DataTable GetPendingMRFList(string status, int To_be_Approved_by_Company_Id, int To_be_Approved_by_emp_code)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetPendingMRFList(status, To_be_Approved_by_Company_Id, To_be_Approved_by_emp_code);
            }
            catch
            {
                throw;
            }
        }

        public int ReturnApprovedCount(string status, int prepared_by, int prepared_by_company_Id)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.ReturnApprovedCount(status, prepared_by, prepared_by_company_Id);
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetApprovedMRFList(string status, int prepared_by_company_Id, int prepared_by)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetApprovedMRFList(status, prepared_by_company_Id, prepared_by);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetDesignation(int companyId, String EmpName)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.GetDesignation(companyId, EmpName);
            }
            catch
            {
                throw;
            }
        }

        public int MRFApproverDetails(int mrfno,int compid,int companyname1,int empcode1, int companyname2, int empcode2, int companyname3, int empcode3, int companyname4, int empcode4, int companyname5, int empcode5)
        {
            try
            {
                CommonDA DA = new CommonDA();
                return DA.MRFApproverDetails(mrfno, compid, companyname1, empcode1, companyname2, empcode2, companyname3, empcode3, companyname4, empcode4, companyname5, empcode5);
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetKeywordsForCategory(string category)
        {
            CommonDA DA = new CommonDA();
            // Call the data access layer to get the keywords from the database
            return DA.GetKeywords(category);
        }
        public int SaveCandidateDetails(ResumeDetailsBO RDO, string resumeFileName)
        {
            CommonDA DA = new CommonDA();
             return DA.SaveCandidateDetails(RDO, resumeFileName);
        }
        public void UpdateResumeFileName(int candidateId, string resumeFileName)
        {
            CommonDA DA = new CommonDA();
            DA.UpdateResumeFileName(candidateId, resumeFileName);
        }

        public DataTable GetResumes(int? minAge, int? maxAge, string qualification, string skills, string experience, bool includeBlocked)
        {
            CommonDA commonDA = new CommonDA();
            return commonDA.SearchResumes(minAge, maxAge, qualification, skills, experience, includeBlocked);
        }

        

        public DataTable SearchCandidates(string skills)
        {
            CommonDA DA = new CommonDA();
            return DA.GetCandidatesByskill(skills);
        }

        public void BlockCandidate(int candidateId, string reason, string prepared_by)
        {
            CommonDA DA = new CommonDA();
            DA.BlockCandidate(candidateId, reason, prepared_by);
        }

        public void BlockUpCandidate(int candidateId, DateTime blockedUntil, string reason, string prepared_by)
        {
            CommonDA DA = new CommonDA();
            DA.BlockUpCandidate(candidateId, blockedUntil, reason, prepared_by);
        }

        // Method to get scored resumes

        
        public CommonBL()
        {
            _mlContext = new MLContext(); // Initialize MLContext
        }
        public void InitializeModel()
        {
            
            string datasetPath = "C://Boarding//Boarding//Boarding//Models//resumeData.csv"; // Specify the path to your dataset
            IDataView trainingData = LoadDataset(datasetPath);

            // Train the model using the dataset
            _model = TrainModel(trainingData);
        }
        public IDataView LoadDataset(string path)
        {
            // Load the dataset
            IDataView dataView = _mlContext.Data.LoadFromTextFile<ResumeMLBO>(path, separatorChar: ',', hasHeader: true);

            return dataView;
        }
        public ITransformer TrainModel(IDataView trainingData)
        {
            // Define the training pipeline
            var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(ResumeMLBO.ResumeText))
                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(ResumeMLBO.Score), maximumNumberOfIterations: 100));

            // Train the model
            var model = pipeline.Fit(trainingData);

            return model;
        }

        

        public List<Resume> GetScoredResumes()
        {
            if (_model == null)
            {
                InitializeModel(); // Ensure the model is initialized
            }
            CommonDA DA = new CommonDA();
            var resumes = DA.GetResumes(); // Ensure this returns List<Resume>

            if (resumes == null || resumes.Count == 0)
            {
                throw new Exception("No resumes found in Compareresume table.");
            }

            // Ensure that ResumePredictionBO is defined
            var predictor = _mlContext.Model.CreatePredictionEngine<ResumeMLBO, ResumePredictionBO>(_model);

            foreach (var resume in resumes)
            {
                if (string.IsNullOrEmpty(resume.ResumeText))
                {
                    throw new Exception($"Resume ID {resume.ResumeID} has no text to predict.");
                }
                // Assuming Resume has a property ResumeText
                var prediction = predictor.Predict(new ResumeMLBO { ResumeText = resume.ResumeText });
                resume.Score = prediction.Score; // Make sure Score is a property of Resume
            }

            return resumes;
        }













    }
}
