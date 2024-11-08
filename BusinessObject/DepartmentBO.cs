using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class DepartmentBO
    {
        private int _Department_Company_Id;
        private int _Department_Id;
        private string _Department_Name;
        private int _Department_head_Company_id;
        private int _Department_head_emp_code;
        private string status;


        public int mDepartment_Company_Id
        {
            get { return _Department_Company_Id; }
            set { _Department_Company_Id = value; }
        }
        public int mDepartment_Id
        {
            get { return _Department_Id; }
            set { _Department_Id = value; }
        }
        public string mDepartment_Name
        {
            get { return _Department_Name; }
            set { _Department_Name = value; }
        }
        public int mDepartment_Head_Company_id
        {
            get{return _Department_head_Company_id;}
            set{_Department_head_Company_id = value; }
        }
        public int mDepartment_head_emp_code
        {
            get { return _Department_head_emp_code; }
            set { _Department_head_emp_code = value; }
        }
        public string mstatus
        {
            get { return status; }
            set { status = value; }
        }

    }
}
