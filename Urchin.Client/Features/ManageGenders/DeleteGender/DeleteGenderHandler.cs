using MediatR;
using System.Net.Http.Json;
using Urchin.Shared.Features.ManageGenders.DeleteGender;

public class DeleteGenderHandler : IRequestHandler<DeleteGenderRequest, DeleteGenderRequest.Response>
{
    private readonly HttpClient _httpClient;

    public DeleteGenderHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DeleteGenderRequest.Response> Handle(DeleteGenderRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.DeleteAsync(DeleteGenderRequest.RouteTemplate, cancellationToken);
    
        if(response.IsSuccessStatusCode)
            return new DeleteGenderRequest.Response(true);
        else
            return new DeleteGenderRequest.Response(false);
    }
}