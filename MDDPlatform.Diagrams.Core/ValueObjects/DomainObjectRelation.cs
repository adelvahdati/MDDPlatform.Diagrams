using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class DomainObjectRelation : ValueObject
{
    public string RelationName { get; set;}
    public string RelationTarget { get; set;}
    public string Multiplicity { get; set;}
    public List<string> TargetInstances { get; set;}

    public DomainObjectRelation(string relationName, string relationTarget, string multiplicity, List<string> targetInstances)
    {
        RelationName = relationName;
        RelationTarget = relationTarget;
        Multiplicity = multiplicity;
        TargetInstances = targetInstances;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RelationName;
        yield return RelationTarget;
        yield return Multiplicity;
        yield return TargetInstances.ToHashSet();
    }
}
