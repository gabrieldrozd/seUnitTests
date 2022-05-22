namespace Client;

public static class BankOperations
{
    public static double AccountBalance { get; private set; } = 800;

    public static double Withdrawal(double amount)
    {
        AccountBalance -= amount;
        return AccountBalance;
    }

    public static double Deposit(double amount)
    {
        AccountBalance += amount;
        return AccountBalance;
    }

    public static double GetAccountBalance()
    {
        return AccountBalance;
    }
}