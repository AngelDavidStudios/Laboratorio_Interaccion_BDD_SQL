﻿namespace ADO.Models.Models;

public class Curso
{
    public int Idcurso { get; set; }

    public string NombreCurso { get; set; }

    public string? Descripcion { get; set; }

    public decimal PrecioxHora { get; set; }

    public string? TipoCurso { get; set; }
}