﻿namespace CapaDTOs;

public class PrestamosDTO
{
    public int IdPrestamo { get; set; }
    public string? NombreCurso { get; set; }
    public required string ApellidoDocentes { get; set; }
    public required string ApellidoEncargado { get; set; }
    public string? NumeroSerieCarrito { get; set; }
    public DateTime FechaPrestamo { get; set; }
}