class Program
    {
        static string MakeWork(int n)
        {
            Thread.Sleep(1000);
            return $"done {n}";
        }

        public static void Main()
        {
            Parallel.For(0, 10, n =>Console.WriteLine(MakeWork(n)));
        }
    }