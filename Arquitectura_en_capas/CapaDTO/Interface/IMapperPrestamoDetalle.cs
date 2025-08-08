using CapaDTO.DTOs;

namespace CapaDTO.Interface;

public interface IMapperPrestamoDetalle
{
    IEnumerable<PrestamosDetalleDTO> GetAllDTO();
    //PrestamosDetalleDTO? GetByIdDTO(int idPrestamoDetalle);
    IEnumerable<PrestamosDetalleDTO> GetByPrestamoDTO(int idPrestamo);
}
