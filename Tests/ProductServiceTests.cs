using Moq;
using Store;
using Xunit;

namespace Tests;

public class ProductServiceTests
{
    [Fact]
    public void GetAllByQuery_WithId_CallsGetAllById()
    {
        var productRepository = new Mock<IProductRepository>();
        productRepository.Setup(repository => repository.GetAllById(It.IsAny<string>()))
            .Returns([new Product(1, "", 0, 0, false, "")]);
        
        productRepository.Setup(repository => repository.GetAllByTitleOrDescription(It.IsAny<string>()))
            .Returns([new Product(2, "", 0, 0, false, "")]);

        var productService = new ProductService(productRepository.Object);
        const string validId = "ID 1";
        
        var actual = productService.GetAllByQuery(validId);
        
        Assert.Collection(actual, product => Assert.Equal(1, product.Id));
    }
    
    [Fact]
    public void GetAllByQuery_WithTitleOrDescription_CallsGetAllByTitleOrDescription()
    {
        var productRepository = new Mock<IProductRepository>();
        productRepository.Setup(repository => repository.GetAllById(It.IsAny<string>()))
            .Returns([new Product(1, "", 0, 0, false, "")]);
        
        productRepository.Setup(repository => repository.GetAllByTitleOrDescription(It.IsAny<string>()))
            .Returns([new Product(2, "", 0, 0, false, "")]);

        var productService = new ProductService(productRepository.Object);

        const string invalidId = "xID 1";
        var actual = productService.GetAllByQuery(invalidId);
        
        Assert.Collection(actual, product => Assert.Equal(2, product.Id));
    }
}