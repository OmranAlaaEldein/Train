using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class PaggingRequest
    {
        public List<Filter> filters { set; get; } 
        
        public int pageSize { set; get; } 
        public int pageNumber { set; get; } 

        public string orderBy { set; get; }
        public string orderType { set; get; } = "asc";
    }
}
