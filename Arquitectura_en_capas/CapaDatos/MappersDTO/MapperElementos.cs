﻿using CapaEntidad;
using CapaDTOs;
using CapaDatos.InterfacesDTO;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperElementos : RepoBase, IMapperElementos
{
    public MapperElementos(IDbConnection conexion)
    : base(conexion)
    {
    }

    #region consulta join con splitOn para mostrar en la UI
    public IEnumerable<ElementosDTO> GetAllDTO()
    {
        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, Carritos, ElementosDTO>(
            "GetElementosDTO",
            (elemento, tipo, estado, carrito) => new ElementosDTO
            {
                IdElemento = elemento.IdElemento,
                NumeroSerie = elemento.numeroSerie,
                CodigoBarra = elemento.codigoBarra,
                TipoElemento = tipo.ElementoTipo,
                Estado = estado.EstadoMantenimientoNombre,
                Carrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                PosicionCarrito = elemento?.PosicionCarrito
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoMantenimientoNombre,NumeroSerieCarrito"
        ).ToList();
    }
    #endregion

    #region Obtener por Id Elemetos
    public ElementosDTO? GetByIdDTO(int idElemento)
    {
        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("@idElemento", idElemento, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, Carritos, ElementosDTO>(
            "GetElementoByIdDTO",
            (elemento, tipo, estado, carrito) => new ElementosDTO
            {
                IdElemento = elemento.IdElemento,
                NumeroSerie = elemento.numeroSerie,
                CodigoBarra = elemento.codigoBarra,
                TipoElemento = tipo.ElementoTipo,
                Estado = estado.EstadoMantenimientoNombre,
                Carrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                PosicionCarrito = elemento?.PosicionCarrito
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoMantenimientoNombre,NumeroSerieCarrito"
        ).FirstOrDefault();

    }
    #endregion

    #region mostrar datos por carrito
    public IEnumerable<ElementosDTO> GetByCarritoDTO(int idCarrito)
    {
        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("@idCarrito", idCarrito, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, Carritos, ElementosDTO>(
            "GetElementoByCarritoDTO",
            (elemento, tipo, estado, carrito) => new ElementosDTO
            {
                IdElemento = elemento.IdElemento,
                NumeroSerie = elemento.numeroSerie,
                CodigoBarra = elemento.codigoBarra,
                TipoElemento = tipo.ElementoTipo,
                Estado = estado.EstadoMantenimientoNombre,
                Carrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                PosicionCarrito = elemento?.PosicionCarrito
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoMantenimientoNombre,NumeroSerieCarrito"
        ).ToList();

    }
    #endregion

    #region Mostrar datos por el tipo de elemento
    public IEnumerable<ElementosDTO> GetByTipoDTO(int idTipoElemento)
    {
        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("@idTipoElemento", idTipoElemento, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, Carritos, ElementosDTO>(
            "GetElementosByTipoDTO",
            (elemento, tipo, estado, carrito) => new ElementosDTO
            {
                IdElemento = elemento.IdElemento,
                NumeroSerie = elemento.numeroSerie,
                CodigoBarra = elemento.codigoBarra,
                TipoElemento = tipo.ElementoTipo,
                Estado = estado.EstadoMantenimientoNombre,
                Carrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                PosicionCarrito = elemento?.PosicionCarrito
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoMantenimientoNombre,NumeroSerieCarrito"
        ).ToList();
    }
    #endregion

    #region Mostrar datos por el codigo de barra
    public ElementosDTO? GetByCodigoBarraDTO(string codigoBarra)
    {
        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("@codigoBarra", codigoBarra, DbType.String, ParameterDirection.Input);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, Carritos, ElementosDTO>(
            "GetElementosByCodigoBarraDTO",
            (elemento, tipo, estado, carrito) => new ElementosDTO
            {
                IdElemento = elemento.IdElemento,
                NumeroSerie = elemento.numeroSerie,
                CodigoBarra = elemento.codigoBarra,
                TipoElemento = tipo.ElementoTipo,
                Estado = estado.EstadoMantenimientoNombre,
                Carrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                PosicionCarrito = elemento?.PosicionCarrito
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoMantenimientoNombre,NumeroSerieCarrito"
        ).FirstOrDefault();
    }
    #endregion
}
