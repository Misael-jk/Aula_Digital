using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperPrestamoDetalle
{
    IEnumerable<PrestamosDetalleDTO> GetAllDTO();
    //PrestamosDetalleDTO? GetByIdDTO(int idPrestamoDetalle);
    IEnumerable<PrestamosDetalleDTO> GetByPrestamoDTO(int idPrestamo);
}
