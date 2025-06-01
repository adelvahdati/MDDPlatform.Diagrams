using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class RelationTargetInstance : ValueObject
{
    private TargetInstance _targetInstance;
    public string RelationName {get;set;}
    public string InstanceName => _targetInstance.Name;
    public string InstanceType => _targetInstance.Type;
    public string InstanceFullName => _targetInstance.FullName;
    public RelationTargetInstance(string relationName, TargetInstance targetInstance)
    {
        RelationName = relationName;
        _targetInstance = targetInstance;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RelationName;
        yield return InstanceFullName;
    }
}