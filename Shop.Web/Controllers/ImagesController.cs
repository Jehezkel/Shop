using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Images.Command;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class ImagesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ProductImage>> Upload(IFormFile uploadedImage)
        {
            return await Mediator.Send(new UploadImageCommand
            {
                UploadedImage = uploadedImage
            });
        }
    }
}