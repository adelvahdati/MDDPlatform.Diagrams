using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class RelationalDimension : ValueObject
{
    public string Name{get; set;}
    public string Target {get; set;}

    public RelationalDimension(string name, string target)
    {
        Name = name;
        Target = target;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Target;
    }
}