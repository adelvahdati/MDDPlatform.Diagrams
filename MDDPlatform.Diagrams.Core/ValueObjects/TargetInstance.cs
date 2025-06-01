using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Diagrams.Core.ValueObjects;
public class TargetInstance : ValueObject
{
    public string Name {get;set;}
    public string Type {get;set;}
    public string FullName => string.Format("{0}.{1}",Name,Type);

    private TargetInstance(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public static TargetInstance Create(string targetInstance)
    {
        if(string.IsNullOrEmpty(targetInstance))
            throw new Exception("Target instance is Null or Empty");

        var items = targetInstance.Split(".").ToList();
        if(items.Count<1)
            throw new Exception("Invalid Target Insatnce");
        if(items.Count ==1)
            return new TargetInstance(items[0],"Concept");
        
        var name = items[0];
        var type = string.Join(".",items.GetRange(1,items.Count-1).ToArray());

        return new TargetInstance(name,type);
        
        
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Type;
    }
}