
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Components
{
    public class AddUnExistLocalisationkeys : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
