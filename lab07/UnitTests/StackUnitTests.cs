using Client.Stack;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests;

public class StackUnitTests
{
    private readonly ITestOutputHelper _output;
    public readonly Client.Stack.Stack<int> _myStack;

    public StackUnitTests(ITestOutputHelper output)
    {
        _output = output;
        _myStack = new Client.Stack.Stack<int>(5);
    }

    [Theory]
    [InlineData(8)]
    [InlineData(52)]
    [InlineData(21)]
    [InlineData(37)]
    public void PushToStack_GetTopElement_ShouldReturnSame(int value)
    {
        _myStack.Push(value);
        var popResult = _myStack.Pop();
        Assert.Equal(value, popResult);
        _output.WriteLine(popResult.ToString());
    }

    [Fact]
    public void IfStackEmpty_PopShouldThrow_StackEmptyException()
    {
        Assert.Throws<StackEmptyException>(() => _myStack.Pop());
    }

    [Fact]
    public void IfStackEmpty_TopShouldThrow_StackEmptyException()
    {
        Assert.Throws<StackEmptyException>(() => _myStack.Top());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_If_TopLessThanZero()
    {
        Assert.True(_myStack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_If_TopGreaterOrEqualThanZero()
    {
        _myStack.Push(2);
        Assert.False(_myStack.IsEmpty());
    }
}