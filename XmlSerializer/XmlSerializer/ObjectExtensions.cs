using System.IO;

namespace XmlSerializer
{
    public static class ObjectExtensions
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(toSerialize.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static void SerializeToFile<T>(this T toSerialize, string file)
            => File.WriteAllText(file, toSerialize.SerializeObject());
    }
}