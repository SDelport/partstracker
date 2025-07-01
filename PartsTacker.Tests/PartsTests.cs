using PartsTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace PartsTacker.Tests;

public class PartsTests
{
    [Fact]
    public void QuantityOnHand_Should_Be_NonNegative()
    {
        var part = new Part
        {
            PartNumber = "P_001",
            Description = "Test",
            QuantityOnHand = -5,
            LocationCode = "pta-1",
            LastStockTake = DateTime.UtcNow
        };

        var context = new ValidationContext(part);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(part, context, results, true);

        Assert.False(isValid);
        Assert.Contains(results, r => r.ErrorMessage!.Contains("Quantity must be equal or larger than 0"));
    }

    [Fact]
    public void Description_Is_Required()
    {
        var part = new Part
        {
            PartNumber = "P-9999",
            Description = "",
            QuantityOnHand = -5,
            LocationCode = "X1",
            LastStockTake = DateTime.UtcNow
        };

        var context = new ValidationContext(part);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(part, context, results, true);

        Assert.False(isValid);
        Assert.Contains(results, r => r.ErrorMessage!.Contains("Required"));
    }

    [Fact]
    public void PartNumber_Is_Required()
    {
        var part = new Part
        {
            PartNumber = "",
            Description = "Test",
            QuantityOnHand = -5,
            LocationCode = "Test",
            LastStockTake = DateTime.UtcNow
        };

        var context = new ValidationContext(part);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(part, context, results, true);

        Assert.False(isValid);
        Assert.Contains(results, r => r.ErrorMessage!.Contains("Required"));
    }

    [Fact]
    public void LocationCode_Is_Required()
    {
        var part = new Part
        {
            PartNumber = "",
            Description = "Test",
            QuantityOnHand = -5,
            LocationCode = "Test",
            LastStockTake = DateTime.UtcNow
        };

        var context = new ValidationContext(part);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(part, context, results, true);

        Assert.False(isValid);
        Assert.Contains(results, r => r.ErrorMessage!.Contains("Required"));
    }
}