namespace InfoGem.Repositories;

public class EFFileRepository : IFileRepository
{

    private readonly string[] _permittedExtensions = { ".png", ".jpeg", ".jpg", ".avif", ".svg", ".webp" };
    private readonly string _uploadsFolderPath = "wwwroot/uploads";

    public bool RemoveFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        else return false;
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}{DateTime.UtcNow:yyyyMMddHHmmssfff}{GetFileExtension(file)}";
        var filePath = Path.Combine(_uploadsFolderPath, fileName);

        using (var stream = File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }

    public async Task<ICollection<string>> UploadFiles(IFormFileCollection files)
    {
        List<string> filePaths = new List<string>();

        foreach (var file in files)
        {
            await UploadFile(file);
            filePaths.Add(file.FileName);
        }
        return filePaths;
    }

    public bool IsFileAnImage(IFormFile file)
    {
        var extension = GetFileExtension(file);

        return (string.IsNullOrEmpty(extension)
        || !_permittedExtensions.Contains(extension)) ? false : true;
    }
    public string GetFileExtension(IFormFile file) =>
        Path.GetExtension(file.FileName).ToLowerInvariant();
}