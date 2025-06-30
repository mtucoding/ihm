using Microsoft.AspNetCore.Http;

namespace LiveImageStream.Models
{
    public class ImageUploadDto
    {
        public IFormFile Image { get; set; }
    }
}
