using System.Globalization;
using Client;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests;

public class BankOperationsUnitTests
{
    private readonly ITestOutputHelper _output;
    private readonly double _currentBalance;


    public BankOperationsUnitTests(ITestOutputHelper output)
    {
        _output = output;
        _currentBalance = BankOperations.AccountBalance;
    }

    [Fact]
    public void GetAccountBalancePassingFactTest()
    {
        Assert.Equal(_currentBalance, BankOperations.GetAccountBalance());
        _output.WriteLine(TestResponseMessage(_currentBalance, BankOperations.GetAccountBalance()));
    }

    [Fact]
    public void GetAccountBalancePassingFactTest_WithDeposit()
    {
        Assert.Equal(BankOperations.Deposit(200), BankOperations.GetAccountBalance());
        _output.WriteLine(TestResponseMessage(
            BankOperations.Deposit(200), BankOperations.GetAccountBalance()));
    }
    
    [Fact]
    public void WithdrawalBalance_IsNotEqual_DepositBalance()
    {
        Assert.NotEqual(BankOperations.Withdrawal(200), BankOperations.Deposit(300));
        _output.WriteLine(TestResponseMessage(
            BankOperations.Withdrawal(200), BankOperations.Deposit(300)));
    }

    [Fact]
    public void CurrentBalance_After_DepositAndWithdrawalTheSameAmount_ShouldBeSameAs_InitialBalance()
    {
        var initialBalance = _currentBalance;
        BankOperations.Deposit(200);
        BankOperations.Withdrawal(200);
        _output.WriteLine(initialBalance.ToString(CultureInfo.InvariantCulture));
        Assert.Equal(initialBalance, BankOperations.GetAccountBalance());
    }

    private string TestResponseMessage(double expected, double actual)
    {
        return $"Expected: {expected}\nActual: {actual}\nResult: {expected == actual}";
    }
}