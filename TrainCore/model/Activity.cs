using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainTrain.model
{
    public class Activity
    {
        [Key]
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }

    }
}
