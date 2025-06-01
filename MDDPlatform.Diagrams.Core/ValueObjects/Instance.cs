using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class Instance : ValueObject
{
    public Guid Id {get;set;}
    public string Name { get; set;}
    public string Type { get; set;}

    public Instance(Guid id, string name, string type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
        yield return Type;
    }
}