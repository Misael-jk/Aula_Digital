delimiter $$

drop procedure if exists InsertCarrito $$
create procedure InsertCarrito(out unidCarrito tinyint, in unnumeroSerieCarrito varchar(40), in undisponibleCarrito boolean)
begin
	insert into carritos (numeroSerieCarrito, disponibleCarrito)
	values (unnumeroSerieCarrito, undisponibleCarrito);

	set unidCarrito = last_insert_id(); 
end $$

delimiter;