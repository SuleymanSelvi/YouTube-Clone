using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Domain
{
    public class YoutubeApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public List<T> DataList { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int OptionalCount { get; set; }
        public bool OptionalBoolean { get; set; }
    }
}
