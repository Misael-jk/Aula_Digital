using CapaDatos;
using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDatos.MappersDTO;
using CapaDatos.Repos;
using CapaDTOs;
using CapaEntidad;
using System.Data;
using System.Net.Mail;

namespace CapaNegocio;

public class UsuariosCN
{
    private readonly IRepoUsuarios repoUsuarios;
    private readonly MapperUsuarios mapperUsuarios;

    public UsuariosCN(IRepoUsuarios repoUsuarios, IRepoRoles repoRoles, MapperUsuarios mapperUsuarios)
    {
        this.repoUsuarios = repoUsuarios;
        this.mapperUsuarios = mapperUsuarios;
    }

    public IEnumerable<UsuariosDTO> ObtenerElementos()
    {
        return mapperUsuarios.GetAllDTO();
    }

    #region INSERT USUARIO
    public void CrearDocente(Usuarios usuariosNEW)
    {

        ValidarEmail(usuariosNEW.Email);

        if (string.IsNullOrWhiteSpace(usuariosNEW.Usuario))
        {
            throw new Exception("El Usuario esta vacio");
        }

        if (string.IsNullOrWhiteSpace(usuariosNEW.Password))
        {
            throw new Exception("La contraseña esta vacia");
        }

        if (string.IsNullOrWhiteSpace(usuariosNEW.Nombre))
        {
            throw new Exception("El nombre es obligatorio");
        }

        if (string.IsNullOrWhiteSpace(usuariosNEW.Apellido))
        {
            throw new Exception("El apellido es obligatorio");
        }

        if (repoUsuarios.GetByEmail(usuariosNEW.Email) != null)
        {
            throw new Exception("Ya existe un docente ese email");
        }

        repoUsuarios.Insert(usuariosNEW);
    }
    #endregion

    #region UPDATE USUARIO
    public void ActualizarUsuario(Usuarios usuariosNEW)
    {
        ValidarEmail(usuariosNEW.Email);

        if (string.IsNullOrWhiteSpace(usuariosNEW.Usuario))
        {
            throw new Exception("El Usuario esta vacio");
        }
        if (string.IsNullOrWhiteSpace(usuariosNEW.Password))
        {
            throw new Exception("La contraseña esta vacia");
        }
        if (string.IsNullOrWhiteSpace(usuariosNEW.Nombre))
        {
            throw new Exception("El nombre es obligatorio");
        }
        if (string.IsNullOrWhiteSpace(usuariosNEW.Apellido))
        {
            throw new Exception("El apellido es obligatorio");
        }

        Usuarios? usuariosOLD = repoUsuarios.GetById(usuariosNEW.IdUsuario);

        if (usuariosOLD == null)
        {
            throw new Exception("El usuario que eligio no esta registrado en el sistema");
        }

        if (usuariosOLD.Usuario != usuariosNEW.Usuario && repoUsuarios.GetByUser(usuariosNEW.Usuario) != null)
        {
            throw new Exception("Ya existe un usuario con ese nombre de usuario");
        }

        if (usuariosOLD.Email != usuariosNEW.Email && repoUsuarios.GetByEmail(usuariosNEW.Email) != null)
        {
            throw new Exception("Ya existe un usuario con ese email");
        }
        repoUsuarios.Update(usuariosNEW);

    }
    #endregion

    #region DELETE USUARIO
    public void EliminarUsuario(int idUsuario)
    {
        Usuarios? usuariosOLD = repoUsuarios.GetById(idUsuario);

        if (usuariosOLD == null)
        {
            throw new Exception("El usuario no existe");
        }

        if (usuariosOLD.IdRol == 1)
        {
            throw new Exception("No se puede eliminar un usuario con rol de administrador");
        }

        repoUsuarios.Delete(idUsuario);
    }
    #endregion

    #region LOGIN
    public Usuarios Login(string usuario, string password)
    {
        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Usuario y contraseña son obligatorios");
        }

        Usuarios? user = repoUsuarios.GetByUserPass(usuario, password);

        if (user == null)
        {
            throw new Exception("Usuario o contraseña incorrectos");
        }

        return user; 
    }
    #endregion

    #region Validaciones Privadas
    private void ValidarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("No completo la casilla del email");
        }

        try
        {
            MailAddress mail = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new Exception("Email invalido, intente de nuevo");
        }
    }
    #endregion

}
