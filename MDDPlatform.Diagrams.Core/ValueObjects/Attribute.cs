using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class Attribute : ValueObject
{
    public string Name { get; set;}
    public string Value { get; set;}

    public Attribute(string name, string value)
    {
        Name = name;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Value;
    }
}