using ADO.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Test_Conexion_ADO_NET.Repository.Interfaces;

namespace Test_Conexion_ADO_NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController: ControllerBase
{
    private readonly ICursoRepository _cursoRepository;
    
    public CursoController(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllCursos()
    {
        return Ok(_cursoRepository.GetAllCursos());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCursoById(int id)
    {
        return Ok(_cursoRepository.GetCursoById(id));
    }
    
    [HttpPost]
    public IActionResult AddCurso([FromBody] Curso curso)
    {
        _cursoRepository.AddCurso(curso);
        return Ok("Curso agregado con exito");
    }
    
    [HttpPut]
    public IActionResult UpdateCurso([FromBody] Curso curso)
    {
        _cursoRepository.UpdateCurso(curso);
        return Ok("Curso actualizado con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCurso(int id)
    {
        _cursoRepository.DeleteCurso(id);
        return Ok("Curso eliminado con exito");
    }
}