namespace Store;

public interface IProductRepository
{
    public Product[] GetAllByTitle(string titlePart);
}