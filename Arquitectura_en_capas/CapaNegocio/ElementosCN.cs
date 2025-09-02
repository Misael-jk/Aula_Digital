using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaEntidad;

namespace CapaNegocio
{
    public class ElementosCN
    {
        private readonly IMapperElementos _mapperElementos;
        private readonly IRepoElemento _repoElemento;
        private readonly IRepoCarritos _repoCarritos;
        private readonly IRepoHistorialElemento _repoHistorialElementos;

        public ElementosCN(IMapperElementos mapperElementos, IRepoElemento repoElemento, IRepoCarritos repoCarritos, IRepoHistorialElemento repoHistorialElementos)
        {
            _mapperElementos = mapperElementos;
            _repoElemento = repoElemento;
            _repoCarritos = repoCarritos;
            _repoHistorialElementos = repoHistorialElementos;
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
        public void CrearElemento(Elemento elementoNEW, int idUsuario)
        {
            if(string.IsNullOrEmpty(elementoNEW.numeroSerie))
            {
                throw new Exception("El numero de serie es obligatorio");
            }

            if(string.IsNullOrEmpty(elementoNEW.codigoBarra))
            {
                throw new Exception("El código de barras es obligatorio");
            }

            Elemento? nroSerieHabilitado = _repoElemento.GetByNumeroSerie(elementoNEW.numeroSerie);

            if(nroSerieHabilitado != null)
            {
                if(nroSerieHabilitado.Disponible == true)
                {
                    throw new Exception("El elemento ya existe y está habilitado.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de crear uno nuevo.");
                }
            }

            Elemento? codigoBarraHabilitado = _repoElemento.GetByCodigoBarra(elementoNEW.codigoBarra);

            if(codigoBarraHabilitado != null)
            {
                if (codigoBarraHabilitado.Disponible == true)
                {
                    throw new Exception("El elemento ya existe y está habilitado.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de crear uno nuevo.");
                }
            }

            if (elementoNEW.IdTipoElemento <= 0)
            {
                throw new Exception("El tipo de elemento es obligatorio");
            }

            if (elementoNEW.IdEstadoElemento != 1)
            {
                throw new Exception("El estado del elemento debe ser 'Disponible' al momento de crearlo");
            }

            if (elementoNEW.Disponible == false)
            {
                throw new Exception("El elemento debe estar disponible al momento de crearlo");
            }

            if (elementoNEW.IdTipoElemento != 1 && elementoNEW.IdCarrito != null)
            {
                throw new Exception("Solo las notebooks pueden seleccionar un carrito");
            }

            elementoNEW.IdCarrito = null;
            elementoNEW.PosicionCarrito = null;

            _repoElemento.Insert(elementoNEW);

            HistorialElemento historialElemento = new HistorialElemento
            {
                IdElemento = elementoNEW.IdElemento,
                IdCarrito = null,
                idUsuario = idUsuario,
                IdEstadoElemento = elementoNEW.IdEstadoElemento,
                FechaHora = DateTime.Now,
                Observacion = "Creación del elemento"
            };

            _repoHistorialElementos.Insert(historialElemento);
        }
        #endregion

        #region UPDATE ELEMENTO
        public void ActualizarElemento(Elemento elementoNEW, int idUsuario)
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

            Elemento? nroSerieHabilitado = _repoElemento.GetByNumeroSerie(elementoNEW.numeroSerie);

            if (elementoOLD.numeroSerie != elementoNEW.numeroSerie && nroSerieHabilitado != null)
            {
                if (nroSerieHabilitado.Disponible == true)
                {
                    throw new Exception("Ya existe otro elemento con el mismo numero de serie.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de actualizar uno nuevo.");
                }
            }

            Elemento? codigoBarraHabilitado = _repoElemento.GetByCodigoBarra(elementoNEW.codigoBarra);

            if (elementoOLD.codigoBarra != elementoNEW.codigoBarra && codigoBarraHabilitado != null)
            {
                if (codigoBarraHabilitado.Disponible == true)
                {
                    throw new Exception("Ya existe otro elemento con el mismo código de barras.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de actualizar uno nuevo.");
                }
            }

            if (elementoOLD.IdEstadoElemento != elementoNEW.IdEstadoElemento && elementoOLD.IdEstadoElemento == 2)
            {
                throw new Exception("No se puede cambiar el estado de un elemento en prestamo sin terminar su devolucion");
            }

            if(elementoNEW.IdEstadoElemento == 2 && elementoOLD.IdEstadoElemento != 2)
            {
                throw new Exception("No se puede cambiar el estado a 'En Prestamo' por que no se hiso un prestamo");
            }

            if(elementoNEW.IdEstadoElemento != 2 && elementoOLD.IdEstadoElemento == 2)
            {
                throw new Exception("No se puede cambiar el estado de un elemento en prestamo sin terminar su devolucion");
            }

            if(elementoNEW.IdEstadoElemento == 2 && elementoNEW.IdCarrito != null)
            {
                throw new Exception("Un elemento en prestamo no puede estar asignado a un carrito");
            }

            if (_repoCarritos.GetById(elementoNEW.IdCarrito ?? 0) == null && elementoNEW.IdCarrito != null)
            {
                throw new Exception("El carrito asignado no existe");
            }

            int cantidad = _repoCarritos.GetCountByCarrito(elementoNEW.IdCarrito ?? 0);

            if(cantidad >= 25 && elementoNEW.IdCarrito != null)
            {
                throw new Exception("El carrito ya tiene el maximo de elementos permitidos");
            }

            if (elementoNEW.IdCarrito != null)
            {
                if (elementoNEW.PosicionCarrito == null || elementoNEW.PosicionCarrito <= 0)
                {
                    throw new Exception("El elemento asignado a un carrito debe tener una posición válida.");
                }

                Elemento? elementoOld = _repoElemento.GetNotebookByPosicion(elementoNEW.IdCarrito.Value, elementoNEW.PosicionCarrito.Value);

                if (elementoOld != null && elementoOld.IdElemento != elementoNEW.IdElemento)
                {
                    throw new Exception($"La posición {elementoNEW.PosicionCarrito} en el carrito ya está ocupada.");
                }
            }
            else
            {
                elementoNEW.PosicionCarrito = null;
            }


            _repoElemento.Update(elementoNEW);

            HistorialElemento historialElemento = new HistorialElemento
            {
                IdElemento = elementoNEW.IdElemento,
                IdCarrito = elementoNEW.IdCarrito,
                idUsuario = idUsuario,
                IdEstadoElemento = elementoNEW.IdEstadoElemento,
                FechaHora = DateTime.Now,
                Observacion = "Actualización del elemento"
            };

            _repoHistorialElementos.Insert(historialElemento);
        }
        #endregion

        public void DeshabilitarElemento(int idElemento, int idUsuario)
        {
            Elemento? elemento = _repoElemento.GetById(idElemento);

            if (elemento == null)
            {
                throw new Exception("El elemento no existe.");
            }

            if (elemento.IdEstadoElemento == 2)
            {
                throw new Exception("No se puede deshabilitar un elemento que está en préstamo.");
            }

            if (!elemento.Disponible)
            {
                throw new Exception("El elemento ya está deshabilitado.");
            }

            if (elemento.IdCarrito != null && elemento.PosicionCarrito != null)
            {
                elemento.PosicionCarrito = null;
            }

            _repoElemento.CambiarDisponible(idElemento, false);

            HistorialElemento historialElemento = new HistorialElemento
            {
                IdElemento = elemento.IdElemento,
                IdCarrito = elemento.IdCarrito,
                idUsuario = idUsuario,
                IdEstadoElemento = elemento.IdEstadoElemento,
                FechaHora = DateTime.Now,
                Observacion = "Deshabilitación del elemento"
            };

            _repoHistorialElementos.Insert(historialElemento);
        }


    }
}
