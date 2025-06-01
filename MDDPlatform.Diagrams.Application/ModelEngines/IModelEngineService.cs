using MDDPlatform.Diagrams.Application.Dtos;

namespace MDDPlatform.Diagrams.Application.ModelEngines;
public interface IModelEngineService
{
    Task<ModelDifferenceDto> CompareObjectDigramAsync(Guid baseModelId, Guid otherModelId);
    Task<ModelDifferenceDto> CompareClassDiagramAsync(Guid baseModelId,Guid otherModelId);
}