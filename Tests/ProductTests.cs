using Store;

namespace Tests;

public class ProductTests
{
    [Fact]
    public void IsId_Null_False()
    {
        Assert.False(Product.IsId(null!));
    }

    [Fact]
    public void IsId_Empty_False()
    {
        Assert.False(Product.IsId(string.Empty));
    }
    
    [Fact]
    public void IsId_Space_False()
    {
        Assert.False(Product.IsId(" "));
    }
    
    [Fact]
    public void IsId_MultipleSpaces_False()
    {
        Assert.False(Product.IsId("      "));
    }

    [Fact]
    public void IsId_Correct_True()
    {
        Assert.True(Product.IsId("ID 2"));
    }
    
    [Fact]
    public void IsId_MultipleNumber_True()
    {
        Assert.True(Product.IsId("ID 2456231"));
    }
    
    [Fact]
    public void IsId_Dash_True()
    {
        Assert.True(Product.IsId("ID-2"));
    }
    
    [Fact]
    public void IsId_LowerCase_True()
    {
        Assert.True(Product.IsId("id 11"));
    }
    
    [Fact]
    public void IsId_TrashStart_False()
    {
        Assert.False(Product.IsId("xxx ID 1 xxx"));
    }
}