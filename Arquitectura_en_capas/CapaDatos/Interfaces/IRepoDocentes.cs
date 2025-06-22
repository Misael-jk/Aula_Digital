using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces;

interface IRepoDocentes
{
    public void AltaDocente(Docentes docente);
    public void ActualizarDocente(Docentes docente);
    public void EliminarDocente(int idDocente);
    public IEnumerable<Docentes> ListarDocentes();
    public Docentes? DetalleDocentes(int idDocente);
}
