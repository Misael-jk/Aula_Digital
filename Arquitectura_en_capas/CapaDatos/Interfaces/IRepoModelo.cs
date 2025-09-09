﻿using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoModelo
{
    public void Insert(Modelos modelo);
    public void Update(Modelos modelo);
    public IEnumerable<Modelos> GetAll();
    public Modelos? GetById(int idModelo);
    public IEnumerable<Modelos> GetByTipo(int idTipoElemento);
}
