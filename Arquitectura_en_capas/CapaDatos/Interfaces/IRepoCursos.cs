﻿using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoCursos
{
    public Curso? GetById(int idCurso);
    public IEnumerable<Curso> GetAll();
}
