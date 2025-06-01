namespace MDDPlatform.Diagrams.Application.Dtos;
public class ModelDifferenceDto{
    public Guid BaseModelId {get;private set;}
    public Guid OtherModelId {get;private set;}
    public List<string> Inclusions {get;private set;}
    public List<string> Exclusions {get;private set;}

    public ModelDifferenceDto(Guid baseModelId, Guid otherModelId, List<string> inclusions, List<string> exclusions)
    {
        BaseModelId = baseModelId;
        OtherModelId = otherModelId;
        Inclusions = inclusions;
        Exclusions = exclusions;
    }
}