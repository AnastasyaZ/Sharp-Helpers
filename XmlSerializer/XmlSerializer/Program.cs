using System.Drawing;

namespace XmlSerializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var obj = new Rectangle(1, 1, 3, 8);
            obj.SerializeToFile("serializedData.txt");
        }
    }
}
