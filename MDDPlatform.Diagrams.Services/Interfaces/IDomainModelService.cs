using MDDPlatform.Diagrams.Core.Entities;

namespace MDDPlatform.Diagrams.Services.Interfaces;
public interface IDomainModelService
{
    Task<List<DomainObject>?> GetDomainObjectsAsync(Guid domainModelId);
    Task<List<DomainConcept>?> GetDomainConceptsAsync(Guid domainModelId);
}