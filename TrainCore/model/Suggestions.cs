using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainTrain.model
{
    public class Suggestions
    {
        [Key]
        public Guid Id { get; set; }
        public string message { get; set; }
        public DateTime submission_date { get; set; }

        public Guid ActiveUser_id { get; set; }
        [ForeignKey("ActiveUser_id")]
        public Activeuser user { get; set; }

    }
}
