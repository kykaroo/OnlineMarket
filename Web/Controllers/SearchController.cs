using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController(IProductRepository productRepository) : Controller
{
    [HttpGet]
    public IActionResult Index(string query)
    {
       return Ok(productRepository.GetAllByTitle(query));
    }
}