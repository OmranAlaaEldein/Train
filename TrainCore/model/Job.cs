using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainTrain.model
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string text { get; set; }
        public string requirements { get; set; }
        public string specialization { get; set; }
        public string salaryRange { get; set; }
        public string jobType { get; set; }
        public string location { get; set; }
        public string experience_level { get; set; }
        public DateTime expirydate { get; set; }
    }
}
