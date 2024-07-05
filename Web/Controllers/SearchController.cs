using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController(ItemService itemService) : Controller
{
    [HttpGet]
    public IActionResult Index(string query)
    {
       return Ok(itemService.GetAllByQuery(query));
    }
}