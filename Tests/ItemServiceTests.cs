using Moq;
using Store;

namespace Tests;

public class ItemServiceTests
{
    [Fact]
    public void GetAllByQuery_WithId_CallsGetAllById()
    {
        var itemRepository = new Mock<IItemRepository>();
        itemRepository.Setup(repository => repository.GetById(It.IsAny<int>()))
            .Returns(new Item(1, "", 0, 0, false, ""));
        
        itemRepository.Setup(repository => repository.GetAllByTitleOrDescription(It.IsAny<string>()))
            .Returns([new Item(2, "", 0, 0, false, "")]);

        var itemService = new ItemService(itemRepository.Object);
        const string validId = "ID 1";
        
        var actual = itemService.GetAllByQuery(validId);
        
        Assert.Collection(actual, item => Assert.Equal(1, item.Id));
    }
    
    [Fact]
    public void GetAllByQuery_WithTitleOrDescription_CallsGetAllByTitleOrDescription()
    {
        var itemRepository = new Mock<IItemRepository>();
        itemRepository.Setup(repository => repository.GetById(It.IsAny<int>()))
            .Returns(new Item(1, "", 0, 0, false, ""));
        
        itemRepository.Setup(repository => repository.GetAllByTitleOrDescription(It.IsAny<string>()))
            .Returns([new Item(2, "", 0, 0, false, "")]);

        var itemService = new ItemService(itemRepository.Object);

        const string invalidId = "xID 1";
        var actual = itemService.GetAllByQuery(invalidId);
        
        Assert.Collection(actual, item => Assert.Equal(2, item.Id));
    }
}