﻿namespace CapaDTOs;

public class NotebooksDTO
{
    public int IdNotebook { get; set; }
    public string? NumeroSerieCarrito { get; set; }
    public required string CodigoBarra { get; set; }
    public int? PosicionCarrito { get; set; }
    public required string NumeroSerieNotebook { get; set; }
    public required string Patrimonio { get; set; }
    public required string Estado { get; set; }
    public required string Modelo { get; set; }

}
