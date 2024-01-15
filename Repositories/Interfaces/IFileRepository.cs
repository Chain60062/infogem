using InfoGem.Models;

namespace InfoGem.Repositories;

public interface IFileRepository
{
    public Task<string> UploadFile(IFormFile file);
    public Task<ICollection<string>> UploadFiles(IFormFileCollection files);
    public bool RemoveFile(string path);
    public bool IsFileAnImage(IFormFile file);
}