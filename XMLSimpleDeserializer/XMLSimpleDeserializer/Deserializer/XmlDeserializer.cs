using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace XMLSimpleDeserializer.Deserializer
{
    public class XmlDeserializer
    {
        private XDocument CurrentDocument { get; set; }

        public XmlDeserializer(XmlDocument xmlDocument) => CurrentDocument = XDocument.Parse(xmlDocument.OuterXml);

        public XmlDeserializer(string xmlText) => CurrentDocument = XDocument.Parse(xmlText);

        public T Deserialize<T>(string name = null)
        {
            string rootName = name ?? typeof(T).Name;
            XElement rootElement = null;

            foreach (XElement element in CurrentDocument.Elements())
            {
                if (element.Name == rootName)
                {
                    rootElement = element;
                }
            }

            string jsonText = JsonConvert.SerializeXNode(rootElement);
            RootClass<T> parsedObject = JsonConvert.DeserializeObject<RootClass<T>>(jsonText);

            return parsedObject.MainContent;
        }

        private class RootClass<T>
        {
            public T MainContent { get; set; }
        }
    }
}
