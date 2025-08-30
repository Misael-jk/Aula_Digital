delimiter $$

drop procedure if exists InsertElemento $$
create procedure InsertElemento (out unidElemento tinyint, in unidTipoElemento tinyint, in unidEstadoElemento tinyint, in unidCarrito tinyint, in unnumeroSerie varchar(40), in uncodigoBarra varchar(40), in undisponible boolean, in unafechaBaja datetime)
begin
    insert into elementos (idTipoElemento, idEstadoElemento, idCarrito, numeroSerie, codigoBarra, disponible, fechaBaja)
    values (unidTipoElemento, unidEstadoElemento, unidCarrito, unnumeroSerie, uncodigoBarra, undisponible, unafechaBaja);

    set unidElemento = last_insert_id();
end $$

delimiter;
