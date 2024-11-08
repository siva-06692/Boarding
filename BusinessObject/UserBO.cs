using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBO
    {
        private int _Company_Id;
        private int _Emp_Code;
        private string _User_Id;
        private string _Password;
        private string Status;


        public int mCompanyId
        {
            get { return _Company_Id; }
            set { _Company_Id = value; }
        }
        public int mEmpCode
        {
            get { return _Emp_Code; }
            set { _Emp_Code = value; }
        }
        public string mUserId
        {

            get { return _User_Id; }
            set { _User_Id = value; }
        }

        public string mPassword
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string mStatus
        {
            get { return Status; }
            set { Status = value; }
        }
    }
   


}


