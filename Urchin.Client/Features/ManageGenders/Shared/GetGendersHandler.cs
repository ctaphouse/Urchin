using MediatR;
using System.Net.Http.Json;
using Urchin.Shared.Features.ManageGenders.Shared;

namespace Urchin.Client.Features.ManageGenders.Shared;

public class GetGendersHandler : IRequestHandler<GetGendersRequest, GetGendersRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetGendersHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetGendersRequest.Response?> Handle(GetGendersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GetGendersRequest.Response>(GetGendersRequest.RouteTemplate);
        }
        catch (HttpRequestException)
        {
            return default!;
        }        
    }
}