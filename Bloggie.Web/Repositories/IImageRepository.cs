﻿namespace Bloggie.Web.Repositories
{
    public interface IImageRepository
    {
        public Task<string> UploadAsync(IFormFile file);
    }
}
