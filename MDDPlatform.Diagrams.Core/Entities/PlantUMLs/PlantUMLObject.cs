using System.Text;
using MDDPlatform.Diagrams.Core.Interfaces;
using MDDPlatform.Diagrams.Core.ValueObjects;

namespace MDDPlatform.Diagrams.Core.Entities;
public class PlantUMLObject : IPlantUMLElement
{    
    private DomainObject _domainObject;

    public string Name => _domainObject.InstanceName;
    public string Type => _domainObject.InstanceType;
    public string FullName => _domainObject.FullName;
    public List<RelationTargetInstance> RelationTargetInstances => _domainObject.RelationTargetInstances;
    public HashSet<TargetInstance> TargetInstances => _domainObject.TargetInstances;

    private PlantUMLObject(DomainObject domainObject)
    {
        _domainObject = domainObject;
    }

    public static PlantUMLObject Create(DomainObject domainObject)
    {
        return new(domainObject);
    }
    public string ToText()
    {
        var builder = new StringBuilder();
        builder.AppendFormat("Object {0} <<{1}>>",Name,Type);
        builder.AppendLine();
        foreach(var prop in _domainObject.Properties)
        {
            if(prop.Value !=null)
            {
                builder.AppendFormat("{0} : {1} = {2}",Name,prop.Name,prop.Value);
                builder.AppendLine();
            }
        }
        foreach(var relationTargetInstance in _domainObject.RelationTargetInstances)
        {
            builder.AppendFormat("{0} --> {1} : {2}",Name,
                                                        relationTargetInstance.InstanceName,
                                                        relationTargetInstance.RelationName);
            builder.AppendLine();
        }
        return builder.ToString();
    }
    public string DeclareObject(){
        var builder = new StringBuilder();
        builder.AppendFormat("Object {0} <<{1}>>",Name,Type);
        builder.AppendLine();
        return builder.ToString();
    }
    public string DeclareProperty()
    {
        var builder = new StringBuilder();
        foreach(var prop in _domainObject.Properties)
        {            
            if(!string.IsNullOrEmpty(prop.Value))
            {
                var propValue = prop.Type.ToLower().Contains("string") ? string.Format("\"{0}\"",prop.Value) : prop.Value;
                builder.AppendFormat("{0} : {1} = {2}",Name,prop.Name,propValue);
                builder.AppendLine();
            }else
            {
                var propValue = prop.Type.ToLower().Contains("string") && prop.Value !=null ? string.Format("\"{0}\"",prop.Value) : "default";
                builder.AppendFormat("{0} : {1} = {2}",Name,prop.Name,propValue);
                builder.AppendLine();
            }
            
        }
        return builder.ToString();
    }
    public string DeclareRelations()
    {
        var builder = new StringBuilder();
        foreach(var relationTargetInstance in _domainObject.RelationTargetInstances)
        {
            builder.AppendFormat("{0} --> {1} : {2}",Name,
                                                        relationTargetInstance.InstanceName,
                                                        relationTargetInstance.RelationName);
            builder.AppendLine();
        }
        return builder.ToString();
    }
    public static string DeclareObject(string name,string type)
    {
        var builder = new StringBuilder();
        builder.AppendFormat("Object {0} <<{1}>>",name,type);
        builder.AppendLine();
        return builder.ToString();
    }
}