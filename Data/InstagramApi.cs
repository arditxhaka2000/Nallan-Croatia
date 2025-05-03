using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InstagramApi
    {
        public string id { get; set; }
        public string media_type { get; set; }
        public string media_url { get; set; }
    }
    public class InstagramMediaResponse
    {
        public List<InstagramApi> Data { get; set; }
    }
}
