using System.Diagnostics;
using BenchmarkDotNet.Running;

namespace ValueTaskConsole;

internal class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<CarStateBenchmarks>();
    }

    private async Task RunCarThreadAsync()
    {
        var car = new CarState();

        Console.WriteLine($"=== First (cold) call ===");
        var sw = Stopwatch.StartNew();
        var beforeBytes = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"Value of car: {await car.GetMakeAsync().ConfigureAwait(false)}");
        sw.Stop();
        var afterBytes = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Console.WriteLine($"Before bytes: {beforeBytes}");
        Console.WriteLine($"After bytes: {afterBytes}");
        Console.WriteLine($"Allocated bytes: {afterBytes - beforeBytes}");

        Console.WriteLine();

        Console.WriteLine($"=== Second (cached) call ===");
        beforeBytes = GC.GetAllocatedBytesForCurrentThread();
        sw.Restart();
        Console.WriteLine($"Value of car: {await car.GetMakeAsync().ConfigureAwait(false)} when cached");
        sw.Stop();
        afterBytes = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Console.WriteLine($"Before bytes: {beforeBytes}");
        Console.WriteLine($"After bytes: {afterBytes}");
        Console.WriteLine($"Allocated bytes: {afterBytes - beforeBytes}");
    }
}
