using Store;

namespace Tests;

public class ItemTests
{
    [Fact]
    public void IsId_Null_False()
    {
        Assert.False(Item.IsId(null!));
    }

    [Fact]
    public void IsId_Empty_False()
    {
        Assert.False(Item.IsId(string.Empty));
    }
    
    [Fact]
    public void IsId_Space_False()
    {
        Assert.False(Item.IsId(" "));
    }
    
    [Fact]
    public void IsId_MultipleSpaces_False()
    {
        Assert.False(Item.IsId("      "));
    }

    [Fact]
    public void IsId_Correct_True()
    {
        Assert.True(Item.IsId("ID 2"));
    }
    
    [Fact]
    public void IsId_MultipleNumber_True()
    {
        Assert.True(Item.IsId("ID 2456231"));
    }
    
    [Fact]
    public void IsId_Dash_True()
    {
        Assert.True(Item.IsId("ID-2"));
    }
    
    [Fact]
    public void IsId_LowerCase_True()
    {
        Assert.True(Item.IsId("id 11"));
    }
    
    [Fact]
    public void IsId_TrashStart_False()
    {
        Assert.False(Item.IsId("xxx ID 1 xxx"));
    }
}