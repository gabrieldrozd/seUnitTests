namespace Client.Stack;

public class Stack<T> : IStack<T>
{
    private readonly int _capacity;
    private readonly T[] _stack;
    private int _top;
    
    public Stack(int maxElements)
    {
        _capacity = maxElements;
        _stack = new T[_capacity];
        _top = -1;
    }

    public T Pop()
    {
        if (_top > -1)
        {
            var removedElement = _stack[_top];
            _top -= 1;
            return removedElement;
        }

        throw new StackEmptyException();
    }

    public void Push(T item)
    {
        if (_top != _capacity - 1)
        {
            _top += 1;
            _stack[_top] = item;
        }
    }

    public T Top()
    {
        if(_top > -1)
        {
            var element = _stack[_top];
            return element;
        }

        throw new StackEmptyException();
    }

    public bool IsEmpty()
    {
        return _top < 0;
    }
}