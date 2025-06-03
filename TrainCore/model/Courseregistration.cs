using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainTrain.model
{
    public class Courseregistration
    {
        [Key]
        public Guid id { get; set; }
        public DateTime registration_date { get; set; }
        public DateTime submission_date { get; set; }
        public string status { get; set; }

        public Guid Course_id { get; set; }
        [ForeignKey("Course_id")]
        public Course Course { get; set; }

        public Guid activeuser_id { get; set; }
        [ForeignKey("activeuser_id")]
        public Activeuser user { get; set; }

    }
}
