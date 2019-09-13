using System;
class Program
{
    static void Main(string[] args)
    {
        Program prog = new Program();
        LinkedList<int> d = new LinkedList<int>();

        for (int i = 0; i < 15; i++)
            d.AddFirst(prog.GetRandomNumber(1, 100));
        
        d.Print();
        Console.WriteLine();
        // d.GnomeSort(d);
        d.RecInsertionSort(d, d.Count());
        d.Print();
    }

    private readonly Random getrandom = new Random();
    private int GetRandomNumber(int min, int max)
    {
        lock (getrandom)
        {
            return getrandom.Next(min, max);
        }
    }
}
