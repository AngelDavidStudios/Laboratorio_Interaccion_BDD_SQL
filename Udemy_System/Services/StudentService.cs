using ADO.Models.Models;
using RestSharp;

namespace Udemy_System.Services;

public class StudentService
{
    private readonly RestClient _client;
    
    public StudentService()
    {
        _client = new RestClient("http://localhost:5201/api/");
    }
    
    public async Task<List<Estudiantes>> GetStudents()
    {
        var request = new RestRequest("Student", Method.Get);
        var response = await _client.ExecuteAsync<List<Estudiantes>>(request);
        return response.Data;
    }
    
    public async Task<Estudiantes> GetStudent(int id)
    {
        var request = new RestRequest($"Student/{id}", Method.Get);
        var response = await _client.ExecuteAsync<Estudiantes>(request);
        return response.Data;
    }
    
    public async Task AddStudent(Estudiantes student)
    {
        var request = new RestRequest("Student", Method.Post);
        request.AddJsonBody(student);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task UpdateStudent(Estudiantes student)
    {
        var request = new RestRequest("Student", Method.Put);
        request.AddJsonBody(student);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task DeleteStudent(int id)
    {
        var request = new RestRequest($"Student/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
}