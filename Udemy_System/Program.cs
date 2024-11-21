using ADO.Models.Models;
using Udemy_System.Services;

class Program
{
    private static readonly StudentService _studentService = new StudentService();
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Listar estudiantes");
            Console.WriteLine("2. Agregar estudiante");
            Console.WriteLine("3. Actualizar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListStudentsAsync();
                    break;
                case "2":
                    await AddStudentAsync();
                    break;
                case "3":
                    await UpdateStudentAsync();
                    break;
                case "4":
                    await DeleteStudentAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    private static async Task ListStudentsAsync()
    {
        try
        {
            var students = await _studentService.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            
            Console.WriteLine("\n--- Lista de Estudiantes ---");
            Console.WriteLine($"{"ID",-5} {"Nombre",-20} {"Apellido",-20} {"Email",-30} {"Teléfono",-15}");
            Console.WriteLine(new string('-', 90));
            
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id,-5} {student.Nombre,-20} {student.Apellido,-20} {student.Email,-30} {student.Telefono,-15}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al listar estudiantes: {e.Message}");
            throw;
        }

    }
    
    private static async Task AddStudentAsync()
    {
        try
        {
            Console.Write("ID del estudiante: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            var apellido = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Telefono: ");
            var telefono = Console.ReadLine();

            var student = new Estudiantes()
            {
                Id = id,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Telefono = telefono
            };

            await _studentService.AddStudent(student);
            Console.WriteLine("Estudiante agregado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar estudiante: {e.Message}");
            throw;
        }
    }
    
    private static async Task UpdateStudentAsync()
    {
        try
        {
            Console.Write("ID del estudiante: ");
            var id = int.Parse(Console.ReadLine());
            var student = await _studentService.GetStudent(id);

            if (student == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.Write("Nombre: ");
            student.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            student.Apellido = Console.ReadLine();
            Console.Write("Email: ");
            student.Email = Console.ReadLine();
            Console.Write("Telefono: ");
            student.Telefono = Console.ReadLine();

            await _studentService.UpdateStudent(student);
            Console.WriteLine("Estudiante actualizado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al actualizar estudiante: {e.Message}");
            throw;
        }
    }
    
    private static async Task DeleteStudentAsync()
    {
        try
        {
            Console.Write("ID del estudiante: ");
            var id = int.Parse(Console.ReadLine());
            await _studentService.DeleteStudent(id);
            Console.WriteLine("Estudiante eliminado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al eliminar estudiante: {e.Message}");
            throw;
        }
    }
}