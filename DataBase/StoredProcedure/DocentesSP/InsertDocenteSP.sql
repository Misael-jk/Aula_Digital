delimiter $$

drop procedure if exists InsertDocente $$
create procedure InsertDocente (out unidDocente smallint, in undni int, in unnombre varchar(40), in unapellido varchar(40), in unemail varchar(70))
begin
    insert into Docentes(dni, nombre, apellido, email)
    values (undni, unnombre, unapellido, unemail);

    set unidDocente = last_insert_id();
end $$

delimiter;