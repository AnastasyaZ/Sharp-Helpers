using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TEST
{

    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    internal class Summator
    {
        private readonly Func<DataSource> openDatasource;
        private readonly ISumFormatter formatter;
        private readonly string outputFilename;

        public Summator(Func<DataSource> openDatasource, ISumFormatter formatter, string outputFilename)
        {
            this.openDatasource = openDatasource;
            this.formatter = formatter;
            this.outputFilename = outputFilename;
        }

        public void Precess()
        {
            var result = SumRecords(openDatasource(), formatter)//исчез вызов Dispose для dataSource
                .AfterEvery(100, n => Console.WriteLine($"processed {n} items"));
            File.WriteAllLines(outputFilename, result);

        }

        public static IEnumerable<string> SumRecords(
            DataSource dataSource,
            ISumFormatter formatter)
        {
            return dataSource.ReadIntRecords(16)
                .Select(args => formatter.Format(args, args.Sum()));
        }
    }

    public static class DatasourceExtensions
    {
        public static IEnumerable<string[]> ReadRecords(this DataSource data)
        {
            return Enumeration.RepeatUntilNull(data.NextRecord);
        }

        public static IEnumerable<int[]> ReadIntRecords(this DataSource data, int radix)
        {
            return data.ReadRecords()
                .Select(record=>record.Select(part => Convert.ToInt32(part, radix)).ToArray());
        }
    }

    public static class Enumeration
    {
        public static IEnumerable<T> RepeatUntilNull<T>(Func<T> getItem)
        {
            return Repeat(getItem).TakeWhile(x => x != null);
        }

        private static IEnumerable<T> Repeat<T>(Func<T> getItem)
        {
            while (true) yield return getItem();
        }

        public static IEnumerable<T> AfterEvery<T>(this IEnumerable<T> source, int period, Action<int> afterNth)
        {
            return source.Select((x, i) =>
            {
                if (i % period == 0) afterNth(i);
                return x;
            });
        }
    }

    public class DataSource : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string[] NextRecord()
        {
            throw new NotImplementedException();
        }
    }

    internal interface ISumFormatter
    {
        string Format(int[] nums, int sum);
    }
}