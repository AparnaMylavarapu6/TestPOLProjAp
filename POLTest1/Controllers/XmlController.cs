using System.Xml;

namespace RentersInsuranceApiTests.Controllers
{
    internal class XmlController
    {
        private readonly XmlDocument doc;

        public XmlController(string path)
        {
            doc = new XmlDocument();
            doc.Load(path);
        }

        public string readElement(string path)
        {
            var node = doc.DocumentElement.SelectSingleNode(path);
            return node.InnerText;
        }
    }
}