namespace Store;

public interface IItemRepository
{
    public Item[] GetAllByTitleOrDescription(string query);

    public Item GetById(int id);
}