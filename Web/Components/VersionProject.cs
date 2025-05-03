using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Models;

namespace Web.Components
{
    public class VersionProject : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public VersionProject(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var model = new VersionProjectViewModel();
            try
            {
                model.IsVisibility = _configuration.GetValue<bool>("MySettings:VisibilityVersion");
                model.Title = _configuration.GetValue<string>("MySettings:TitleVersion");
            }
            catch (System.Exception)
            {
                model.IsVisibility = false;
            }
            return View(model);
        }
    }
}
