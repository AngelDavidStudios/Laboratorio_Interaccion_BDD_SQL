using ADO.Models.Models;

namespace Test_Conexion_ADO_NET.Repository.Interfaces;

public interface IStudentRepository
{
    List<Estudiantes> GetAllStudents();
    Estudiantes GetStudentById(int id);
    
    // CRUD
    void AddStudent(Estudiantes student);
    void UpdateStudent(Estudiantes student);
    void DeleteStudent(int id);
}