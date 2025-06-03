using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainTrain.model
{
    public class Course
    {
        [Key]
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        
        public DateTime reg_start_date { get; set; }
        public DateTime reg_end_date { get; set; }
        
        public List<DayOfWeek> work_day { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }


        public Guid Trainer_id { get; set; }
        [ForeignKey("Trainer_id")]
        public Trainer Trainer { get; set; }

        public List<Courseregistration> registration { get; set; }


    }
}
