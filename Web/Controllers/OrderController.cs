using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IProductRepository productRepository, IOrderRepository orderRepository) : Controller
{
    [HttpPost]
    public IActionResult Add(int id, int numberOfItems)
    {
        if (numberOfItems <= 0)
        {
            return BadRequest("Trying to add <= 0 items to order");
        }
        
        var order = orderRepository.GetById(1) ?? orderRepository.CreateOrder();

        var item = productRepository.GetAllById(id.ToString());
        
        order.AddItem(item[0], numberOfItems);
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }
}