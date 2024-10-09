using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository _repository;
        public ImagesController(IImageRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await _repository.UploadAsync(file);
            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)System.Net.HttpStatusCode.InternalServerError);
            }
            return Json(new { link = imageUrl });
        }
    }
}
