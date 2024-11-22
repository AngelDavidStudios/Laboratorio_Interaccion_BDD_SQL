using ADO.Models.Models;
using Microsoft.Data.SqlClient;
using Test_Conexion_ADO_NET.Repository.Interfaces;

namespace Test_Conexion_ADO_NET.Repository;

public class CursoRepository: ICursoRepository
{
    private readonly string _connectionString;
    
    public CursoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionUdemyDb");
    }
    
    public List<Curso> GetAllCursos()
    {
        List<Curso> courses = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Cursos";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Curso course = new()
                {
                    Idcurso = Convert.ToInt32(reader["IDCurso"]),
                    NombreCurso = reader["NombreCurso"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    PrecioxHora = Convert.ToDouble(reader["PrecioXHora"]),
                    TipoCurso = reader["TipoCurso"].ToString()
                };
                courses.Add(course);
            }
        }
        return courses;
    }
    
    public Curso GetCursoById(int id)
    {
        Curso course = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Cursos WHERE IDCurso = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                course.Idcurso = Convert.ToInt32(reader["IDCurso"]);
                course.NombreCurso = reader["NombreCurso"].ToString();
                course.Descripcion = reader["Descripcion"].ToString();
                course.PrecioxHora = Convert.ToDouble(reader["PrecioXHora"]);
                course.TipoCurso = reader["TipoCurso"].ToString();
            }
        }
        return course;
    }
    
    public void AddCurso(Curso course)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Cursos (IDCurso, NombreCurso, Descripcion, PrecioXHora, TipoCurso) VALUES (@IDCurso, @NombreCurso, @Descripcion, @PrecioXHora, @TipoCurso)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@IDCurso", course.Idcurso);
            command.Parameters.AddWithValue("@NombreCurso", course.NombreCurso);
            command.Parameters.AddWithValue("@Descripcion", course.Descripcion);
            command.Parameters.AddWithValue("@PrecioXHora", course.PrecioxHora);
            command.Parameters.AddWithValue("@TipoCurso", course.TipoCurso);
            command.ExecuteNonQuery();
        }
    }
    
    public void UpdateCurso(Curso course)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "UPDATE Cursos SET NombreCurso = @NombreCurso, Descripcion = @Descripcion, PrecioXHora = @PrecioXHora, TipoCurso = @TipoCurso WHERE IDCurso = @IDCurso";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@IDCurso", course.Idcurso);
            command.Parameters.AddWithValue("@NombreCurso", course.NombreCurso);
            command.Parameters.AddWithValue("@Descripcion", course.Descripcion);
            command.Parameters.AddWithValue("@PrecioXHora", course.PrecioxHora);
            command.Parameters.AddWithValue("@TipoCurso", course.TipoCurso);
            command.ExecuteNonQuery();
        }
    }
    
    public void DeleteCurso(int id)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Cursos WHERE IDCurso = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}