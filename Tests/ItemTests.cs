using Store;

namespace Tests;

public class ItemTests
{
    [Fact]
    public void IsId_Null_False()
    {
        Assert.False(Item.TryFormatId(null!, out var id));
    }

    [Fact]
    public void IsId_Empty_False()
    {
        Assert.False(Item.TryFormatId(string.Empty, out var id));
    }
    
    [Fact]
    public void IsId_Space_False()
    {
        Assert.False(Item.TryFormatId(" ", out var id));
    }
    
    [Fact]
    public void IsId_MultipleSpaces_False()
    {
        Assert.False(Item.TryFormatId("      ", out var id));
    }

    [Fact]
    public void IsId_Correct_True()
    {
        Assert.True(Item.TryFormatId("ID 2", out var id));
    }
    
    [Fact]
    public void IsId_MultipleNumber_True()
    {
        Assert.True(Item.TryFormatId("ID 2456231", out var id));
    }
    
    [Fact]
    public void IsId_Dash_True()
    {
        Assert.True(Item.TryFormatId("ID-2", out var id));
    }
    
    [Fact]
    public void IsId_LowerCase_True()
    {
        Assert.True(Item.TryFormatId("id 11", out var id));
    }
    
    [Fact]
    public void IsId_TrashStart_False()
    {
        Assert.False(Item.TryFormatId("xxx ID 1 xxx", out var id));
    }
}