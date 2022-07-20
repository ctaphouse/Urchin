using MediatR;
using System.Net.Http.Json;
using Urchin.Shared.Features.ManageGenders.AddGender;

namespace Urchin.Client.Features.ManageGenders.AddGender;

public class AddGenderHandler : IRequestHandler<AddGenderRequest, AddGenderRequest.Response>
{
    private readonly HttpClient _httpClient;

    public AddGenderHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AddGenderRequest.Response> Handle(AddGenderRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(AddGenderRequest.RouteTemplate, request, cancellationToken);
    
        if(response.IsSuccessStatusCode)
        {
            var genderId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
            return new AddGenderRequest.Response(genderId);
        }

        return new AddGenderRequest.Response(-1);
    }
}