using System.Text;
using MDDPlatform.Diagrams.Core.ValueObjects;

namespace MDDPlatform.Diagrams.Core.Entities;
public class PlantUMLObjectDiagram
{
    private List<PlantUMLObject> _plantUmlObjects;

    public IReadOnlyList<PlantUMLObject> PlantUmlObjects => _plantUmlObjects;

    public PlantUMLObjectDiagram(List<DomainObject> domainObjects)
    {
        _plantUmlObjects = domainObjects.Select(domainObject=>PlantUMLObject.Create(domainObject)).ToList();
    }
    public string ToText()
    {
        List<string> currentObjects = new();
        HashSet<TargetInstance> targetInstances = new();

        var builder = new StringBuilder();
        builder.AppendLine("@startuml");
        foreach(var plantUmlObject in  _plantUmlObjects)
        {
            builder.Append(plantUmlObject.DeclareObject());

            currentObjects.Add(plantUmlObject.FullName.ToLower());
            foreach(var targetInstance in plantUmlObject.TargetInstances){
                targetInstances.Add(targetInstance);
            }

        }        
        foreach(var targetInstance in targetInstances)
        {
            if(!currentObjects.Contains(targetInstance.FullName.ToLower()))
            {
                builder.Append(PlantUMLObject.DeclareObject(targetInstance.Name,targetInstance.Type));                 
                currentObjects.Add(targetInstance.FullName.ToLower());
            }
        }
        foreach(var plantUmlObject in  _plantUmlObjects)
        {
            builder.Append(plantUmlObject.DeclareProperty());
            builder.Append(plantUmlObject.DeclareRelations());
        }        
        builder.Append("@enduml");
        return builder.ToString();
    }
}