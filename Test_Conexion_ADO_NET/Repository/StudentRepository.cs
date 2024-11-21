using ADO.Models.Models;
using Microsoft.Data.SqlClient;
using Test_Conexion_ADO_NET.Repository.Interfaces;

namespace Test_Conexion_ADO_NET.Repository;

public class StudentRepository: IStudentRepository
{
    private readonly string _connectionString;
    
    public StudentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionUdemyDb");
    }
    
    public List<Estudiantes> GetAllStudents()
    {
        List<Estudiantes> students = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Estudiantes";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Estudiantes student = new()
                {
                    Id = Convert.ToInt32(reader["IDEstudiante"]),
                    Nombre = reader["NombreEstudiante"].ToString(),
                    Apellido = reader["ApellidoEstudiante"].ToString(),
                    Email = reader["Email"].ToString(),
                    Telefono = reader["Telefono"].ToString()
                };
                students.Add(student);
            }
        }
        return students;
    }
    
    public Estudiantes GetStudentById(int id)
    {
        Estudiantes student = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Estudiantes WHERE IDEstudiante = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                student.Id = Convert.ToInt32(reader["IDEstudiante"]);
                student.Nombre = reader["NombreEstudiante"].ToString();
                student.Apellido = reader["ApellidoEstudiante"].ToString();
                student.Email = reader["Email"].ToString();
                student.Telefono = reader["Telefono"].ToString();
            }
        }
        return student;
    }
    
    public void AddStudent(Estudiantes student)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Estudiantes (IDEstudiante, NombreEstudiante, ApellidoEstudiante, Email, Telefono) VALUES (@Id,@Nombre, @Apellido, @Email, @Telefono)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Nombre", student.Nombre);
            command.Parameters.AddWithValue("@Apellido", student.Apellido);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Telefono", student.Telefono);
            command.ExecuteNonQuery();
        }
    }
    
    public void UpdateStudent(Estudiantes student)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "UPDATE Estudiantes SET NombreEstudiante = @Nombre, ApellidoEstudiante = @Apellido, Email = @Email, Telefono = @Telefono WHERE IDEstudiante = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Nombre", student.Nombre);
            command.Parameters.AddWithValue("@Apellido", student.Apellido);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Telefono", student.Telefono);
            command.ExecuteNonQuery();
        }
    }
    
    public void DeleteStudent(int id)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Estudiantes WHERE IDEstudiante = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}