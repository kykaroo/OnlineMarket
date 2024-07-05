namespace Store;

public class ItemService(IItemRepository itemRepository)
{
    public Item[] GetAllByQuery(string query)
    {
        if (Item.IsId(query))
        {
            return itemRepository.GetAllById(query[2..]);
        }

        return itemRepository.GetAllByTitleOrDescription(query);
    }
}