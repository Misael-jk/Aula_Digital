-- Mostrar Usuario disponibles en la UI

delimiter $$

drop view if exists View_GetUsuariosDTO $$
create view View_GetUsuariosDTO as
	select 
        u.idUsuario,
        u.usuario,
        u.pass as Password,
        u.nombre,
        u.apellido,
        u.email as Email,
        r.rol,
        fotoPerfil
    from Usuarios u
    join Rol r using(idRol);

delimiter ;