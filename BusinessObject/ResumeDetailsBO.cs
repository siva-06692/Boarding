using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessObject
{
    public class ResumeDetailsBO
    {
        private string _name;
        private string _Age;
        private DateTime _DOB;
        private string _phone;
        private string _email;
        private string _experience;
        private string _skills;
        private string _qualification;
        private string _ResumeFileName;
        public string mname
        {
            get { return _name; }
            set { _name = value; }
        }
        public string mage
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public DateTime mDOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        public string mPhone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string mEmail
        {
            get { return _email; }
            set { _email = value; }
        }
        public string mExperience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        public string mSkills
        {
            get { return _skills; }
            set { _skills = value; }
        }
        public string mqualification
        {
            get { return _qualification; }
            set { _qualification = value; }
        }
        public string mResumeFileName
        {
            get { return _ResumeFileName; }
            set { _ResumeFileName = value; }
        }
        
    }
}
