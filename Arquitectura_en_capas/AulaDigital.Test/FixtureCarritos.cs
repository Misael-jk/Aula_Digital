using CapaDatos.Repos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaDigital.Test;

public class FixtureCarritos : IClassFixture<TestBase>
{
    private readonly CarritosCN carritosCN;
    private readonly TestBase fixture;
    private RepoCarritos repoCarritos;

    public FixtureCarritos(TestBase fixture)
    {
        RepoElemento repoElementos = new RepoElemento(fixture.Conexion);
        repoCarritos = new RepoCarritos(fixture.Conexion);

        carritosCN = new CarritosCN(repoCarritos, repoElementos);
        this.fixture = fixture;
    }

    [Fact]
    public void CrearCarrito()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();

        Carritos carritosNEW = new Carritos
        {
            IdCarrito = 4,
            NumeroSerieCarrito = "CR-03",
            DisponibleCarrito = true
        };

        carritosCN.CrearCarrito(carritosNEW);
        
        Assert.True(carritosNEW.IdCarrito >= 0);
        Assert.Equal("CR-03", carritosNEW.NumeroSerieCarrito);
        trasaction.Rollback();
    }

    [Fact]
    public void ActualizarCarrito()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();

        Carritos carritosNEW = new Carritos
        {
            IdCarrito = 22,
            NumeroSerieCarrito = "CRR-05",
            DisponibleCarrito = true
        };

        carritosCN.CrearCarrito(carritosNEW);

        Assert.True(carritosNEW.IdCarrito >= 0);
        Assert.Equal("CRR-05", carritosNEW.NumeroSerieCarrito);

        carritosNEW.NumeroSerieCarrito = "CRR-06";

        carritosCN.ActualizarCarrito(carritosNEW);

        Assert.Equal("CRR-06", carritosNEW.NumeroSerieCarrito);
        trasaction.Rollback();
    }

    [Fact]
    public void DeleteCarrito()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();
        Carritos carritosNEW = new Carritos
        {
            IdCarrito = 23,
            NumeroSerieCarrito = "CRR-05",
            DisponibleCarrito = true
        };
        carritosCN.CrearCarrito(carritosNEW);

        Assert.True(carritosNEW.IdCarrito >= 0);
        Assert.Equal("CRR-05", carritosNEW.NumeroSerieCarrito);

        repoCarritos.Delete(carritosNEW.IdCarrito);

        Carritos? carritoBorrado = repoCarritos.GetById(carritosNEW.IdCarrito);

        Assert.Null(carritoBorrado);

        trasaction.Rollback();
    }
}
