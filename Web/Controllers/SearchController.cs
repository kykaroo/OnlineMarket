using App;
using Microsoft.AspNetCore.Mvc;

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