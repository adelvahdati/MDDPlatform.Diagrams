using MDDPlatform.Diagrams.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;
using Attribute = MDDPlatform.Diagrams.Core.ValueObjects.Attribute;

namespace MDDPlatform.Diagrams.Core.Entities;
public class DomainConcept : BaseEntity<Guid>
{

    public string Name {get;set;}
    public string Type {get;set;}
    public List<Property> Properties {get;set;}
    public List<Relation> Relations {get;set;}
    public  List<Operation> Operations {get;set;}
    public List<Attribute> Attributes { get; set; }
    public string FullName => string.Format("{0}.{1}",Name,Type);

    public DomainConcept(string name, string type, List<Property> properties, List<Relation> relations, List<Operation> operations, List<Attribute> attributes)
    {
        Name = name;
        Type = type;
        Properties = properties;
        Relations = relations;
        Operations = operations;
        Attributes = attributes;
    }
}