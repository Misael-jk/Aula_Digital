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
        private readonly IRepoUbicacion repoUbicacion;
        private readonly IRepoModelo repoModelo;

        public ElementosCN(IMapperElementos mapperElementos, IRepoModelo repoModelo, IRepoUbicacion repoUbicacion, IRepoElemento repoElemento)
        {
            _mapperElementos = mapperElementos;
            this.repoModelo = repoModelo;
            this.repoUbicacion = repoUbicacion;
            _repoElemento = repoElemento;

        }

        #region Metodos de Lectura para la UI DTOs

        #region Mostrar Elementos completos
        public IEnumerable<ElementosDTO> ObtenerElementos()
        {
            return _mapperElementos.GetAllDTO();
        }
        #endregion

        //#region mostrar por carrito 
        //public IEnumerable<ElementosDTO> ObtenerPorCarrito(int idCarrito)
        //{
        //    return _mapperElementos.GetByCarritoDTO(idCarrito);
        //}
        //#endregion

        //#region mostrar por Codigo de Barra
        //public ElementosDTO? ObtenerPorCodigoBarra(string codigoBarra)
        //{
        //    return _mapperElementos.GetByCodigoBarraDTO(codigoBarra);
        //}
        //#endregion

        //#region mostrar por tipo
        //public IEnumerable<ElementosDTO> ObtenerPorTipo(int idTipoElemento)
        //{
        //    return _mapperElementos.GetByTipoDTO(idTipoElemento);
        //}
        //#endregion

        #endregion


        #region INSERT ELEMENTO
        public void CrearElemento(Elemento elementoNEW, int idUsuario)
        {
            if(string.IsNullOrEmpty(elementoNEW.NumeroSerie))
            {
                throw new Exception("El numero de serie es obligatorio");
            }

            if(string.IsNullOrEmpty(elementoNEW.CodigoBarra))
            {
                throw new Exception("El código de barras es obligatorio");
            }

            if((string.IsNullOrEmpty(elementoNEW.Patrimonio)))
            {
                throw new Exception("El patrimonio es obligatorio");
            }

            Elemento? nroSerieHabilitado = _repoElemento.GetByNumeroSerie(elementoNEW.NumeroSerie);

            if(nroSerieHabilitado != null)
            {
                if(nroSerieHabilitado.Habilitado == true)
                {
                    throw new Exception("El elemento ya existe con ese numero de serie y está habilitado.");
                }
                else
                {
                    throw new Exception("El elemento ya existe con ese numero de serie pero está deshabilitado, por favor habilitelo antes de crear uno nuevo.");
                }
            }

            Elemento? codigoBarraHabilitado = _repoElemento.GetByCodigoBarra(elementoNEW.CodigoBarra);

            if(codigoBarraHabilitado != null)
            {
                if (codigoBarraHabilitado.Habilitado == true)
                {
                    throw new Exception("El elemento ya existe con ese codigo de barra y está habilitado.");
                }
                else
                {
                    throw new Exception("El elemento ya existe con ese codigo de barra pero está deshabilitado, por favor habilitelo antes de crear uno nuevo.");
                }
            }

            Elemento? patrimonioHabilitado = _repoElemento.GetByPatrimonio(elementoNEW.Patrimonio);

            if (patrimonioHabilitado != null)
            {
                if (patrimonioHabilitado.Habilitado == true)
                {
                    throw new Exception("El elemento ya existe con ese patrimonio y está habilitado.");
                }
                else
                {
                    throw new Exception("El elemento ya existe con ese patrimonio pero está deshabilitado, por favor habilitelo antes de crear uno nuevo.");
                }
            }

            if (elementoNEW.IdTipoElemento <= 0)
            {
                throw new Exception("El tipo de elemento es obligatorio");
            }

            if (elementoNEW.IdEstadoMantenimiento != 1)
            {
                throw new Exception("El estado del elemento debe ser 'Disponible' al momento de crearlo");
            }

            if(repoUbicacion.GetById(elementoNEW.IdUbicacion) == null)
            {
                throw new Exception("Ubicacion del elemento invalida");
            }

            if(repoModelo.GetById(elementoNEW.IdModelo) == null)
            {
                throw new Exception("Modelo del elemento invalida");
            }

            if(repoModelo.GetByTipo(elementoNEW.IdTipoElemento) == null)
            {
                throw new Exception("El modelo debe ser correspondiente al tipo de elemento");
            }

            if (elementoNEW.Habilitado == false)
            {
                throw new Exception("El elemento debe estar disponible al momento de crearlo");
            }


            _repoElemento.Insert(elementoNEW);

        }
        #endregion

        #region UPDATE ELEMENTO
        public void ActualizarElemento(Elemento elementoNEW, int idUsuario)
        {

            if (string.IsNullOrEmpty(elementoNEW.NumeroSerie))
            {
                throw new Exception("El numero de serie es obligatorio");
            }

            if (string.IsNullOrEmpty(elementoNEW.CodigoBarra))
            {
                throw new Exception("El código de barras es obligatorio");
            }

            if(string.IsNullOrEmpty(elementoNEW.Patrimonio))
            {
                throw new Exception("El patrimonio es obligatorio");
            }

            Elemento? elementoOLD = _repoElemento.GetById(elementoNEW.IdElemento);

            if (elementoOLD == null)
            {
                throw new Exception("El elemento no existe");
            }

            if (repoUbicacion.GetById(elementoNEW.IdUbicacion) == null)
            {
                throw new Exception("Ubicacion del elemento invalida");
            }

            if (repoModelo.GetById(elementoNEW.IdModelo) == null)
            {
                throw new Exception("Modelo del elemento invalida");
            }

            if(_repoElemento.GetByPatrimonio(elementoNEW.Patrimonio) == null)
            {
                throw new Exception("El patrimonio no existe en otro elemento, por favor elija uno existente");
            }

            if(elementoOLD.IdTipoElemento != elementoNEW.IdTipoElemento)
            {
                throw new Exception("No se puede cambiar el tipo de elemento");
            }

            if (repoModelo.GetByTipo(elementoNEW.IdTipoElemento) == null)
            {
                throw new Exception("El modelo debe ser correspondiente al tipo de elemento");
            }

            Elemento? patrimonioHabilitado = _repoElemento.GetByPatrimonio(elementoNEW.Patrimonio);

            if(elementoOLD.Patrimonio != elementoNEW.Patrimonio && patrimonioHabilitado != null)
            {
                if (patrimonioHabilitado.Habilitado == true)
                {
                    throw new Exception("Ya existe otro elemento con el mismo patrimonio.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de actualizar uno nuevo.");
                }
            }

            Elemento? nroSerieHabilitado = _repoElemento.GetByNumeroSerie(elementoNEW.NumeroSerie);

            if (elementoOLD.NumeroSerie != elementoNEW.NumeroSerie && nroSerieHabilitado != null)
            {
                if (nroSerieHabilitado.Habilitado == true)
                {
                    throw new Exception("Ya existe otro elemento con el mismo numero de serie.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de actualizar uno nuevo.");
                }
            }

            Elemento? codigoBarraHabilitado = _repoElemento.GetByCodigoBarra(elementoNEW.CodigoBarra);

            if (elementoOLD.CodigoBarra != elementoNEW.CodigoBarra && codigoBarraHabilitado != null)
            {
                if (codigoBarraHabilitado.Habilitado == true)
                {
                    throw new Exception("Ya existe otro elemento con el mismo código de barras.");
                }
                else
                {
                    throw new Exception("El elemento ya existe pero está deshabilitado, por favor habilitelo antes de actualizar uno nuevo.");
                }
            }

            if(elementoNEW.IdEstadoMantenimiento == 2 && elementoOLD.IdEstadoMantenimiento != 2)
            {
                throw new Exception("No se puede cambiar el estado a 'En Prestamo' por que no se hiso un prestamo");
            }

            if(elementoNEW.IdEstadoMantenimiento != 2 && elementoOLD.IdEstadoMantenimiento == 2)
            {
                throw new Exception("No se puede cambiar el estado de un elemento en prestamo sin terminar su devolucion");
            }


            _repoElemento.Update(elementoNEW);

        }
        #endregion

        public void DeshabilitarElemento(int idElemento, int idEstadoMantenimiento, int idUsuario)
        {
            Elemento? elemento = _repoElemento.GetById(idElemento);

            if (elemento == null)
            {
                throw new Exception("El elemento no existe.");
            }

            if (elemento.IdEstadoMantenimiento == 2)
            {
                throw new Exception("No se puede deshabilitar un elemento que está en préstamo.");
            }

            if (!elemento.Habilitado)
            {
                throw new Exception("El elemento ya está deshabilitado.");
            }

            elemento.Habilitado = false;
            elemento.IdEstadoMantenimiento = idEstadoMantenimiento; 
            elemento.FechaBaja = DateTime.Now;

            _repoElemento.Update(elemento);

        }


    }
}
