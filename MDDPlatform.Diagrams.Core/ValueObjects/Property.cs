using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class Property : ValueObject
{
    public string Name { get; set; }
    public string Type { get; set; }
    public bool IsCollection { get; set; } = false;
    public string? Value { get; set; }
    public List<Attribute> Attributes { get; set; }

    public Property(string name, string type, bool isCollection, string? value, List<Attribute> attributes)
    {
        Name = name;
        Type = type;
        IsCollection = isCollection;
        Value = value;
        Attributes = attributes;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Type;
        yield return IsCollection;
        yield return Value==null? "[NULL]" : Value;
        yield return Attributes.ToHashSet();
    }
}
