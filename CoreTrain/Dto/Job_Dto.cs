using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class Job_Dto
    {
        public string title { get; set; }
        public string company { get; set; }
        public string text { get; set; }
        public string requiremenys { get; set; }
        public string specialization { get; set; }
        public string salaryRange { get; set; }
        public string jobType { get; set; }
        public string location { get; set; }
        public string experience_level { get; set; }
        public DateTime expirydate { get; set; }
    }
}
