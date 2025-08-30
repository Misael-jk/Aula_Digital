delimiter $$

drop procedure if exists DeleteDocente $$
create procedure DeleteDocente(in unidDocente smallint)
begin
	delete
	from docentes 
	where idDocente = unidDocente;
end $$

delimiter;