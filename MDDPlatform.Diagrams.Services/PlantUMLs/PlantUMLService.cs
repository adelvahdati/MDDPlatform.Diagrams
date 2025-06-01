using MDDPlatform.Diagrams.Core.Entities;
using MDDPlatform.Diagrams.Services.Interfaces;

namespace MDDPlatform.Diagrams.Services.PlantUMLs;

public class PlantUMLService : IPlantUMLService
{
     private readonly IDomainModelService _domainModelService;

    public PlantUMLService(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public async Task<PlantUMLDiagram> DrawClassDiagramAsync(Guid domainModelId)
    {
        var code = await GetClassDiagramTextSyntax(domainModelId);
        return new PlantUMLDiagram(domainModelId,"Class Diagram",code,DiagramType.ClassDiagram);
    }

    public async Task<PlantUMLDiagram> DrawObjectDigramAsync(Guid domainModelId)
    {
        var code = await GetObjectDiagramTextSyntax(domainModelId);
        return new PlantUMLDiagram(domainModelId,"Object Diagram", code,DiagramType.ObjectDiagram);
    }

    public async Task<string> GetClassDiagramTextSyntax(Guid domainModelId)
    {
        var result = await _domainModelService.GetDomainConceptsAsync(domainModelId);
        var domainConcepts = result == null ? new List<DomainConcept>() : result;
        var diagram = new PlantUMLClassDiagram(domainConcepts);
        return  diagram.ToText();
    }

    public async Task<string> GetObjectDiagramTextSyntax(Guid domainModelId)
    {
        var result = await _domainModelService.GetDomainObjectsAsync(domainModelId);
        var domainObjects = result == null? new List<DomainObject>() : result;
        var diagram = new PlantUMLObjectDiagram(domainObjects);
        return  diagram.ToText();           
    }
}