﻿using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoEstadosPrestamo
{
    public IEnumerable<EstadosPrestamo> GetAll();
    public EstadosPrestamo? GetById(int idEstadosPrestamo);
}
