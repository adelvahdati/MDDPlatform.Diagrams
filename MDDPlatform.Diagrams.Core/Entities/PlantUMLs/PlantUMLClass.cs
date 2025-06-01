using System.Text;
using MDDPlatform.Diagrams.Core.Interfaces;
using MDDPlatform.Diagrams.Core.ValueObjects;

namespace MDDPlatform.Diagrams.Core.Entities;
public class PlantUMLClass : IPlantUMLElement
{
    private DomainConcept _domainConcept;
    public string Name => _domainConcept.Name;
    public string Type => _domainConcept.Type;
    public string FullName => _domainConcept.FullName;

    public IReadOnlyList<RelationTarget> RelationTargets => _domainConcept.Relations.Select(rel=>RelationTarget.Create(rel.Target)).ToList();

    private PlantUMLClass(DomainConcept domainConcept){
        _domainConcept = domainConcept;
    }
    public static PlantUMLClass Create(DomainConcept domainConcept)
    {
        return new(domainConcept);
    }

    public string ToText()
    {
        var builder = new StringBuilder();
        builder.Append(DeclareClass());
        builder.Append(DeclareProperties());
        builder.Append(DeclareOperations());
        builder.Append(DeclareRelations());

        return builder.ToString();
    }
    public string DeclareClass()
    {
        var builder = new StringBuilder();
        builder.AppendFormat("Class {0} <<{1}>>",Name,Type);
        builder.AppendLine();
        return builder.ToString();

    }
    public string DeclareProperties()
    {
        var builder = new StringBuilder();
        foreach(var prop in _domainConcept.Properties)
        {
            var propertyType = prop.IsCollection ? string.Format("{0}[]",prop.Type) : prop.Type;
            builder.AppendFormat("{0} : {1} {2}",Name,propertyType,prop.Name);
            builder.AppendLine();
        }
        return builder.ToString();
    }
    public string DeclareRelations()
    {
        var builder = new StringBuilder();
        foreach(var relation in _domainConcept.Relations)
        {
            builder.AppendFormat("{0} \"1\" --> \"{1}\" {2} : {3}",Name,
                                                        relation.Multiplicity,
                                                        relation.RelationTargetName,
                                                        relation.Name);
            builder.AppendLine();
        }
        return builder.ToString();

    }
    public string DeclareOperations()
    {
        var builder = new StringBuilder();
        foreach(var operation in _domainConcept.Operations)
        {
                builder.AppendFormat("{0} : {1} {2}({3})",Name,operation.Output.ToString(),operation.Name,operation.FlattenInputs);
                builder.AppendLine();            
        }
        return builder.ToString();
    }
    public static string DeclareClass(string name,string type){
        var builder = new StringBuilder();
        builder.AppendFormat("Class {0} <<{1}>>",name,type);
        builder.AppendLine();
        return builder.ToString();
    }

}