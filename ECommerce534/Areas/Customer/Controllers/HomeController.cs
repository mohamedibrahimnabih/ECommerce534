using ECommerce534.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerce534.Areas.Customer.Controllers;

[Area(AreaConstants.CUSTOMER_AREA)]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context = new();

    public IActionResult Index()
    {
        var products = _context
            .Products
            .Include(e => e.Category)
            .AsQueryable();

        products = products.Skip(0).Take(8);

        return View(products);
    }

    public IActionResult Details([FromRoute] int id)
    {
        // 1. Get product Details
        var product = _context.Products.Include(e => e.Category).SingleOrDefault(e => e.Id == id); 

        //if (product is null) return NotFound();
        if (product is null) return RedirectToAction(ErrorConstants.NOT_FOUND, ErrorConstants.ERROR_CONTROLLER);

        product.Traffic += 1;
        _context.SaveChanges();

        // 2. Related products by name 
        var relatedProductsByName = _context.Products
            .Where(e => e.Name.ToLower().Contains(product.Name.ToLower()) && e.Id != product.Id)
            .OrderBy(e => e.Traffic)
            .Skip(0)
            .Take(4);

        // 3. Related products by category name
        var relatedProductsByCategoryName = _context.Products
            .Where(e => e.CategoryId == product.CategoryId && e.Id != product.Id)
            .OrderBy(e => e.Traffic)
            .Skip(0)
            .Take(4);

        return View(new ProductWithRelatedVM
        {
            Product = product,
            //ProductSubImgs = _context.ProductSubImgs.Where(e=>e.ProductId == id),
            //ProductColors = _context.ProductColors.Where(e=>e.ProductId == id),
            RelatedProductsByName = relatedProductsByName,
            RelatedProductsByCategoryName = relatedProductsByCategoryName
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Hello()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
