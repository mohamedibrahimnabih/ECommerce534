using ECommerce534.Services.IServices;

namespace ECommerce534.Services;

public enum FileType
{
    Img,
}

public enum EntityType
{
    brand,
    product
}


public class FileUpload : IFileUpload
{
    public string GetFullFileName(string fileName)
    {
        return $"{Guid.NewGuid().ToString()}-{DateTime.UtcNow.ToString("dd-MM-yyyy-hh-m-ss")}{Path.GetExtension(fileName)}";
    }

    public string GetFullPathName(string fileName, FileType fileType, EntityType entityType)
    {
        if (fileType == FileType.Img)
        {
            switch (entityType)
            {
                case EntityType.brand:
                    return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\brands", fileName);
                case EntityType.product:
                    return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", fileName);
                default:
                    throw new Exception("Invalid entity Type");
            }
        }
        else
        {
            throw new Exception("Invalid file Type");
        }
    }

    public async Task UploadAsync(string filePath, IFormFile file)
    {
        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }
    }
}
