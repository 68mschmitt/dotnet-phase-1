// Write a method that parses and transforms a byte array using Span<byte> with no allocations
// Also write something using Memory<T>

using System.Diagnostics;

namespace SpanConsole;

public partial class Program
{
    public static void Main()
    {
        // Heap based solution
        CowSay("Heap", SpanFromArrayHeapBased());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        // Stack based solution
        CowSay("Stack", SpanFromArrayStackBased());
    }

    private static string SpanFromArrayStackBased()
    {
        var sw = new Stopwatch();
        sw.Start();
        byte data = 0;
        Span<byte> stackSpan = stackalloc byte[100];
        for (var i = 0; i < stackSpan.Length; i++)
            stackSpan[i] = data++;

        int stackSum = 0;
        foreach (var value in stackSpan)
            stackSum += value;

        sw.Stop();
        return $"The sum is {stackSum} : {sw.Elapsed}";
    }

    private static string SpanFromArrayHeapBased()
    {
        var sw = new Stopwatch();
        sw.Start();
        var array = new byte[100];
        var arraySpan = new Span<byte>(array);

        byte data = 0;
        for(var i = 0; i < arraySpan.Length; i++)
            arraySpan[i] = data++;

        int arraySum = 0;
        foreach(var value in array)
            arraySum += value;

        return $"The sum is {arraySum} : {sw.Elapsed}";
    }

    private static void CowSay(string processType, string phrase)
    {
       Console.WriteLine(@"  ___________________________________");
       Console.WriteLine($" |{processType, 35}|");
       Console.WriteLine($" |{phrase, 35}|");
       Console.WriteLine(@"  -----------------------------------");
       Console.WriteLine(@"         \   ^__^");
       Console.WriteLine(@"          \  (oo)\_______");
       Console.WriteLine(@"             (__)\       )\/\");
       Console.WriteLine(@"                 ||----w |");
       Console.WriteLine(@"                 ||     ||");
    }
}
