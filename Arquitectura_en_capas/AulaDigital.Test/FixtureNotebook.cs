using CapaDatos.Interfaces;
using CapaEntidad;
using CapaNegocio;
using Moq;

namespace AulaDigital.Test;

public class FixtureNotebook
{
    private readonly Mock<IRepoNotebooks> mockRepoNotebooks = null!;
    private readonly Mock<IRepoCarritos> mockRepoCarritos = null!;
    private readonly Mock<IRepoModelo> mockRepoModelo = null!;
    private readonly Mock<IRepoUbicacion> mockRepoUbicacion = null!;
    private readonly Mock<IRepoTipoElemento> mockRepoTipoElemento = null!;
    private readonly Mock<IRepoEstadosMantenimiento> mockRepoEstadosMantenimiento = null!;

    public FixtureNotebook()
    {
        mockRepoNotebooks = new Mock<IRepoNotebooks>();
        mockRepoCarritos = new Mock<IRepoCarritos>();
        mockRepoModelo = new Mock<IRepoModelo>();
        mockRepoUbicacion = new Mock<IRepoUbicacion>();
        mockRepoTipoElemento = new Mock<IRepoTipoElemento>();
        mockRepoEstadosMantenimiento = new Mock<IRepoEstadosMantenimiento>();
    }

    private NotebooksCN CrearService()
    {
        return new NotebooksCN(mockRepoNotebooks.Object, mockRepoCarritos.Object, mockRepoModelo.Object, mockRepoUbicacion.Object);
    }

    private Notebooks CrearNotebookValida()
    {
        return new Notebooks
        {
            IdElemento = 1,
            NumeroSerie = "SN123",
            CodigoBarra = "CB123",
            Patrimonio = "PATR123",
            IdCarrito = null,
            PosicionCarrito = null,
            IdUbicacion = 1,
            IdTipoElemento = 1,
            IdModelo = 1,
            IdEstadoMantenimiento = 1,
            Habilitado = true
        };
    }

    [Fact]
    public void CrearNotebook_CuandoEsValida_LlamaAInsert()
    {
        // Arrange
        var service = CrearService();
        var notebook = CrearNotebookValida();

        mockRepoUbicacion.Setup(r => r.GetById(It.IsAny<int>())).Returns(new Ubicacion() { IdUbicacion = 1, NombreUbicacion = "Aula Digital" });
        mockRepoTipoElemento.Setup(r => r.GetById(It.IsAny<int>())).Returns(new TipoElemento() { IdTipoElemento = 1, ElementoTipo = "Notebook" });
        mockRepoEstadosMantenimiento.Setup(r => r.GetById(It.IsAny<int>())).Returns(new EstadosMantenimiento() { IdEstadoMantenimiento = 1, EstadoMantenimientoNombre = "Disponible" });
        mockRepoModelo.Setup(r => r.GetById(It.IsAny<int>())).Returns(new Modelos() { IdModelo = 1, IdTipoElemento = 1, NombreModelo = "Ferrari" });

        mockRepoNotebooks.Setup(r => r.GetByNumeroSerie(notebook.NumeroSerie)).Returns((Notebooks?)null);
        mockRepoNotebooks.Setup(r => r.GetByCodigoBarra(notebook.CodigoBarra)).Returns((Notebooks?)null);
        mockRepoNotebooks.Setup(r => r.GetByPatrimonio(notebook.Patrimonio)).Returns((Notebooks?)null);

        // Act
        service.CrearNotebook(notebook);

        // Assert
        mockRepoNotebooks.Verify(r => r.Insert(It.IsAny<Notebooks>()), Times.Once);
    }


}
