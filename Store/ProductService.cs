namespace Store;

public class ProductService(IProductRepository productRepository)
{
    public Product[] GetAllByQuery(string query)
    {
        if (Product.IsId(query))
        {
            return productRepository.GetAllById(query[2..]);
        }

        return productRepository.GetAllByTitleOrDescription(query);
    }
}