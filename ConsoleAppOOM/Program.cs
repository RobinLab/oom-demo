namespace ConsoleAppOOM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello, World!");
                var q = Console.ReadLine();
                if(q == "q")
                {
                    break;
                }
            }
        }
    }
}
