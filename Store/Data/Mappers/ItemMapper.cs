namespace Store.Data.Mapper;

public static class ItemMapper
{
    public static Item Map(ItemData itemData) => new(itemData);
    public static ItemData Map(Item item) => item._item;
}