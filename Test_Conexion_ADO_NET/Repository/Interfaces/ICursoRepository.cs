using ADO.Models.Models;

namespace Test_Conexion_ADO_NET.Repository.Interfaces;

public interface ICursoRepository
{
    List<Curso> GetAllCursos();
    Curso GetCursoById(int id);
    
    // CRUD
    void AddCurso(Curso curso);
    void UpdateCurso(Curso curso);
    void DeleteCurso(int id);
}