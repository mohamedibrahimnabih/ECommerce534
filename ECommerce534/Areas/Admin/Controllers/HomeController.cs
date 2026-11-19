using Microsoft.AspNetCore.Mvc;

namespace ECommerce534.Areas.Admin.Controllers;

[Area(AreaConstants.ADMIN_AREA)]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
