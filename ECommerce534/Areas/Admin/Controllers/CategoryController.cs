using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ECommerce534.Areas.Admin.Controllers;

[Area(AreaConstants.ADMIN_AREA)]
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context = new();

    public IActionResult Index(string? q = null, int pg = 1, int pageSize = 10)
    {
        var categories = _context.Categories
            .AsNoTracking()
            .AsQueryable();

        // Filter
        if(q is not null)
            categories = categories.Where(e => e.Id.ToString() == q || e.Name.ToLower().Contains(q.ToLower()));

        // Pagination
        var totalPages = Math.Ceiling(categories.Count() / (double)pageSize);
        categories = categories.Skip((pg - 1) * pageSize).Take(pageSize);

        return View(new CategoryWithFilterVM
        {
            Categories = categories,
            Q = q,
            TotalPages = totalPages,
            CurrentPage = pg
        });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        //_context.Categories.Add(new Category()
        //{
        //    Name = name,
        //    Status = status
        //});

        _context.Categories.Add(category);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var category = _context.Categories/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (category is null) return NotFound();

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        //_context.Categories.Add(new Category()
        //{
        //    Name = name,
        //    Status = status
        //});

        _context.Categories.Update(category);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = _context.Categories/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (category is null) return NotFound();

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}