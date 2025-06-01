using MDDPlatform.Diagrams.Core.Entities;

namespace MDDPlatform.Diagrams.Services.PlantUMLs;
public interface IPlantUMLService
{
    Task<PlantUMLDiagram> DrawObjectDigramAsync(Guid domainModelId);
    Task<PlantUMLDiagram> DrawClassDiagramAsync(Guid domainModelId);
    Task<string> GetObjectDiagramTextSyntax(Guid domainModelId);
    Task<string> GetClassDiagramTextSyntax(Guid domainModelId);
}