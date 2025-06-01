using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;

public class OperationInput : ValueObject
{
    public string Name { get; set;}
    public string Type { get; set;}

    public OperationInput(string name, string type)
    {
        Name = name;
        Type = type;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Type;
    }
    public override string ToString()
    {
        return string.Format("{0} {1}",Type,Name);
    }
}
