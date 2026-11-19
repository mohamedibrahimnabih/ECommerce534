using Microsoft.AspNetCore.Mvc;

namespace ECommerce534.Areas.Customer.Controllers;

[Area(AreaConstants.CUSTOMER_AREA)]
public class ErrorController : Controller
{
    public IActionResult NotFoundPage()
    {
        return View();
    }

    public IActionResult BadRequestPage()
    {
        return View();
    }

    public IActionResult UnAuthorizedPage()
    {
        return View();
    }

    public IActionResult ForbiddenPage()
    {
        return View();
    }
}
