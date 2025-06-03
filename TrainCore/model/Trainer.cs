using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainTrain.model
{
    public class Trainer
    {
        [Key]
        public Guid Id { get; set; }

        public string name { get; set; }
        public string bio { get; set; }
        public string specialization { get; set; }
        public string Username { get; set; }
        public string password { get; set; }

        public List<Course> Course { get; set; }
    }
}



















































































































