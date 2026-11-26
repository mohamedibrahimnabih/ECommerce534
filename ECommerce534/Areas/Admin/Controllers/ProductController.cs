using ECommerce534.Services;
using ECommerce534.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ECommerce534.Areas.Admin.Controllers;

[Area(AreaConstants.ADMIN_AREA)]
public class ProductController : Controller
{
    private readonly ApplicationDbContext _context = new();
    private readonly IFileUpload _fileUpload = new FileUpload();

    public IActionResult Index(ProductRequestVM productRequestVM, int pg = 1, int pageSize = 10) /* TODO: Create PaginationRequestVM and replace it */
    {
        var products = _context.Products
            .AsNoTracking()
            .AsQueryable()
            .Select(e => new ProductResponseVM
            {
                Id = e.Id,
                Name = e.Name,
                Status = e.Status,
                Price = e.Price,
                Quantity = e.Quantity,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name,
                BrandId = e.Brand.Id,
                BrandName = e.Brand.Name
            });

        // Filter
        if (productRequestVM.Q is not null)
            products = products.Where(e => e.Id.ToString() == productRequestVM.Q || e.Name.ToLower().Contains(productRequestVM.Q.ToLower()));

        if (productRequestVM.MinPrice is not null)
            products = products.Where(e => e.Price >= productRequestVM.MinPrice);

        if (productRequestVM.MaxPrice is not null)
            products = products.Where(e => e.Price <= productRequestVM.MaxPrice);

        if (productRequestVM.CategoryId is not null)
            products = products.Where(e => e.CategoryId == productRequestVM.CategoryId);

        if (productRequestVM.BrandId is not null)
            products = products.Where(e => e.BrandId == productRequestVM.BrandId);

        // Pagination
        var totalPages = Math.Ceiling(products.Count() / (double)pageSize);
        products = products.Skip((pg - 1) * pageSize).Take(pageSize);

        return View(new ProductWithFilterVM
        {
            Products = products,
            Categories = _context.Categories,
            Brands = _context.Brands,
            Q = productRequestVM.Q,
            TotalPages = totalPages,
            CurrentPage = pg
        });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateProductResponseVM
        {
            Categories = _context.Categories,
            Brands = _context.Brands
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product, IFormFile mainImg, List<IFormFile>? subImgs, List<string>? colors) /* TODO: Create Request and replace it */
    {
        //_context.Products.Add(new Product()
        //{
        //    Name = name,
        //    Status = status
        //});

        if (mainImg is not null && mainImg.Length > 0)
        {
            product.MainImg = await UploadImgsAsync(mainImg, EntityType.product);
        }

        _context.Products.Add(product);
        _context.SaveChanges();

        if (subImgs is not null && subImgs.Any())
        {
            foreach (var item in subImgs)
            {
                _context.ProductSubImgs.Add(new()
                {
                    SubImg = await UploadImgsAsync(item, EntityType.productSubImg),
                    ProductId = product.Id
                });
            }

            _context.SaveChanges();
        }

        if (colors is not null && colors.Any())
        {
            foreach (var item in colors)
            {
                _context.ProductColors.Add(new()
                {
                    Color = item,
                    ProductId = product.Id
                });
            }

            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = _context.Products/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (product is null) return NotFound();

        return View(new UpdateProductResponseVM
        {
            Product = product,
            ProductSubImgs = _context.ProductSubImgs.Where(e => e.ProductId == id),
            ProductColors = _context.ProductColors.Where(e => e.ProductId == id),
            Categories = _context.Categories,
            Brands = _context.Brands
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product, IFormFile? mainImg, List<IFormFile>? subImgs, List<string>? colors) /* TODO: Create Request and replace it */
    {
        //_context.Products.Add(new Product()
        //{
        //    Name = name,
        //    Status = status
        //});

        var productInDB = _context.Products.AsNoTracking().SingleOrDefault(e => e.Id == product.Id);
        if (productInDB is null) return NotFound();

        if (mainImg is not null && mainImg.Length > 0)
        {
            product.MainImg = await UploadImgsAsync(mainImg, EntityType.product);
        }
        else
        {
            product.MainImg = productInDB.MainImg;
        }

        _context.Products.Update(product);
        _context.SaveChanges();

        if (subImgs is not null && subImgs.Any())
        {
            // 1. retrieve old sub imgs
            var productSubImgs = _context.ProductSubImgs.Where(e => e.ProductId == product.Id);

            // 2. delete them from wwwroot
            foreach (var productSubImg in productSubImgs)
            {
                if (productSubImg is not null)
                {
                    var filePath = _fileUpload.GetFullPathName(productSubImg.SubImg, FileType.Img, EntityType.productSubImg);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            // 3. delete them from db
            _context.ProductSubImgs.RemoveRange(productSubImgs);

            // 4. create new sub imgs
            foreach (var item in subImgs)
            {
                _context.ProductSubImgs.Add(new()
                {
                    SubImg = await UploadImgsAsync(item, EntityType.productSubImg),
                    ProductId = product.Id
                });
            }

            _context.SaveChanges();
        }

        if (colors is not null && colors.Any())
        {
            // 1. retrieve old colors
            var productColors = _context.ProductColors.Where(e => e.ProductId == product.Id);

            // 2. delete them from db
            _context.ProductColors.RemoveRange(productColors);

            // 3. create new colors
            foreach (var item in colors)
            {
                _context.ProductColors.Add(new()
                {
                    Color = item,
                    ProductId = product.Id
                });
            }

            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteSubImg(int productId, int subImgId)
    {
        var productSubImg = _context.ProductSubImgs.SingleOrDefault(e => e.ProductId == productId && e.Id == subImgId);
        if (productSubImg is null) return NotFound();

        if (productSubImg is not null)
        {
            var filePath = _fileUpload.GetFullPathName(productSubImg.SubImg, FileType.Img, EntityType.productSubImg);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        _context.ProductSubImgs.Remove(productSubImg);
        _context.SaveChanges();

        return RedirectToAction(nameof(Edit), new { id = productId });
    }

    public IActionResult Delete(int id)
    {
        var product = _context.Products/*.AsNoTracking()*/.SingleOrDefault(e => e.Id == id);
        if (product is null) return NotFound();

        if (product.MainImg is not null)
        {
            var filePath = _fileUpload.GetFullPathName(product.MainImg, FileType.Img, EntityType.product);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        #region SubImgs
        // 1. retrieve old sub imgs
        var productSubImgs = _context.ProductSubImgs.Where(e => e.ProductId == product.Id);

        // 2. delete them from wwwroot
        foreach (var productSubImg in productSubImgs)
        {
            if (productSubImg is not null)
            {
                var filePath = _fileUpload.GetFullPathName(productSubImg.SubImg, FileType.Img, EntityType.productSubImg);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
        // 3. delete them from db
        _context.ProductSubImgs.RemoveRange(productSubImgs);
        #endregion

        #region Colors
        // 1. retrieve old colors
        var productColors = _context.ProductColors.Where(e => e.ProductId == product.Id);

        // 2. delete them from db
        _context.ProductColors.RemoveRange(productColors);
        #endregion

        _context.SaveChanges();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Uploads an image file to the server and returns the generated file name.
    /// </summary>
    /// <param name="mainImg">The image file to upload.</param>
    /// <param name="entityType">The entity type that the image belongs to.</param>
    /// <returns>The generated file name of the uploaded image.</returns>
    private async Task<string> UploadImgsAsync(IFormFile mainImg, EntityType entityType)
    {
        var fileName = _fileUpload.GetFullFileName(mainImg.FileName);
        var filePath = _fileUpload.GetFullPathName(fileName, FileType.Img, entityType);
        await _fileUpload.UploadAsync(filePath, mainImg);
        return fileName;
    }
}