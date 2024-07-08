using App;
using Microsoft.AspNetCore.Mvc;
using Store;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IItemRepository itemRepository, IOrderRepository orderRepository) : Controller
{
    [HttpPost("AddItems")]
    public IActionResult AddItemsToOrder(int id, int numberOfItems)
    {
        if (numberOfItems <= 0)
            return BadRequest("Trying to add <= 0 items to order");
        
        var item = itemRepository.GetById(id);

        if (item == null)
            return BadRequest($"Item with ID \"{id}\" not found");
        
        var order = orderRepository.GetById(1) ?? orderRepository.CreateOrder();

        if (order.Items.TryGet(id, out var orderItem))
            orderItem.Count += numberOfItems;
        else
            order.Items.Add(id, numberOfItems, item.Price);
        
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }
    
    [HttpDelete("RemoveAllItems")]
    public IActionResult RemoveAllItemsInOrder(int id)
    {
        var order = orderRepository.GetById(1);
        
        if (order == null)
        {
            return BadRequest("You not order anything yet");
        }

        if (!order.Items.TryRemoveAllItems(id))
        {
           return BadRequest($"You not ordered item with ID \"{id}\" yet");
        }
        
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }

    [HttpDelete("RemoveItems")]
    public IActionResult RemoveItemsInOrder(int id, int numberToRemove)
    {
        if (numberToRemove <= 0)
        {
            return BadRequest("Trying to remove <= 0 items in order");
        }
        
        var order = orderRepository.GetById(1);

        if (order == null)
        {
            return BadRequest("You not order anything yet");
        }
        
        if (!order.Items.TryRemoveItems(id, numberToRemove))
        {
            return BadRequest($"You not ordered item with ID \"{id}\" yet");
        }
        
        orderRepository.UpdateOrder(order);
        
        return Ok($"Items count: {order.TotalCount}, Total price: {order.TotalPrice}");
    }

    [HttpGet("GetMyOrder")]
    public IActionResult GetMyOrder()
    {
        var order = orderRepository.GetById(1);

        if (order == null)
        {
            return BadRequest("You order with ID \"1\" not found");
        }
        
        var model = Map(order);

        return Ok(model);
    }

    private OrderModel Map(Order order)
    {
        var itemIds = order.Items.Select(item => item.ItemId);
        var items = itemRepository.GetAllByIds(itemIds);

        var itemModels = from orderItem in order.Items
            join item in items on orderItem.ItemId equals item.Id
            select new OrderItemModel
            {
                ItemId = item.Id,
                Title = item.Title,
                Decription = item.Description,
                Count = orderItem.Count,
                Price = orderItem.Price
            };

        return new OrderModel
        {
            Id = order.Id,
            Items = itemModels.ToArray(),
            TotalCount = order.TotalCount,
            TotalPrice = order.TotalPrice
        };
    }
}