namespace ECommerce534.Services.IServices;

public interface IFileUpload
{
    string GetFullFileName(string fileName);
    string GetFullPathName(string fileName, FileType fileType, EntityType entityType);
    Task UploadAsync(string filePath, IFormFile file);
}
