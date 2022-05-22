namespace Client.Stack;

public class StackEmptyException : Exception
{
    public StackEmptyException(string message = "Stos jest pusty") : base(message)
    {
    }
}