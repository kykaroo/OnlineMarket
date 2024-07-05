namespace Store;

public interface IItemRepository
{
    public Item[] GetAllByTitleOrDescription(string query);

    public Item[] GetAllById(string id);
}