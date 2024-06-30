using Store;

namespace Memory;

public class ProductRepository : IProductRepository
{
    private readonly Product[] _products =
    [
        new Product(1, "Капитошка", 100),
        new Product(2, "1000 рублей с красивым номером", 10000),
        new Product(3, "3 литровые банки 10 шт", 700)
    ];
    
    public Product[] GetAllByTitle(string titlePart)
    {
        return _products.Where(product => product.Title.Contains(titlePart)).ToArray();
    }
}