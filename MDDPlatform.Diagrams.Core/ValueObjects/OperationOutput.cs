using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;

public class OperationOutput : ValueObject
{
    public string Type { get; set;}
    public bool IsCollection { get; set;}

    public OperationOutput(string type, bool isCollection)
    {
        Type = type;
        IsCollection = isCollection;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return IsCollection;
    }
    public override string ToString()
    {
        if(IsCollection)
            return string.Format("{0}[]",Type);
        else
            return Type;
    }
}
