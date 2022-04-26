using DocConverter.Core.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace DocConverter.Core.Adapters;

public class XML2JsonAdapter : IConvertAdapter
{    
    private readonly bool withDeclarations;
    XmlDocument? doc;

    public XML2JsonAdapter(bool withDeclarations = false)
    {
        this.withDeclarations = withDeclarations;
    }

    public string Convert(string input)
    {
        LoadDocument(input);
        TransformDocument();
        return SerializeDocument();
    }

    protected virtual void LoadDocument(string input)
    {
        doc = new XmlDocument();
        doc.LoadXml(input);
    }

    protected virtual void TransformDocument()
    {
        if (!withDeclarations)
        {
            var declarations = doc?.ChildNodes.OfType<XmlNode>()
                .Where(x => x.NodeType == XmlNodeType.XmlDeclaration)
                .ToList();
            declarations?.ForEach(x => doc?.RemoveChild(x));
        }
    }

    protected virtual string SerializeDocument()
    {
        return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
    }
}
