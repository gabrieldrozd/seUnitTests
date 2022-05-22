using System.Globalization;
using Xunit;
using Client;
using Xunit.Abstractions;

namespace UnitTests;

public class BasicOperationsUnitTests
{
    private readonly ITestOutputHelper _output;


    public BasicOperationsUnitTests(ITestOutputHelper output)
    {
        _output = output;
    }

    // BasicOperations.Add Pass and Fail tests
    [Fact]
    public void AddPassingFact()
    {
        Assert.Equal(4, BasicOperations.Add(2, 2));
    }

    [Fact]
    public void AddFailingFact()
    {
        Assert.NotEqual(2, BasicOperations.Add(2, 2));
    }

    // BasicOperations.Subtract Pass and Fail tests
    [Fact]
    public void SubtractPassingFact()
    {
        Assert.Equal(4, BasicOperations.Subtract(8, 4));
    }

    [Fact]
    public void SubtractFailingFact()
    {
        Assert.NotEqual(8, BasicOperations.Subtract(8, 4));
    }

    // BasicOperations.Multiply Pass and Fail tests
    [Fact]
    public void MultiplyPassingFact()
    {
        Assert.Equal(4, BasicOperations.Multiply(2, 2));
    }

    [Fact]
    public void MultiplyFailingFact()
    {
        Assert.NotEqual(8, BasicOperations.Multiply(2, 2));
    }

    // BasicOperations.Divide Pass and Fail tests
    [Fact]
    public void DividePassingFact()
    {
        Assert.Equal(4, BasicOperations.Divide(8, 2));
    }

    [Fact]
    public void DivideByZeroFailingFactTest()
    {
        var ex = Assert.Throws<DivideByZeroException>(() =>
            BasicOperations.Divide(2, 0));
        Assert.IsType<DivideByZeroException>(ex);
    }

    [Theory]
    [InlineData(3, 6, 8)]
    [InlineData(3, 6, 3)]
    [InlineData(5, 12, 18)]
    [InlineData(5, 12, 16)]
    public void AddTheoryTest(int num1, int num2, int result)
    {
        Assert.NotEqual(result, BasicOperations.Add(num1, num2));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(3, 2, 1.5)]
    [InlineData(9, 2, 4.5)]
    [InlineData(6, 12, 0.5)]
    public void DivideTheoryTest(int num1, int num2, double result)
    {
        if (num1 != 0 && num2 != 0)
        {
            Assert.NotEqual(result, BasicOperations.Divide(num1, num2));
        }
        else //(num1 == 0 || num2 == 0)
        {
            Assert.Throws<DivideByZeroException>(() => BasicOperations.Divide(num1, num2));
        }

        _output.WriteLine(result.ToString(CultureInfo.InvariantCulture));
    }
}