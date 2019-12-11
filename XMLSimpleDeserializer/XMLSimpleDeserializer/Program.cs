using System.Diagnostics;
using System.IO;
using System.Xml;
using XMLSimpleDeserializer.Deserializer;
using XMLSimpleDeserializer.Model;

namespace XMLSimpleDeserializer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stream xmlResouce = LoadResource("Payload.xml");
            XmlDocument document = new XmlDocument();
            document.Load(xmlResouce);

            Debug.WriteLine(document.ToString());

            XmlDeserializer deserializer = new XmlDeserializer(document);

            MainContent parsedContent = deserializer.Deserialize<MainContent>();

            Debug.WriteLine(parsedContent);
        }

        private static Stream LoadResource(string resourceName, string folder = "Assets")
        {
            Stream resourceStream = new FileStream($"{folder}/{resourceName}", FileMode.Open);
            return resourceStream;
        }
    }
}
