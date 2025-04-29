internal class Program
{
    private static void Main()
    {
        CancellationTokenSource? tokenSource = null;
        Task? task = null;

        for (;;)
        {
            if (tokenSource is null || tokenSource.IsCancellationRequested)
            {
                if (GetAndCheckInput("Start new task? - y/n"))
                {
                    tokenSource = new();
                    task = Task.Run(() => DoSomething(tokenSource.Token), tokenSource.Token);
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (GetAndCheckInput("Cancel the task? - y/n"))
                    tokenSource.Cancel();
            }
        }
    }

    public static bool GetAndCheckInput(string message)
    {
        CowSay(message);
        var input = Console.ReadLine();
        if (input is null || !input.ToLowerInvariant().Equals("y")) return false;
        return true;
    }

    public static void DoSomething(CancellationToken token)
    {
        for (var i = 0;; i++)
        {
            if (token.IsCancellationRequested) break;
            Console.WriteLine($"Hello, World! - {i}");
            Thread.Sleep(1000);
        }
    }

    private static void CowSay(string phrase)
    {
       Console.WriteLine(@"  ___________________________________");
       Console.WriteLine($" |{phrase, 35}|");
       Console.WriteLine(@"  -----------------------------------");
       Console.WriteLine(@"         \   ^__^");
       Console.WriteLine(@"          \  (oo)\_______");
       Console.WriteLine(@"             (__)\       )\/\");
       Console.WriteLine(@"                 ||----w |");
       Console.WriteLine(@"                 ||     ||");
    }
}
