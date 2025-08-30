delimiter $$

drop procedure if exists DeleteCarrito $$
create procedure DeleteCarrito(in unidCarrito tinyint)
begin
	delete 
	from carritos c 
	where idCarrito = unidCarrito;
end $$

delimiter;