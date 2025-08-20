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
        var repo = new RepoElemento(fixture.Conexion);
        var mapper = new MapperElementos(fixture.Conexion);

        _elementoCN = new ElementosCN(mapper, repo);
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

        _elementoCN.ActualizarElemento(NewElemento);

        ElementosDTO? OldElemento = _elementoCN.ObtenerElementos().FirstOrDefault(e => e.IdElemento == NewElemento.IdElemento);

        Assert.NotNull(OldElemento);
        Assert.Equal("NB003", OldElemento.NumeroSerie);
        Assert.Equal("CB005", OldElemento.CodigoBarra);

        trasaction.Rollback();
    }

    //[Fact]
    //public void Obtener_Elementos_Por_Carrito_OK()
    //{
    //    var elementos = _elementoCN.ObtenerPorCarrito(1);
    //    Assert.NotEmpty(elementos);
    //}

    //[Fact]
    //public void Obtener_Elementos_Por_Tipo_OK()
    //{
    //    var elementos = _elementoCN.ObtenerPorTipo(1);
    //    Assert.NotEmpty(elementos);
    //}

    //[Fact]
    //public void Obtener_Elemento_Por_Codigo_Barra_OK()
    //{
    //    var elemento = _elementoCN.ObtenerPorCodigoBarra("CB004");
    //    Assert.NotNull(elemento);
    //    Assert.Equal("CB004", elemento.CodigoBarra);
    //}

    //[Fact]
    //public void Crear_Elemento_Sin_Numero_Serie_Falla()
    //{
    //    var nuevoElemento = new Elemento
    //    {
    //        IdTipoElemento = 1,
    //        IdCarrito = 1,
    //        IdEstadoElemento = 1,
    //        numeroSerie = "",
    //        codigoBarra = "CB006",
    //        Disponible = true
    //    };
    //    Assert.Throws<Exception>(() => _elementoCN.CrearElemento(nuevoElemento));
    //}

    //[Fact]
    //public void Eliminar_Elemento_Inexistente_Falla()
    //{
    //    Assert.Throws<Exception>(() => _elementoCN.EliminarElemento(9999)); 
    //}
}