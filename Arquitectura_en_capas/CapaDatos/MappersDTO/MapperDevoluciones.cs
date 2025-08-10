using CapaDTOs;
using CapaDatos.InterfacesDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperDevoluciones : RepoBase, IMapperDevoluciones
{
    public MapperDevoluciones(IDbConnection conexion)
      : base(conexion)
    {
    }

    #region Obtener todas las devoluciones
    public IEnumerable<DevolucionesDTO> GetAllDTO()
    {
        return Conexion.Query<Devolucion, Prestamos, Docentes, Usuarios, DevolucionesDTO>(
            "GetDevolucionesDTO",
            (devolucion, prestamo, docente, Usuarios) => new DevolucionesDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                ApellidoDocente = docente.Apellido,
                ApellidoEncargado = Usuarios.Apellido,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                Observaciones = devolucion.Observaciones
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "Apellido, Apellido, FechaPrestamo" 
        ).ToList();
    }
    #endregion

    #region Obtener por Id de prestamo
    public DevolucionesDTO? GetByIdDTO(int idPrestamo)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idPrestamo", idPrestamo, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Devolucion, Prestamos, Docentes, Usuarios, DevolucionesDTO>(
            "GetDevolucionByPrestamoDTO",
            (devolucion, prestamos, docente, encargado) => new DevolucionesDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                ApellidoDocente = docente.Apellido,
                ApellidoEncargado = encargado.Apellido,
                FechaPrestamo = prestamos.FechaPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                Observaciones = devolucion.Observaciones
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "Apellido,Apellido"
        ).FirstOrDefault();
    }
    #endregion

    #region Obtener por Id de docente
    public IEnumerable<DevolucionesDTO> GetByDocenteDTO(int idDocente)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idDocente", idDocente, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Devolucion, Prestamos, Docentes, Usuarios, DevolucionesDTO>(
            "GetDevolucionesByDocenteDTO",
            (devolucion, prestamos,docente, encargado) => new DevolucionesDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                ApellidoDocente = docente.Apellido,
                ApellidoEncargado = encargado.Apellido,
                FechaPrestamo = prestamos.FechaPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                Observaciones = devolucion.Observaciones
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "Apellido, Apellido, FechaPrestamo"
        ).ToList();
    }
    #endregion
}