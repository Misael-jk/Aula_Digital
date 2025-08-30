delimiter $$ 

drop procedure if exists UpdateDocente $$
create procedure UpdateDocente (in unidDocente smallint, in undni int, in unnombre varchar(40), in unapellido varchar(40), in unemail varchar(70))
begin
	update docentes 
	set dni = undni,
		nombre = unnombre,
		apellido = unapellido,
		email = unemail
	where idDocente = unidDocente;
end $$

delimiter;
