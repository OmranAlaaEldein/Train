using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTrain.Dto
{
    public class PaggingResponse<T>
    {
        public int pageSize { set; get; }
        public int pageNumber { set; get; }
        public int total { set; get; }
        public List<T> items { set; get; }
    }
}
