using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

public class SearchController(IProductRepository productRepository) : Controller
{
    public IActionResult Market(string query)
    {
        var products = productRepository.GetAllByTitle(query);
        return View(products);
    }
}