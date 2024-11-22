using ADO.Models.Models;
using RestSharp;

namespace Udemy_System.Services;

public class CursoService
{
    private readonly RestClient _client;
    
    public CursoService()
    {
        _client = new RestClient("http://localhost:5201/api/");
    }
    
    public async Task<List<Curso>> GetCursos()
    {
        var request = new RestRequest("Curso", Method.Get);
        var response = await _client.ExecuteAsync<List<Curso>>(request);
        return response.Data;
    }
    
    public async Task<Curso> GetCurso(int id)
    {
        var request = new RestRequest($"Curso/{id}", Method.Get);
        var response = await _client.ExecuteAsync<Curso>(request);
        return response.Data;
    }
    
    public async Task AddCurso(Curso curso)
    {
        var request = new RestRequest("Curso", Method.Post);
        request.AddJsonBody(curso);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task UpdateCurso(Curso curso)
    {
        var request = new RestRequest("Curso", Method.Put);
        request.AddJsonBody(curso);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task DeleteCurso(int id)
    {
        var request = new RestRequest($"Curso/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
}