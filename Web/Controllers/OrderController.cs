using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IItemRepository itemRepository, IOrderRepository orderRepository) : Controller
{
    [HttpPost]
    public IActionResult AddItemToOrder(int id, int numberOfItems)
    {
        if (numberOfItems <= 0)
        {
            return BadRequest("Trying to add <= 0 items to order");
        }
        
        var order = orderRepository.GetById(1) ?? orderRepository.CreateOrder();

        var item = itemRepository.GetById(id);

        if (item == null)
        {
            return BadRequest($"No item with ID {id} found");
        }
        
        order.AddItem(item, numberOfItems);
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }
}