using MDDPlatform.SharedKernel.ValueObjects;
namespace MDDPlatform.Diagrams.Core.ValueObjects;

public class RelationTarget : ValueObject
{
    public string Name {get;set;}
    public string Type {get;set;}
    public string FullName => string.Format("{0}.{1}",Name,Type);

    public RelationTarget(string name, string type)
    {
        Name = name;
        Type = type;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullName;        
    }
    public static RelationTarget Create(string targetInstance)
    {
        if(string.IsNullOrEmpty(targetInstance))
            throw new Exception("Target instance is Null or Empty");

        var items = targetInstance.Split(".").ToList();
        if(items.Count<1)
            throw new Exception("Invalid Target Insatnce");
        if(items.Count ==1)
            return new RelationTarget(items[0],"Concept");
        
        var name = items[0];
        var type = string.Join(".",items.GetRange(1,items.Count-1).ToArray());

        return new RelationTarget(name,type);
        
        
    }

}
