using Microsoft.AspNetCore.Mvc;
using MDDPlatform.Diagrams.Application.Dtos;
using MDDPlatform.Diagrams.Services.PlantUMLs;
using MDDPlatform.Diagrams.Application.ModelEngines;

namespace MDDPlatform.Diagrams.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantUMLController : ControllerBase
{
    private readonly IPlantUMLService _plantUMLService;
    private readonly IConfiguration configuration;
    private readonly IModelEngineService _modelEngineService;

    public PlantUMLController(IPlantUMLService plantUMLService, IConfiguration configuration, IModelEngineService modelEngineService)
    {
        _plantUMLService = plantUMLService;
        this.configuration = configuration;
        _modelEngineService = modelEngineService;
    }

    [HttpGet("ObjectDiagram/{domainModelId}")]
    public async Task<DiagramDto?> ShowObjectDiagram(Guid domainModelId)
    {
        var diagram = await _plantUMLService.DrawObjectDigramAsync(domainModelId);
        if(Equals(diagram,null)) return null;

        var plantUmlService =  configuration["Services:PlantUmlExternalService"];
        return DiagramDto.CreateFrom(diagram,plantUmlService);
    }
    [HttpGet("ClassDiagram/{domainModelId}")]
    public async Task<DiagramDto?> ShowClassDiagram(Guid domainModelId)
    {
        var diagram = await _plantUMLService.DrawClassDiagramAsync(domainModelId);
        if(Equals(diagram,null)) return null;

        var plantUmlService =  configuration["Services:PlantUmlExternalService"];
        return DiagramDto.CreateFrom(diagram,plantUmlService);
    }
    
    [HttpGet("ObjectDiagram/{baseModelId}/Compare/{otherModelId}")]
    public async Task<ModelDifferenceDto> CompareObjectDigrams(Guid baseModelId,Guid otherModelId){
        return await _modelEngineService.CompareObjectDigramAsync(baseModelId,otherModelId);
    }
    [HttpGet("ClassDiagram/{baseModelId}/Compare/{otherModelId}")]
    public async Task<ModelDifferenceDto> CompareClassDigrams(Guid baseModelId,Guid otherModelId){
        return await _modelEngineService.CompareClassDiagramAsync(baseModelId,otherModelId);
    }

}
