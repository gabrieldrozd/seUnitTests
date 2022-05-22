namespace Client;

public class SetOperations
{
    private List<int> Zbior { get; set; }
    // private static int[] Zbior { get; set; } = Array.Empty<int>();
    // private static int Roz;

    public SetOperations(IEnumerable<int> initialArray)
    {
        Zbior = new List<int>(initialArray);
    }

    /// <summary>
    /// Dodaje liczbę n do zbioru liczb. 
    /// Jeżeli podana liczba już istnieje dodawana jest po raz drugi 
    /// </summary>
    /// <param name="n">Do dodania do zbioru</param>
    public void Dodaj(int n)
    {
        Zbior.Add(n);
    }

    /// <summary>
    /// Usuwa liczbę n ze zbioru liczb. 
    /// W przypadku gdy zbiór nie posiada liczby podanej jako parametr rzucany jest wyjątek. 
    /// </summary>
    /// <param name="n">Do usunięcia ze zbioru.</param>
    /// <exception cref="Exception">Jeśli "n" nie znajduje się w zbiorze.</exception>
    public void Usun(int n)
    {
        var result = Zbior.Remove(n);

        if (!result)
        {
            throw new Exception("Number not in Set");
        }    
    }

    /// <summary>
    /// Losuje jedną liczbę ze zbioru, a następnie usuwa ją.
    /// </summary>
    /// <returns>Zwraca usuniętą liczbę</returns>
    public int Losuj()
    {
        var rnd = new Random();
        var numberToDraw = Zbior[rnd.Next(0, Zbior.Count - 1)];
        Zbior.ToList().Remove(numberToDraw);
        return numberToDraw;
    }

    /// <summary>
    /// Zwraca sumę wszystkich liczb ze zbioru. W przypadku pustego zbioru suma wynosi 0.
    /// </summary>
    /// <returns>Zwaraca sumę liczb w zbiorze.</returns>
    public int PobierzSume()
    {
        var setSum = Zbior.Sum();
        return setSum == 0 ? 0 : setSum;
    }

    /// <summary>
    /// Dzieli każdy element ze zbioru przez n bez reszty.
    /// </summary>
    /// <param name="n">Liczba, przez którą będzie wykonane dzielenie.</param>
    public void IlorazElem(int n)
    {
        for (var i = 0; i < Zbior.Count - 1; i++)
        {
            Zbior[i] /= n;
        }

        var sett = Zbior;
    }

    /// <summary>
    /// Sprawdza, czy w zbiorze istnieje element n.
    /// </summary>
    /// <param name="n">Element do sprawdzenia.</param>
    /// <returns>True lub false w zależności, czy element istnieje w zbiorze.</returns>
    public bool Sprawdz(int n)
    {
        var result = Zbior.IndexOf(n) != -1;
        return result;
    }

    /// <summary>
    /// Zwraca rozmiar zbioru (liczbę dodanych elementów)
    /// </summary>
    /// <returns>Rozmiar zbioru</returns>
    public int PobierzRozmiar()
    {
        return Zbior.Count;
    }
}