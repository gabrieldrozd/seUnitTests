using Client;
using Xunit;
using Xunit.Abstractions;
using Xunit.Repeat;

namespace UnitTests;

public class SetOperationsUnitTests
{
    private readonly ITestOutputHelper _output;
    private readonly SetOperations _setOperations;

    public SetOperationsUnitTests(ITestOutputHelper output)
    {
        _output = output;
        _setOperations = new SetOperations(new[] {1, 3, 5, 6, 7, 9, 13, 17, 20, 28});
    }

    [Fact]
    public void AddToSet_Should_Pass()
    {
        var initialSetLength = _setOperations.PobierzRozmiar();
        _setOperations.Dodaj(21);
        Assert.Equal(initialSetLength + 1, _setOperations.PobierzRozmiar());
        _output.WriteLine($"Initial size: {initialSetLength}\nAdded: 1 number\nCurrent size: {_setOperations.PobierzRozmiar()}");
    }

    [Fact]
    public void RemoveFromSet_Should_Pass()
    {
        var initialSetLength = _setOperations.PobierzRozmiar();
        _setOperations.Usun(28);
        Assert.Equal(initialSetLength - 1, _setOperations.PobierzRozmiar());
        _output.WriteLine($"Initial size: {initialSetLength}\nRemoved: 1 number\nCurrent size: {_setOperations.PobierzRozmiar()}");
    }

    [Fact]
    public void RemoveFromSet_Should_ThrowError()
    {
        Assert.Throws<Exception>(() => _setOperations.Usun(29));
    }

    [Theory]
    [Repeat(10)]
    public void DrawFromSet_ShouldReturn_Number(int value)
    {
        var drawResult = _setOperations.Losuj();
        Assert.Equal(typeof(int), drawResult.GetType());
        _output.WriteLine(drawResult.ToString());
    }

    [Fact]
    public void GetSum_ShouldReturn_Number()
    {
        var setNumbersSum = _setOperations.PobierzSume();
        Assert.Equal(typeof(int), setNumbersSum.GetType());
        _output.WriteLine(setNumbersSum.ToString());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DivideSetElementsTheoryTest(int value)
    {
        var setNumbersSum = _setOperations.PobierzSume();
        
        switch (value)
        {
            case 0:
                var test = Assert.Throws<DivideByZeroException>(() => _setOperations.IlorazElem(value));
                _output.WriteLine(test.Message);
                break;
            case 1:
                _setOperations.IlorazElem(value);
                Assert.Equal(setNumbersSum, _setOperations.PobierzSume());
                break;
            case > 1:
                _setOperations.IlorazElem(value);
                Assert.NotEqual(setNumbersSum, _setOperations.PobierzSume());
                break;
        }
        
        _output.WriteLine(setNumbersSum.ToString() + ' ' + _setOperations.PobierzSume());
    }

    [Fact]
    public void CheckNumberInSet_ShouldReturnTrue()
    {
        var checkResult = _setOperations.Sprawdz(1);
        Assert.True(checkResult);
        _output.WriteLine(checkResult.ToString());
    }
    
    [Fact]
    public void CheckNumberNotInSet_ShouldReturnFalse()
    {
        var checkResult = _setOperations.Sprawdz(999);
        Assert.False(checkResult);
        _output.WriteLine(checkResult.ToString());
    }

    [Fact]
    public void GetSize_ShouldReturn_Number()
    {
        var result = _setOperations.PobierzRozmiar();
        Assert.Equal(typeof(int), result.GetType());
    }
    
    [Fact]
    public void GetSize_ShouldReturn_Number_BiggerThanZero()
    {
        var result = _setOperations.PobierzRozmiar();
        Assert.True(result > 0);
    }
}