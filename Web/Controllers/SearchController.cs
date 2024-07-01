using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController(ProductService productService) : Controller
{
    [HttpGet]
    public IActionResult Index(string query)
    {
       return Ok(productService.GetAllByQuery(query));
    }
}