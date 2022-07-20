using MediatR;
using System.Net.Http.Json;
using Urchin.Shared.Features.ManageGenders.EditGender;

public class EditGenderHandler : IRequestHandler<EditGenderRequest, EditGenderRequest.Response>
{
    private readonly HttpClient _httpClient;

    public EditGenderHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EditGenderRequest.Response> Handle(EditGenderRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(EditGenderRequest.RouteTemplate, request, cancellationToken);
    
        if(response.IsSuccessStatusCode)
            return new EditGenderRequest.Response(true);
        else
            return new EditGenderRequest.Response(false);
    }
}