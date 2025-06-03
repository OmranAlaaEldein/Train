using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class Course_Dto
    {
        public Guid id { get; set; }
        public Guid idTrainner { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string duration { get; set; }
        
        public List<DayOfWeek> work_day { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }

    }
}
