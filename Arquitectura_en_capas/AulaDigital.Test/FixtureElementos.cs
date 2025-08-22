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

namespace CapaTests;

public class ElementoTests : IClassFixture<TestBase>
{
    private readonly ElementosCN _elementoCN;
    private readonly TestBase _fixture;

    public ElementoTests(TestBase fixture)
    {
        _fixture = fixture;
        RepoElemento repoElementos = new RepoElemento(fixture.Conexion);
        RepoCarritos repoCarritos = new RepoCarritos(fixture.Conexion);
        MapperElementos mapper = new MapperElementos(fixture.Conexion);


        _elementoCN = new ElementosCN(mapper, repoElementos, repoCarritos);
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

            _elementoCN.CrearElemento(NewElemento);

            Assert.True(NewElemento.IdElemento > 0);

            ElementosDTO? elementosDTO = _elementoCN.ObtenerElementos().FirstOrDefault(e => e.IdElemento == NewElemento.IdElemento);

            Assert.NotNull(elementosDTO);
            Assert.Equal(NewElemento.numeroSerie, elementosDTO.NumeroSerie);
            Assert.Equal(NewElemento.codigoBarra, elementosDTO.CodigoBarra);

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

        _elementoCN.CrearElemento(NewElemento);

        NewElemento.numeroSerie = "NB003";
        NewElemento.codigoBarra = "CB005";
        NewElemento.IdCarrito = 2;
        //NewElemento.IdEstadoElemento = 2;
        //NewElemento.Disponible = false;

        _elementoCN.ActualizarElemento(NewElemento);

        ElementosDTO? OldElemento = _elementoCN.ObtenerElementos().FirstOrDefault(e => e.IdElemento == NewElemento.IdElemento);

        Assert.NotNull(OldElemento);
        Assert.Equal("NB003", OldElemento.NumeroSerie);
        Assert.Equal("CB005", OldElemento.CodigoBarra);

        trasaction.Rollback();
    }

    [Fact]
    public void EliminarElemento()
    {
        using IDbTransaction transaction = _fixture.Conexion.BeginTransaction();

        Assert.Throws<Exception>(() => _elementoCN.EliminarElemento(9999));

        _elementoCN.EliminarElemento(1);

        transaction.Rollback();
    }
}