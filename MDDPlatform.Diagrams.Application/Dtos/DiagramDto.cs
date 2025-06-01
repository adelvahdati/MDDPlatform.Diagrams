using MDDPlatform.Diagrams.Core.Entities;

namespace MDDPlatform.Diagrams.Application.Dtos;
public class DiagramDto
{
    public string Title {get;private set;}
    public string Code {get;private set;}
    public string URLComponent {get;private set;}
    public string SVGImageUrl => string.Format("{0}/svg/{1}",base_url,URLComponent);
    public string PNGImageUrl => string.Format("{0}/png/{1}",base_url,URLComponent);

    // private string base_url = "http://localhost:8080";
    private string base_url;
    
    private DiagramDto(string title, string code,string urlComponent,string plantUmlServcie)
    {
        this.Title = title;
        this.Code = code;
        this.URLComponent = urlComponent;
        base_url = plantUmlServcie;
    }
    public static DiagramDto CreateFrom(PlantUMLDiagram diagram,string plantUmlService)
    {
        return new DiagramDto(diagram.Title,diagram.Code,diagram.EncodeText(),plantUmlService);
    }

}