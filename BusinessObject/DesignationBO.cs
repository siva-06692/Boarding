using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class DesignationBO
    {
       
            private int _Company_Id;
            private int _Designation_Id;
            private string _Designation_Name;
            private string Status;

            public int mCompany_Id
            {
                get { return _Company_Id; }
                set { _Company_Id = value; }
            }
            public int mDesignation_Id
            {
                get { return _Designation_Id; }
                set { _Designation_Id = value; }
            }
            public string mDesignation_Name
            {
                get { return _Designation_Name; }
                set { _Designation_Name = value; }
            }
            public string mStatus
            {
                get { return Status; }
                set { Status = value; }
            }
        }

    }
