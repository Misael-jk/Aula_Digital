﻿namespace CapaEntidad;

public class DevolucionDetalle
{
    public int IdDevolucion { get; set; }
    public int IdElemento { get; set; }
    public int IdEstadoMantenimiento { get; set; }
    public string? Observaciones { get; set; }
}
