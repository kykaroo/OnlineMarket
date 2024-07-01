namespace Store;

public interface IProductRepository
{
    public Product[] GetAllByTitleOrDescription(string query);

    public Product[] GetAllById(string id);
}