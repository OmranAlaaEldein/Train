using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainTrain.model
{
    public class Activeuser
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cvpath { get; set; }
        public string specialization { get; set; }
        public string rool { get; set; }

        public List<Suggestions> Suggestions { get; set; }
        public List<Courseregistration> Courseregistration { get; set; }
    }
}
