using MDDPlatform.Diagrams.Core.Entities;
using MDDPlatform.Diagrams.Services.Interfaces;
using MDDPlatform.RestClients;

namespace MDDPlatform.Diagrams.Infrastructure.ExternalServices;
public class DomainModelService : IDomainModelService
{
    private readonly IRestClient _restClient;

    public DomainModelService(HttpClient httpClient)
    {
        _restClient = new RestClient(httpClient);
    }

    public async Task<List<DomainConcept>?> GetDomainConceptsAsync(Guid domainModelId)
    {
        var url = string.Format("DomainModel/{0}/DomainConcepts",domainModelId);
        return await _restClient.GetAsync<List<DomainConcept>?>(url);
    }

    public async Task<List<DomainObject>?> GetDomainObjectsAsync(Guid domainModelId)
    {
        var url = string.Format("DomainModel/{0}/DomainObjetcs",domainModelId);
        return await _restClient.GetAsync<List<DomainObject>?>(url);
    }
}