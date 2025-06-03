using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class Filter
    {
        public string field { set; get; }
        public string operation { set; get; }
        public string value { set; get; }
    }
}
