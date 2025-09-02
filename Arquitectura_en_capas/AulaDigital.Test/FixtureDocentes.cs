using CapaDatos.Repos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaDigital.Test;

public class FixtureDocentes : IClassFixture<TestBase>
{
    private readonly TestBase fixture;
    private readonly DocentesCN docentesCN;
    private readonly RepoDocentes repoDocentes;
    public FixtureDocentes(TestBase fixture)
    {
        this.fixture = fixture;
        repoDocentes = new RepoDocentes(fixture.Conexion);
        docentesCN = new DocentesCN(repoDocentes);
    }

    [Fact]
    public void CrearDocente()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();

        Docentes docentesNEW = new Docentes
        {
            IdDocente = 4,
            Dni = "12345678",
            Nombre = "Juan",
            Apellido = "Perez",
            Email = "misaelpiucaet12d1@gmail.com"
        };

        docentesCN.CrearDocente(docentesNEW);

        Assert.True(docentesNEW.IdDocente >= 0);
        Assert.Equal("12345678", docentesNEW.Dni);
        Assert.Equal("Juan", docentesNEW.Nombre);
        Assert.Equal("Perez", docentesNEW.Apellido);

        trasaction.Rollback();
    }

    [Fact]
    public void ActualizarDocente()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();

        Docentes? docentes = repoDocentes.GetById(2);

        docentes.Dni = "87654321";
        docentes.Nombre = "Misael";
        docentes.Apellido = "Puca";
        
        docentesCN.ActualizarDocente(docentes);

        Assert.Equal("87654321", docentes.Dni);
        Assert.Equal("Misael", docentes.Nombre);
        Assert.Equal("Puca", docentes.Apellido);

        trasaction.Rollback();
    }

    [Fact]
    public void EliminarDocente()
    {
        using IDbTransaction? trasaction = fixture.Conexion.BeginTransaction();

        Docentes docentesNEW = new Docentes
        {
            IdDocente = 1,
            Dni = "12345678",
            Nombre = "Juan",
            Apellido = "Perez",
            Email = "misaelpiucaet12d1@gmail.com"
        };

        docentesCN.CrearDocente(docentesNEW);

        docentesCN.EliminarDocente(docentesNEW.IdDocente);

        Docentes? docentes = repoDocentes.GetById(docentesNEW.IdDocente);

        Assert.Null(docentes);

        trasaction.Rollback();
    }
}
