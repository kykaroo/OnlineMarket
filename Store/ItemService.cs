namespace Store;

public class ItemService(IItemRepository itemRepository)
{
    public Item[] GetAllByQuery(string query)
    {
        if (Item.IsId(query))
        {
            query = query[2..];
            
            return [itemRepository.GetById(int.Parse(query))];
        }

        return itemRepository.GetAllByTitleOrDescription(query);
    }
}