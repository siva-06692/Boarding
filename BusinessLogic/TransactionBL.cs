using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransactionBL
    {
        public int InsertDesignation(DesignationBO udo)
        {
            try
            {
                TransactionDA DA = new TransactionDA();
                return DA.InsertDesignation(udo);
            }
            catch
            {
                throw;
            }
        }
        public int InsertDepartment(DepartmentBO dbo)
        {
            try
            {
                TransactionDA DA = new TransactionDA();
                return DA.InsertDepartment(dbo);
            }
            catch
            {
                throw;
            }
        }
        public int InsertMRFDetails(MRFBO mrf)
        {
            try
            {
                TransactionDA DA = new TransactionDA();
                return DA.InsertMRFDetails(mrf);

            }
            catch
            {
                throw;
            }
        }

        public int UpdateMRF(MRFBO mrf)
        {
            try
            {
                TransactionDA DA = new TransactionDA();
                return DA.UpdateMRF(mrf);

            }
            catch
            {
                throw;
            }
        }
    }
}    
