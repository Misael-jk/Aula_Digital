using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDatos.Repos;
using CapaDTOs;
using CapaEntidad;
using System.Configuration;

namespace CapaNegocio;

public class CarritosBajasCN
{
    private readonly IRepoCarritos repoCarritos;
    private readonly IMapperCarritosBajas _mapperCarritosBajas;

    public CarritosBajasCN(IMapperCarritosBajas mapperCarritosBajas, IRepoCarritos repoCarritos)
    {
        _mapperCarritosBajas = mapperCarritosBajas;
        this.repoCarritos = repoCarritos;
    }

    public IEnumerable<CarrtiosBajasDTO> GetAllDTO()
    {
        return _mapperCarritosBajas.GetAllDTO();
    }

    public void HabilitarCarrito(int idCarrito)
    {
        Carritos? carritos = repoCarritos.GetById(idCarrito);

        if (carritos == null)
        {
            throw new Exception("El elemento no existe.");
        }

        if (carritos.Habilitado)
        {
            throw new Exception("El elemento ya esta habilitado.");
        }

        carritos.Habilitado = true;
        carritos.IdEstadoMantenimiento = 1;
        carritos.FechaBaja = null;

        repoCarritos.Update(carritos);
    }
}
