using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class Trainer_Dto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public string specialization { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public List<string> NameCourse { get; set; }
    }
}
