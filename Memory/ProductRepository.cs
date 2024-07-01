using System;
using System.Linq;
using Store;

namespace Memory;

public class ProductRepository : IProductRepository
{
    private readonly Product[] _products =
    [
        new Product(1, "Капитошка", 100, 1000, false, "Игрушка для детей"),
        new Product(2, "1000 рублей с красивым номером", 10000, 1,false,"1000 рублевая купюра с номером 7777777777"),
        new Product(3, "3 литровые банки 10 шт", 700, 14, false, "Добротные банки для консервирования"),
        new Product(4, "Карл Маркс \"Капитал\"", 1499, 69, false, "Книжка, которая сделает тебя богатым")
    ];
    
    public Product[] GetAllByTitleOrDescription(string query)
    {
        return _products.Where(product =>
            product.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
            product.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToArray();
    }

    public Product[] GetAllById(string id)
    {
        return _products.Where(product => product.Id == int.Parse(id)).ToArray();
    }
}