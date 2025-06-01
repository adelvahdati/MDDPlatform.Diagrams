using MDDPlatform.Diagrams.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Diagrams.Core.Entities;
public class DomainObject : BaseEntity<Guid>
{
    public Guid DomainConceptId {get;set;}
    public string InstanceName {get;set;}
    public string InstanceType {get;set;}
    public List<Property> Properties {get;set;}
    public List<DomainObjectRelation> Relations {get;set;}
    public  List<Operation> Operations {get;set;}
    public List<RelationalDimension> RelationalDimensions {get;set;}


    public string FullName => string.Format("{0}.{1}",InstanceName,InstanceType);
    public List<RelationTargetInstance> RelationTargetInstances => GetRelationTargetInstances();
    public HashSet<TargetInstance> TargetInstances => GetTargetInstances();


    public DomainObject(Guid domainConceptId, string instanceName, string instanceType, List<Property> properties, List<DomainObjectRelation> relations, List<Operation> operations, List<RelationalDimension> relationalDimensions)
    {
        DomainConceptId = domainConceptId;
        InstanceName = instanceName;
        InstanceType = instanceType;
        Properties = properties;
        Relations = relations;
        Operations = operations;
        RelationalDimensions = relationalDimensions;
    }
    private List<RelationTargetInstance> GetRelationTargetInstances()
    {
        List<RelationTargetInstance> relationTargetInstances = new();
        
        foreach(var rel in Relations)
        {
            foreach(var targetInstance in rel.TargetInstances)
            {
                var relationTargetInstance = new RelationTargetInstance(rel.RelationName,TargetInstance.Create(targetInstance));
                relationTargetInstances.Add(relationTargetInstance);        
            }
        }
        return relationTargetInstances;
   }
    private HashSet<TargetInstance> GetTargetInstances()
    {
        HashSet<TargetInstance> targetInstances = new();
        
        foreach(var rel in Relations)
        {
            foreach(var instance in rel.TargetInstances)
            {
                var targetInstance = TargetInstance.Create(instance);
                targetInstances.Add(targetInstance);        
            }
        }
        return targetInstances;
   }    
}