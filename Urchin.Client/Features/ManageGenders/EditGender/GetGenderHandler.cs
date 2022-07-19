using MediatR;
using System.Net.Http.Json;
using Urchin.Shared.Features.ManageGenders.EditGender;

namespace Urchin.Client.Features.ManageGenders.EditGender;

public class GetGenderHandler : IRequestHandler<GetGenderRequest, GetGenderRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetGenderHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetGenderRequest.Response?> Handle(GetGenderRequest request, CancellationToken cancellationToken)
    {
        try
        {
           return await _httpClient.GetFromJsonAsync<GetGenderRequest.Response?>(GetGenderRequest.RouteTemplate);   
        }
        catch (System.Exception)
        {
            return default!;
        }
    }
}