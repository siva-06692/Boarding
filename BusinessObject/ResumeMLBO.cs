using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ResumeMLBO
    {
        [LoadColumn(0)]
        public string ResumeText { get; set; }
        [LoadColumn(1)]
        public float Score { get; set; }
    }
}
