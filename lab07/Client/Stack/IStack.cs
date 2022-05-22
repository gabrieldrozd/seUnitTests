namespace Client.Stack;

public interface IStack<T>
{
    /// <summary>
    /// Usuwa i zwraca element znajdujący się na szczycie stosu. 
    /// Generuje wyjątek StackEmptyException gdy stos jest pusty. 
    /// </summary>
    /// <returns>Usunięty element</returns>
    T Pop(); 
    
    /// <summary>
    /// Umieszcza element na szczycie stosu. 
    /// </summary>
    /// <param name="item">Obiekt do dodania.</param>
    void Push(T item);
    
    /// <summary>
    /// Zwraca element znajdujący się na szczycie stosu, ale nie usuwa go stamtąd. 
    /// Generuje wyjątek StackEmptyException gdy stos jest pusty.
    /// </summary>
    /// <returns>Element ze szczytu</returns>
    T Top(); 

    /// <summary>
    /// Zwraca true gdy stos jest pusty.
    /// </summary>
    /// <returns>True gdy stos pusty. False w przeciwnym razie</returns>
    bool IsEmpty();
}