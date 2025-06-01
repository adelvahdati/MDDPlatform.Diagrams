using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class Operation : ValueObject
{
    public string Name { get; set; }
    public List<OperationInput> Inputs { get; set; }
    public OperationOutput Output { get; set; }
    public List<Attribute> Attributes { get; set; }
    public string FlattenInputs => string.Join(",",Inputs.Select(inp=>inp.ToString()).ToArray());

    public Operation(string name, List<OperationInput> inputs, OperationOutput output, List<Attribute>? attributes = null)
    {
        Name = name;
        Inputs = inputs;
        Output = output;
        Attributes = attributes == null ? new() : attributes;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Inputs.ToHashSet();
        yield return Output;
        yield return Attributes.ToHashSet();
    }
}
