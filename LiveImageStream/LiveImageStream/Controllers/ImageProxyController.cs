using LiveImageStream.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageProxyController : ControllerBase
    {
        private static byte[]? _latestImage = null;
        private static readonly object _imageLock = new();

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadDto dto)
        {
            if (dto.Image == null || dto.Image.Length == 0)
                return BadRequest("Image is missing.");

            using var ms = new MemoryStream();
            await dto.Image.CopyToAsync(ms);

            lock (_imageLock)
            {
                _latestImage = ms.ToArray(); // Store in memory
            }

            return Ok(new { message = "Image received" });
        }

        [HttpGet("latest")]
        public IActionResult GetLatestImage()
        {
            lock (_imageLock)
            {
                if (_latestImage == null)
                    return NotFound("No image available.");

                return File(_latestImage, "image/jpeg");
            }
        }
    }
}
