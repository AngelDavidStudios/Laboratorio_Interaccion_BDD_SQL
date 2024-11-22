using ADO.Models.Models;
using Udemy_System.Services;

class Program
{
    private static readonly StudentService _studentService = new StudentService();
    private static readonly CursoService _cursoService = new CursoService();
    
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Listar Cursos");
            Console.WriteLine("2. Agregar Curso");
            Console.WriteLine("3. Actualizar Curso");
            Console.WriteLine("4. Eliminar Curso");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListCursoAsync();
                    break;
                case "2":
                    await AddCursoAsync();
                    break;
                case "3":
                    await UpdateCursoAsync();
                    break;
                case "4":
                    await DeleteCursoAsync();
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

    public static async Task ListCursoAsync()
    {
        try
        {
            var cursos = await _cursoService.GetCursos();
            if (cursos.Count == 0)
            {
                Console.WriteLine("No hay cursos registrados.");
                return;
            }
            
            Console.WriteLine("\n--- Lista de Cursos ---");
            Console.WriteLine($"{"ID Curso",-5} {"Nombre Curso",-20} {"Descripción",-20} {"Precios X Hora",-30} {"Tipo de Curso",-15}");
            Console.WriteLine(new string('-', 90));
            
            foreach (var curso in cursos)
            {
                Console.WriteLine($"{curso.Idcurso,-5} {curso.NombreCurso,-20} {curso.Descripcion,-20} {curso.PrecioxHora,-30} {curso.TipoCurso,-15}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al listar cursos: {e.Message}");
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

    public static async Task AddCursoAsync()
    {
        try
        {
            Console.Write("ID Curso: ");
            var idcurso = int.Parse(Console.ReadLine());
            Console.Write("Nombre Curso: ");
            var nombreCurso = Console.ReadLine();
            Console.Write("Descripción: ");
            var descripcion = Console.ReadLine();
            Console.Write("Precio x Hora: ");
            var precioxHora = double.Parse(Console.ReadLine());
            Console.Write("Tipo de Curso: ");
            var tipoCurso = Console.ReadLine();

            var curso = new Curso()
            {
                Idcurso = idcurso,
                NombreCurso = nombreCurso,
                Descripcion = descripcion,
                PrecioxHora = precioxHora,
                TipoCurso = tipoCurso
            };

            await _cursoService.AddCurso(curso);
            Console.WriteLine("Curso agregado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar curso: {e.Message}");
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

    public static async Task UpdateCursoAsync()
    {
        try
        {
            Console.Write("ID Curso: ");
            var idcurso = int.Parse(Console.ReadLine());
            var curso = await _cursoService.GetCurso(idcurso);

            if (curso == null)
            {
                Console.WriteLine("Curso no encontrado.");
                return;
            }

            Console.Write("Nombre Curso: ");
            curso.NombreCurso = Console.ReadLine();
            Console.Write("Descripción: ");
            curso.Descripcion = Console.ReadLine();
            Console.Write("Precio x Hora: ");
            curso.PrecioxHora = double.Parse(Console.ReadLine());
            Console.Write("Tipo de Curso: ");
            curso.TipoCurso = Console.ReadLine();

            await _cursoService.UpdateCurso(curso);
            Console.WriteLine("Curso actualizado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al actualizar curso: {e.Message}");
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

    private static async Task DeleteCursoAsync()
    {
        try
        {
            Console.Write("ID Curso: ");
            var idcurso = int.Parse(Console.ReadLine());
            await _cursoService.DeleteCurso(idcurso);
            Console.WriteLine("Curso eliminado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al eliminar curso: {e.Message}");
            throw;
        }
    }
}