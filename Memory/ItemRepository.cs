﻿using Store;

namespace Memory;

public class ItemRepository : IItemRepository
{
    private readonly Item[] _items =
    [
        new Item(1, "Капитошка", 100, 1000, false, "Игрушка для детей"),
        new Item(2, "1000 рублей с красивым номером", 10000, 1,false,"1000 рублевая купюра с номером 7777777777"),
        new Item(3, "3 литровые банки 10 шт", 700, 14, false, "Добротные банки для консервирования"),
        new Item(4, "Карл Маркс \"Капитал\"", 1499, 69, false, "Книжка, которая сделает тебя богатым")
    ];
    
    public Item[] GetAllByTitleOrDescription(string query)
    {
        return _items.Where(item =>
            item.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
            item.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToArray();
    }

    public Item? GetById(int id)
    {
        return _items.SingleOrDefault(product => product.Id == id);
    }

    public Item[] GetAllByIds(IEnumerable<int> ids)
    {
        var result = from item in _items join itemId in ids on item.Id equals itemId select item;
        
        return result.ToArray();
    }
}