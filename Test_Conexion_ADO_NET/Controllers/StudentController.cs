using ADO.Models.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test_Conexion_ADO_NET.Repository.Interfaces;

namespace Test_Conexion_ADO_NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController: ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        return Ok(_studentRepository.GetAllStudents());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        return Ok(_studentRepository.GetStudentById(id));
    }
    
    [HttpPost]
    public IActionResult AddStudent([FromBody] Estudiantes student)
    {
        _studentRepository.AddStudent(student);
        return Ok("Estudiante agregado con exito");
    }
    
    [HttpPut]
    public IActionResult UpdateStudent([FromBody] Estudiantes student)
    {
        _studentRepository.UpdateStudent(student);
        return Ok("Estudiante actualizado con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentRepository.DeleteStudent(id);
        return Ok("Estudiante eliminado con exito");
    }
}