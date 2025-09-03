-- Mostrar el Historial de un Elemento junto al usuario logueado

drop view if exists GetHistorialElementosDTO;

create view GetHistorialElementosDTO as
	select he.idHistorialElemento,
       he.fechaHora,
       he.observacion,
       te.elemento as ElementoTipo,
       e.numeroSerie,
       c.numeroSerieCarrito,
       ee.estadoMantenimiento as EstadoMantenimientoNombre
from HistorialElementos he
join Elementos e using(idElemento)
left join carritos c on e.idCarrito = c.idCarrito
join TipoElemento te on e.idTipoElemento = te.idTipoElemento 
join EstadosMantenimiento ee ON e.idEstadoMantenimiento = ee.idEstadoMantenimiento;
