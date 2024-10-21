using Bloggie.Web.Repositories.Interfaces;
using CloudinaryDotNet;
using System;

namespace Bloggie.Web.Repositories.Implementations
{
    public class ImageRepositoryCloudinary : IImageRepository
    {
        private readonly Account _account;

        public ImageRepositoryCloudinary(IConfiguration configuration)
        {
            //Use this if config in .env file
            _account = new Account
            {
                Cloud = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME"),
                ApiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY"),
                ApiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET"),
            };

            /* Use this if config in appsettings.json
            _account = new Account
            {
                Cloud = configuration["Cloudinary:CloudName"],
                ApiKey = configuration["Cloudinary:ApiKey"],
                ApiSecret = configuration["Cloudinary:ApiSecret"]
            };
            */
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(_account);
            var uploadFileResult = await client.UploadAsync(
                new CloudinaryDotNet.Actions.ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    DisplayName = file.FileName
                });

            if (uploadFileResult != null && uploadFileResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadFileResult.SecureUrl.ToString();
            }
            return null;
        }
    }
}
