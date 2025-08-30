delimiter $$ 

drop procedure if exists UpdateElemento $$
create procedure UpdateElemento(in unidElemento tinyint, in unidTipoElemento tinyint, in unidEstadoElemento tinyint, in unidCarrito tinyint, in unnumeroSerie varchar(40), in uncodigoBarra varchar(40), in undisponible boolean, in unafechaBaja datetime)
begin
	update elementos 
	set idTipoElemento = unidTipoElemento,
		idEstadoElemento = unidEstadoElemento,
		idCarrito = unidCarrito,
		numeroSerie = unnumeroSerie,
		codigoBarra = uncodigoBarra,
		disponible = undisponible,
		fechaBaja = unafechaBaja
	where idElemento = unidElemento;
end $$

delimiter;