namespace MaximOS.dbLibs;
using System.Xml;

public class XmlDatabase {
    private XmlDocument xdoc = new();
    private string filePath;

    public XmlDatabase(string basePath) {
        filePath = basePath;
        xdoc.Load(basePath);
    }

    public XmlNodeList GetElementsByTagName(string tagName) {
        return xdoc.GetElementsByTagName(tagName);
    }

    public string[] NodeListToString(XmlNodeList nodeList) {
        List<string> elements = [];
        foreach (XmlNode node in nodeList) {
            elements.Add(node.InnerText);
        }
        return [.. elements];
    }

    public string[] GetStringElementsByTagName(string tagName) {
        return NodeListToString(GetElementsByTagName(tagName));
    }

    public void SetFirstElementText(string tagName, string newText) {
        var nodes = GetElementsByTagName(tagName);
        if (nodes.Count > 0) {
            nodes[0]!.InnerText = newText;
        } else {
            XmlElement newElem = xdoc.CreateElement(tagName);
            newElem.InnerText = newText;
            xdoc.DocumentElement?.AppendChild(newElem);
        }
    }

    public void Save() {
        xdoc.Save(filePath);
    }
}
