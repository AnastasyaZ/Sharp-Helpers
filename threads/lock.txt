
    internal class Program
    {
        private string commonVariable = "methods done: ";
        private readonly object obj=new object();
        /*
         * locked object should be reference type
         * can't use commonVariable of type string because it's changed into programm
         */

        private void MakeWork(int n)
        {
            lock (obj)
            {
                Thread.Sleep(500);
                commonVariable += $" {n}";
                Console.WriteLine(commonVariable);
            }
        }

        public static void Main()
        {
            var exemplar=new Program();
            Parallel.For(0, 10, exemplar.MakeWork);
        }
    }