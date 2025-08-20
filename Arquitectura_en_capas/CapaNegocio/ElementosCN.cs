using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDatos.Repos;
using CapaDTOs;
using CapaEntidad;

namespace CapaNegocio
{
    public class ElementosCN
    {
        private readonly IMapperElementos _mapperElementos;
        private readonly IRepoElemento _repoElemento;

        public ElementosCN(IMapperElementos mapperElementos, IRepoElemento repoElemento)
        {
            _mapperElementos = mapperElementos;
            _repoElemento = repoElemento;
        }

        #region Metodos de Lectura para la UI DTOs

        #region Mostrar Elementos completos
        public IEnumerable<ElementosDTO> ObtenerElementos()
        {
            return _mapperElementos.GetAllDTO();
        }
        #endregion

        #region mostrar por carrito 
        public IEnumerable<ElementosDTO> ObtenerPorCarrito(int idCarrito)
        {
            return _mapperElementos.GetByCarritoDTO(idCarrito);
        }
        #endregion

        #region mostrar por Codigo de Barra
        public ElementosDTO? ObtenerPorCodigoBarra(string codigoBarra)
        {
            return _mapperElementos.GetByCodigoBarraDTO(codigoBarra);
        }
        #endregion

        #region mostrar por tipo
        public IEnumerable<ElementosDTO> ObtenerPorTipo(int idTipoElemento)
        {
            return _mapperElementos.GetByTipoDTO(idTipoElemento);
        }
        #endregion

        #endregion


        #region INSERT ELEMENTO
        public void CrearElemento(Elemento elementoNEW)
        {
            if(string.IsNullOrEmpty(elementoNEW.numeroSerie))
            {
                throw new Exception("El numero de serie es obligatorio");
            }

            if(string.IsNullOrEmpty(elementoNEW.codigoBarra))
            {
                throw new Exception("El código de barras es obligatorio");
            }

            if (_repoElemento.GetByNumeroSerie(elementoNEW.numeroSerie) != null)
            {
                throw new Exception("Ya existe un elemento con ese numero de serie, por favor elija uno nuevo");
            }

            if (_repoElemento.GetByCodigoBarra(elementoNEW.codigoBarra) != null)
            {
                throw new Exception("Ya existe un elemento con el mismo código de barras.");
            }

            if(elementoNEW.IdTipoElemento <= 0)
            {
                throw new Exception("El tipo de elemento es obligatorio");
            }

            if (elementoNEW.IdCarrito <= 0)
            {
                throw new Exception("Debe elegir un carrito");
            }
            
            if(elementoNEW.IdEstadoElemento != 1)
            {
                throw new Exception("El estado del elemento debe ser 'Disponible' al momento de crearlo");
            }

            if (elementoNEW.Disponible == false)
            {
                throw new Exception("El elemento debe estar disponible al momento de crearlo");
            }

            _repoElemento.Insert(elementoNEW);
        }
        #endregion

        #region UPDATE ELEMENTO
        public void ActualizarElemento(Elemento elementoNEW)
        {

            if (string.IsNullOrEmpty(elementoNEW.numeroSerie))
            {
                throw new Exception("El numero de serie es obligatorio");
            }

            if (string.IsNullOrEmpty(elementoNEW.codigoBarra))
            {
                throw new Exception("El código de barras es obligatorio");
            }

            Elemento? elementoOLD = _repoElemento.GetById(elementoNEW.IdElemento);

            if (elementoOLD == null)
            {
                throw new Exception("El elemento no existe");
            }

            if (elementoOLD.numeroSerie != elementoNEW.numeroSerie && _repoElemento.GetByNumeroSerie(elementoNEW.numeroSerie) != null)
            {
                throw new Exception("Ya existe otro elemento con el mismo numero de serie");
            }

            if (elementoOLD.codigoBarra != elementoNEW.codigoBarra && _repoElemento.GetByCodigoBarra(elementoNEW.codigoBarra) != null)
            {
                throw new Exception("Ya existe otro elemento con el mismo codigo de barras.");
            }

            if (elementoOLD.IdEstadoElemento != elementoNEW.IdEstadoElemento && elementoOLD.IdEstadoElemento == 2)
            {
                throw new Exception("No se puede cambiar el estado de un elemento en prestamo sin terminar su devolucion");
            }



            _repoElemento.Update(elementoNEW);
        }
        #endregion

        #region DELETE ELEMENTO 
        public void EliminarElemento(int idElemento)
        {
            Elemento? elementoOLD = _repoElemento.GetById(idElemento);

            if (elementoOLD == null)
            {
                throw new Exception("El elemento no existe.");
            }

            if (elementoOLD.IdEstadoElemento == 2)
            {
                throw new Exception("No se puede eliminar un elemento que está en prestamo");
            }

            _repoElemento.Delete(idElemento);
        }
        #endregion

    }
}
