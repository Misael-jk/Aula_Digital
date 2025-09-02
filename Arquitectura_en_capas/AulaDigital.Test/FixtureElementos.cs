using Xunit;
using CapaDatos.Repos;
using CapaDatos.MappersDTO;
using CapaNegocio;
using CapaEntidad;
using CapaDTOs;
using AulaDigital.Test;
using System.Transactions;
using System.Data.Common;
using System.Data;
using CapaDatos.Interfaces;

namespace CapaTests;

public class ElementoTests : IClassFixture<TestBase>
{
    private readonly IRepoHistorialElemento repohistorialElemento;
    private readonly ElementosCN _elementoCN;
    private readonly TestBase _fixture;

    public ElementoTests(TestBase fixture)
    {
        _fixture = fixture;
        RepoElemento repoElementos = new RepoElemento(fixture.Conexion);
        RepoCarritos repoCarritos = new RepoCarritos(fixture.Conexion);
        MapperElementos mapper = new MapperElementos(fixture.Conexion);
        repohistorialElemento = new RepoHistorialElemento(fixture.Conexion);


        _elementoCN = new ElementosCN(mapper, repoElementos, repoCarritos, repohistorialElemento);
    }

    [Fact]
    public void CrearElemento()
    {
        using IDbTransaction? trasaction = _fixture.Conexion.BeginTransaction();
        
            Elemento NewElemento = new Elemento
            {
                IdTipoElemento = 1,
                IdCarrito = 1,
                IdEstadoElemento = 1,
                numeroSerie = "NB002",
                codigoBarra = "CB004",
                Disponible = true
            };

            _elementoCN.CrearElemento(NewElemento, 1);

            Assert.True(NewElemento.IdElemento > 0);

            ElementosDTO? elementosDTO = _elementoCN.ObtenerElementos().FirstOrDefault(e => e.IdElemento == NewElemento.IdElemento);

            Assert.NotNull(elementosDTO);
            Assert.Equal(NewElemento.numeroSerie, elementosDTO.NumeroSerie);
            Assert.Equal(NewElemento.codigoBarra, elementosDTO.CodigoBarra);

        var historialCreacion = repohistorialElemento.GetByElemento(NewElemento.IdElemento);
        Assert.NotNull(historialCreacion);

        trasaction.Rollback();
        
    }

    [Fact]
    public void ActualizarElemento()
    {
        using IDbTransaction? trasaction = _fixture.Conexion.BeginTransaction();

        Elemento NewElemento = new Elemento
        {
            IdTipoElemento = 1,
            IdCarrito = 1,
            IdEstadoElemento = 1,
            numeroSerie = "NB002",
            codigoBarra = "CB004",
            Disponible = true
        };

        _elementoCN.CrearElemento(NewElemento, 1);

        NewElemento.numeroSerie = "NB003";
        NewElemento.codigoBarra = "CB005";
        NewElemento.IdCarrito = 2;
        //NewElemento.IdEstadoElemento = 2;
        //NewElemento.Disponible = false;

        _elementoCN.ActualizarElemento(NewElemento, 1);

        ElementosDTO? OldElemento = _elementoCN.ObtenerElementos().FirstOrDefault(e => e.IdElemento == NewElemento.IdElemento);

        Assert.NotNull(OldElemento);
        Assert.Equal("NB003", OldElemento.NumeroSerie);
        Assert.Equal("CB005", OldElemento.CodigoBarra);

        trasaction.Rollback();
    }

    [Fact]
    public void DeshabilitarElemento()
    {
        using IDbTransaction transaction = _fixture.Conexion.BeginTransaction();

        Elemento NewElemento = new Elemento
        {
            IdTipoElemento = 1,
            IdCarrito = 1,
            IdEstadoElemento = 1,
            numeroSerie = "NB066",
            codigoBarra = "CB076",
            Disponible = true
        };

        _elementoCN.CrearElemento(NewElemento, 1);

        _elementoCN.DeshabilitarElemento(NewElemento.IdElemento, 1);

        Assert.False(!NewElemento.Disponible);

        transaction.Rollback();
    }
}