internal class Program
{
    private static void Main(string[] args)
    {
        Lazy<LargeObject> lazyObject = new();
        Console.WriteLine("Would you like to call the large object value?");
        Console.ReadLine();

        Console.WriteLine(lazyObject.Value.Data);
    }

    public class LargeObject
    {
        public LargeObject()
        {
            Console.WriteLine("Initializing large object");
            Thread.Sleep(5000);
            Data = "This is some data";
            Console.WriteLine("Large Object has been initialized");
        }

        public string Data { get; set; }
    }
}
