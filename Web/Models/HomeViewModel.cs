using Data;
using NLog.LayoutRenderers;
using OA_Web.Models;
using System;
using System.Collections.Generic;
using Web.Models.SettingsVM;

namespace Web.Models
{
    public class HomeViewModel
    {
        public List<ApiData> Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<ApiCategoryViewModel> ApiCategories { get; set; }
        public List<InstagramMediaViewModel> InstaData { get; set; }

    }


}
