namespace Bloggie.Web.Repositories.Interfaces
{
    public interface IImageRepository
    {
        public Task<string> UploadAsync(IFormFile file);
    }
}
