using System.Text;
using MDDPlatform.Diagrams.Application.Dtos;
using MDDPlatform.Diagrams.Services.PlantUMLs;

namespace MDDPlatform.Diagrams.Application.ModelEngines;
public class ModelEngineService : IModelEngineService
{
    private readonly IPlantUMLService _plantUMlService;

    public ModelEngineService(IPlantUMLService plantUMlService)
    {
        _plantUMlService = plantUMlService;
    }

    public async Task<ModelDifferenceDto> CompareClassDiagramAsync(Guid baseModelId, Guid otherModelId)
    {
        var baseCode = await _plantUMlService.GetClassDiagramTextSyntax(baseModelId);
        var otherCode = await _plantUMlService.GetClassDiagramTextSyntax(otherModelId);

        return BinarySearchApproach(baseModelId,otherModelId,baseCode,otherCode);
    }

    public async Task<ModelDifferenceDto> CompareObjectDigramAsync(Guid baseModelId, Guid otherModelId)
    {
        var baseCode = await _plantUMlService.GetObjectDiagramTextSyntax(baseModelId);
        var otherCode = await _plantUMlService.GetObjectDiagramTextSyntax(otherModelId);

        return BinarySearchApproach(baseModelId,otherModelId,baseCode,otherCode);
    }

    private ModelDifferenceDto BinarySearchApproach(Guid baseModelId, Guid otherModelId,string baseCode, string otherCode){

        char[] delims = new[] { '\r', '\n' };

        var baseCodeLines = baseCode.Trim().ToLower().Split(delims,StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        var otherCodeLines = otherCode.Trim().ToLower().Split(delims,StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        baseCodeLines.Sort((left,right)=> left.CompareTo(right));
        otherCodeLines.Sort((left,right)=> left.CompareTo(right));

        var inclusion = otherCodeLines.Where(line=>baseCodeLines.BinarySearch(line)<0).ToList();
        var exclusion = baseCodeLines.Where(line=>otherCodeLines.BinarySearch(line)<0).ToList();

        return new ModelDifferenceDto(baseModelId,otherModelId,inclusion,exclusion);
    }
}