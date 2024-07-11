using Store;

namespace App;

public class ItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public Item[] GetAllByQuery(string query)
    {
        return !Item.TryFormatId(query, out var id)
            ? _itemRepository.GetAllByTitleOrDescription(query)
            : [_itemRepository.GetById(id)];
    }

    private ItemModel Map(Item item)
    {
        return new ItemModel
        {
            Id = item.Id,
            Title = item.Title,
            Price = item.Price,
            Stock = item.Stock,
            AdultOnly = item.AdultOnly,
            Description = item.Description
        };
    }

    public ItemModel GetById(int id)
    {
        return Map(_itemRepository.GetById(id));
    }
}