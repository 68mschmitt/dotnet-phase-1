internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Normal Async Await");
        Console.WriteLine($"[Before Await] Thread ID: {Environment.CurrentManagedThreadId}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
        await BoilWaterAsync().ConfigureAwait(false);
        Console.WriteLine($"[Before Await] Thread ID: {Environment.CurrentManagedThreadId}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("ConfigureAwait(false)");
        Console.WriteLine($"[Before Await] Thread ID: {Environment.CurrentManagedThreadId}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
        await BoilWaterAsync().ConfigureAwait(false);
        Console.WriteLine($"[Before Await] Thread ID: {Environment.CurrentManagedThreadId}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    }

    private static async Task BoilWaterAsync()
    {
        Console.WriteLine("Starting the kettle");

        await Task.Delay(1000);

        Console.WriteLine("Water is boiling");
    }
}

/*
 * Conceptually, how would I go about doing this?
 * The challenge?
 * Call an async function using the async/await keywords and have the task be configured to resume
 * on any thread. Not just the main one
 *
 * I guess the easy part is to just create an async method that has a task.delay and call it with a
 * configureawait(false)
 *
 * How to test to show it is doing what we want it to do?
 *
 * Could print out a message saying that the awaited function should print first
 * Then while we are waiting, we can perform a synchronous process on the main thread
 *
 * Since the awaited task will want to resume on the main thread, it will not resume
 * until the main thread process completes
 *
 * Then we call it with configureawait(false) to show that it will output as we want, on a different thread
 */
