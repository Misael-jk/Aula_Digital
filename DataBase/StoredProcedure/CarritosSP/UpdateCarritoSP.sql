delimiter $$ 

drop procedure if exists UpdateCarrito $$
create procedure UpdateCarrito(in unidCarrito tinyint, in unnumeroSerieCarrito varchar(40), in undisponibleCarrito boolean)
begin
	update carritos 
	set numeroSerieCarrito = unnumeroSerieCarrito, disponibleCarrito = undisponibleCarrito
	where idCarrito = unidCarrito;
end $$

delimiter;