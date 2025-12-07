using FigureShopSharedLibrary.Contracts;
using FigureShopSharedLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FigureShopServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProduct productService;
        public ProductController(IProduct productService)
        {
            this.productService = productService;
        }
        //return Ok(product);           ---> 200 OK
        //return BadRequest("Error");   ---> 400 Bad Request
        //return NotFound();            ---> 404 Not Found
        //return StatusCode(500);       ---> 500 Server error
        // ko dùng datatype actionresult → API rất khó kiểm soát lỗi.
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured)
        {
            // var để trình biên dịch tự suy ra kiểu dữ liệu --> var product = await productService.GetAllProducts(featured);
            List<Product> product = await productService.GetAllProducts(featured);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product model)
        {
            if(model == null) return BadRequest("product null");
            var respone = await productService.AddProduct(model);
            return Ok(respone);

        }
    }
}
