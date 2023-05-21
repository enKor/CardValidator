using System.Collections.Generic;
using CardValidator.Helpers;
using Xunit;

namespace CardValidator.Tests;

public class ListHelperTests
{
    [Fact]
    public void AddRange_AddsRangeToList()
    {
        // Arrange
        var list = new List<string>();

        // Act
        var result = list.AddRange(1, 3);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal("1", list[0]);
        Assert.Equal("2", list[1]);
        Assert.Equal("3", list[2]);
        Assert.Same(list, result);
    }
    
    [Theory]
    [InlineData(1, 1, "1")]
    [InlineData(1, 10, "1", "2", "3", "4", "5", "6", "7", "8", "9", "10")]
    [InlineData(2, 1)]
    public void AddRange_AddsRangeToListVariants(int start, int end, params string[] expectedItems)
    {
        var results = new List<string>().AddRange(start, end);
        Assert.Equal(expectedItems, results);
    }

    [Fact]
    public void AddRange_ReturnsSameListInstance()
    {
        // Arrange
        var list = new List<string>();

        // Act
        var result = list.AddRange(1, 3);

        // Assert
        Assert.Same(list, result);
    }
}