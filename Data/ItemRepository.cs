using Microsoft.EntityFrameworkCore;
using Store;
using Store.Data.Mapper;

namespace Data;

public class ItemRepository(DbContextFactory dbContextFactory) : IItemRepository
{
    public Item[] GetAllByTitleOrDescription(string query)
    {
        var dbContext = dbContextFactory.Create(typeof(ItemRepository));

        return dbContext.Items
            .FromSqlRaw("SELECT * FROM Items WHERE CONTAINS((Title, Description), @titleOrDescription)")
            .AsEnumerable().Select(ItemMapper.Map).ToArray();
    }

    public Item? GetById(int id)
    {
        var dbContext = dbContextFactory.Create(typeof(ItemRepository));

        var itemData = dbContext.Items.Single(item => item.Id == id);

        return ItemMapper.Map(itemData);
    }

    public Item[] GetAllByIds(IEnumerable<int> ids)
    {
        var dbContext = dbContextFactory.Create(typeof(ItemRepository));

        return dbContext.Items.Where(item => ids.Contains(item.Id)).AsEnumerable().Select(ItemMapper.Map).ToArray();
    }
}