using System.Collections.Generic;

namespace Web.Models
{
    public class InstaApiViewModel
    {
        public List<InstagramMediaViewModel> InstaData { get; set; }
    }
    public class InstagramMediaViewModel
    {
        public string id { get; set; }
        public string media_type { get; set; }
        public string media_url { get; set; }
    }
}
