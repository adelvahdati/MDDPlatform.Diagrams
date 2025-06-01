using MDDPlatform.Diagrams.Core.Utils;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Diagrams.Core.Entities;
public class PlantUMLDiagram : BaseEntity<Guid>
{
    private string diagramTextEncode;

    public string Title { get; private set; }
    public string Code { get; private set; }
    public DiagramType Type {get;private set;}

    public string SVGImageRelativeUrl => string.Format("/svg/{0}",diagramTextEncode);
    public string PNGImageRelativeURL => string.Format("/svg/{0}",diagramTextEncode);

    public PlantUMLDiagram(Guid domainModelId,string title, string code,DiagramType type)
    {
        Id = domainModelId;
        Title = title;
        Code = code;
        Type = type;
        diagramTextEncode = PlantUMLTextEncoder.Encode(code);
    }

    public string EncodeText()
    {
        return diagramTextEncode;
    }
}
public enum DiagramType
{
    ClassDiagram,
    ObjectDiagram    
}
