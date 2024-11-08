using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MRFBO
    {
        private int _MRF_No;
        private int _Company_Id;
        private string _Position_title;
        private int _No_of_vacancies;
        private int _Department_Id;
        private int _Reporting_to_Company_Id;
        private int _Reporting_to_empcode;
        private int _HOD_Company_Id;
        private int _HOD_Emp_Code;
        private string _Reason_for_recruitment;
        private int _replacement_emp_code;
        private string _Qualification;
        private double _Experience_Years;
        private string _Functional_expertise;
        private string _Job_description;
        private string status;
        private int _vacancycode;
        private int _Prepared_By;
        private int _Prepared_by_company_Id;
        private string _Remarks;


        public int mMRFno
        {
            get { return _MRF_No; }
            set { _MRF_No = value; }
        }
        public int mCompany_Id
        {
            get { return _Company_Id; }
            set { _Company_Id = value; }
        }
        
        public string mPosition_title
        {
            get { return _Position_title; }
            set { _Position_title = value; }
        }
        public int mNo_of_vacancies
        {
            get { return _No_of_vacancies;}
            set { _No_of_vacancies = value; }   
        }
        public int mDepartment_Id
        {
            get { return _Department_Id; }
            set { _Department_Id = value; }
        }
        public int mReporting_to_Company_Id
        {
            get { return _Reporting_to_Company_Id; }
            set { _Reporting_to_Company_Id = value; }
        }
        public int mReporting_to_empcode
        {
            get { return _Reporting_to_empcode; }
            set { _Reporting_to_empcode = value; }
        }
        public int mHOD_Company_Id
        {
            get { return _HOD_Company_Id; }
            set { _HOD_Company_Id = value; }
        }
        public int mHOD_Emp_Code
        {
            get { return _HOD_Emp_Code; }
            set { _HOD_Emp_Code = value; }
        }
        public string mReason_for_recruitment
        {
            get { return _Reason_for_recruitment; }
            set { _Reason_for_recruitment = value; }
        }
        public int mreplacement_emp_code
        {
            get { return _replacement_emp_code; }
            set { _replacement_emp_code = value; }
        }
        public string mQualification
        {
            get { return _Qualification; } 
            set{ _Qualification = value; } 
        }
        public double mExperience_Years
        {
            get { return _Experience_Years; }
            set { _Experience_Years = value; }
        }
        public string mFunctional_expertise
        {
            get { return _Functional_expertise; }
            set { _Functional_expertise = value; }
        }
        public string mJob_description
        {
            get { return _Job_description; }
            set { _Job_description = value; }
        }
        public string mstatus
        {
            get { return status; }
            set { status = value; }
        }
        public int mvacancycode
        {
            get { return mvacancycode; }
            set { mvacancycode = value; }
        }
            
        public int mPrepared_By
        {
            get { return _Prepared_By; }
            set { _Prepared_By = value; }
        }
        public int mPrepared_by_company_Id
        {
            get { return _Prepared_by_company_Id; }
            set { _Prepared_by_company_Id = value; }
        }
        public string mRemarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }   

        }
        




    }
}
