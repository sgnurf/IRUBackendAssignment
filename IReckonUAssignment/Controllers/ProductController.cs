using IReckonUAssignment.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace IReckonUAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductFileProcessor productFileProcessor;

        public ProductController(IProductFileProcessor productFileProcessor)
        {
            this.productFileProcessor = productFileProcessor;
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Upload(IFormFile productFile)
        {
            if(productFile == null)
            {
                return BadRequest("A Product file must be provided.");
            }

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    productFile.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    await productFileProcessor.ProcessProductFile(memoryStream);
                }

                return Ok();
            }
            catch
            {
                return BadRequest("An error occured while processing the product file.");
            }
        }
    }
}