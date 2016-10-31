class Program
    {
        static string MakeWork()
        {
            Thread.Sleep(1000);
            return "done";
        }

        public static void Main()
        {
            var func = new Func<string>(MakeWork);
            var result = func.BeginInvoke(null, null);
            while (!result.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }
            Console.WriteLine(func.EndInvoke(result));
        }
    }