using Store;

namespace Data;

public class ItemRepository : IItemRepository
{
    public Item[] GetAllByTitleOrDescription(string query)
    {
        throw new NotImplementedException();
    }

    public Item? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Item[] GetAllByIds(IEnumerable<int> ids)
    {
        throw new NotImplementedException();
    }
}