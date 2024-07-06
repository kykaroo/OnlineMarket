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

        if (GetItem(id, out var item, out var actionResult)) return actionResult!;

        order.AddItem(item!, numberOfItems);
        
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }
    
    private bool GetItem(int id, out Item? item, out IActionResult? actionResult)
    {
        item = itemRepository.GetById(id);

        if (item == null)
        {
            {
                actionResult = BadRequest($"No item with ID \"{id}\" found");
                return true;
            }
        }

        actionResult = null;
        return false;
    }
    
    [HttpDelete]
    public IActionResult RemoveItemInOrder(int id)
    {
        var order = orderRepository.GetById(1);
        
        if (order == null)
        {
            return BadRequest("You not order anything yet");
        }
        
        if (GetItem(id, out var item, out var actionResult)) return actionResult!;
        
        if (!order.TryRemoveItem(item!, out var errorMessage))
        {
            return BadRequest(errorMessage);
        }
        
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }
}