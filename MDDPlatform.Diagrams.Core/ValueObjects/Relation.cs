using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class Relation : ValueObject
{
    private RelationTarget _target;
    public string Name { get; set;}
    public string Target { get; set;}
    public string Multiplicity { get; set;}

    public string RelationTargetName => _target.Name;
    public string RelationTargetType => _target.Type;

    public Relation(string name, string target, string multiplicity)
    {
        Name = name;
        Target = target;
        Multiplicity = multiplicity;
        _target = RelationTarget.Create(target);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Target;
        yield return Multiplicity;
    }
}