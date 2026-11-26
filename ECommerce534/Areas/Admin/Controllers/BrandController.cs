using ECommerce534.Services;
using ECommerce534.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ECommerce534.Areas.Admin.Controllers;

[Area(AreaConstants.ADMIN_AREA)]
public class BrandController : Controller
{
    private readonly ApplicationDbContext _context = new();
    private readonly IFileUpload _fileUpload = new FileUpload();

    public IActionResult Index(string? q = null, int pg = 1, int pageSize = 10)
    {
        var brands = _context.Brands
            .AsNoTracking()
            .AsQueryable();

        // Filter
        if(q is not null)
            brands = brands.Where(e => e.Id.ToString() == q || e.Name.ToLower().Contains(q.ToLower()));

        // Pagination
        var totalPages = Math.Ceiling(brands.Count() / (double)pageSize);
        brands = brands.Skip((pg - 1) * pageSize).Take(pageSize);

        return View(new BrandWithFilterVM
        {
            Brands = brands,
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
    public async Task<IActionResult> Create(Brand brand, IFormFile logo)
    {
        //_context.Brands.Add(new Brand()
        //{
        //    Name = name,
        //    Status = status
        //});

        if (logo is not null && logo.Length > 0)
        {
            brand.Logo = await UploadLogoAsync(logo);
        }

        _context.Brands.Add(brand);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var brand = _context.Brands/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (brand is null) return NotFound();

        return View(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Brand brand, IFormFile? logo)
    {
        //_context.Brands.Add(new Brand()
        //{
        //    Name = name,
        //    Status = status
        //});

        var brandInDB = _context.Brands.AsNoTracking().SingleOrDefault(e => e.Id == brand.Id);
        if(brandInDB is null) return NotFound();

        if(logo is not null && logo.Length > 0)
        {
            brand.Logo = await UploadLogoAsync(logo);
        }
        else
        {
            brand.Logo = brandInDB.Logo;
        }

        _context.Brands.Update(brand);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var brand = _context.Brands/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (brand is null) return NotFound();

        if(brand.Logo is not null)
        {
            var filePath = _fileUpload.GetFullPathName(brand.Logo, FileType.Img, EntityType.brand);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        _context.Brands.Remove(brand);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Asynchronously uploads a brand logo file to the server and returns the generated file name.
    /// </summary>
    /// <param name="logo">The logo file to upload.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated file name of the uploaded logo.</returns>
    private async Task<string> UploadLogoAsync(IFormFile logo)
    {
        var fileName = _fileUpload.GetFullFileName(logo.FileName);
        var filePath = _fileUpload.GetFullPathName(fileName, FileType.Img, EntityType.brand);
        await _fileUpload.UploadAsync(filePath, logo);
        return fileName;
    }
}