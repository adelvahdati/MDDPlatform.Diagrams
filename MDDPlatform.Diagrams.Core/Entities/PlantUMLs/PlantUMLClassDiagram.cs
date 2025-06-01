using System.Text;
using MDDPlatform.Diagrams.Core.ValueObjects;

namespace MDDPlatform.Diagrams.Core.Entities;
public class PlantUMLClassDiagram
{
    private List<PlantUMLClass> _plantUmlClasses;

    public IReadOnlyList<PlantUMLClass> PlantUmlClasses => _plantUmlClasses;

    public PlantUMLClassDiagram(List<DomainConcept> domainConcepts)
    {
        _plantUmlClasses = domainConcepts.Select(domainConcept=>PlantUMLClass.Create(domainConcept)).ToList();
    }
    public string ToText()    
    {
        List<string> currentConcepts = new();
        HashSet<RelationTarget> targets = new();

        var builder = new StringBuilder();
        builder.AppendLine("@startuml");
        foreach(var plantUmlClass in  _plantUmlClasses)
        {
            builder.Append(plantUmlClass.DeclareClass());

            currentConcepts.Add(plantUmlClass.FullName.ToLower());
            foreach(var target in plantUmlClass.RelationTargets){
                targets.Add(target);
            }

        }        
        foreach(var target in targets)
        {
            if(!currentConcepts.Contains(target.FullName.ToLower()))
            {
                builder.Append(PlantUMLClass.DeclareClass(target.Name,target.Type));                 
                currentConcepts.Add(target.FullName.ToLower());
            }
        }
        foreach(var plantUmlClass in  _plantUmlClasses)
        {
            builder.Append(plantUmlClass.DeclareProperties());
            builder.Append(plantUmlClass.DeclareRelations());
            builder.Append(plantUmlClass.DeclareOperations());
        }        
        builder.Append("@enduml");
        return builder.ToString();
    }
}