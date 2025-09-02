-- ROL insert

INSERT INTO Rol (rol) VALUES
('Administrador'),
('Usuario'),
('Invitado');


-- USUARIOS inserts 

INSERT INTO Usuarios (usuario, pass, nombre, apellido, idRol, email, FotoPerfil) VALUES
('admin', 'hashed_password1', 'Juan', 'Perez', 1, 'juan.perez@mail.com', NULL),
('user1', 'hashed_password2', 'Ana', 'Gomez', 2, 'ana.gomez@mail.com', NULL),
('guest', 'hashed_password3', 'Luis', 'Ramirez', 3, 'luis.ramirez@mail.com', NULL);


-- DOCENTES inserts 

INSERT INTO Docentes (dni, nombre, apellido, email) VALUES
(30123456, 'Maria', 'Fernandez', 'maria.fernandez@mail.com'),
(30123457, 'Carlos', 'Sanchez', 'carlos.sanchez@mail.com');


-- TIPO ELEMENTOS inserts 

INSERT INTO tipoElemento (elemento) VALUES
('Notebook'),
('Proyector'),
('Tablet');


-- ESTADOS ELEMENTOS inserts

INSERT INTO EstadosElemento (estadoElemento) VALUES
('Disponible'),
('En mantenimiento'),
('Prestado');


-- CARRITOS inserts

INSERT INTO Carritos (numeroSerieCarrito, disponibleCarrito) VALUES
('CARR-001', TRUE),
('CARR-002', TRUE);


-- ELEMENTOS inserts

-- ELEMENTOS inserts

INSERT INTO Elementos (idTipoElemento, idCarrito, posicionCarrito , idEstadoElemento, numeroSerie, codigoBarra, disponible) VALUES
(1, null, null, 1, 'NB001', 'CB001', TRUE),
(2, NULL, null, 1, 'PR001', 'CB002', TRUE),
(3, null, null, 2, 'TB001', 'CB003', FALSE),
(1, null, null, 1, 'NB002', 'CB004', TRUE),
(1, null, null, 1, 'NB003', 'CB005', TRUE),
(1, null, null, 1, 'NB004', 'CB006', TRUE),
(1, null, null, 1, 'NB005', 'CB007', TRUE),
(1, null, null, 1, 'NB006', 'CB008', TRUE),
(1, null, null, 1, 'NB007', 'CB009', TRUE),
(1, null, null, 1, 'NB008', 'CB010', TRUE),
(1, null, null, 1, 'NB009', 'CB011', TRUE),
(1, null, null, 1, 'NB010', 'CB012', TRUE),
(1, null, null, 1, 'NB011', 'CB013', TRUE),
(1, null, null, 1, 'NB012', 'CB014', TRUE),
(1, null, null, 1, 'NB013', 'CB015', TRUE),
(1, null, null, 1, 'NB014', 'CB016', TRUE),
(1, null, null, 1, 'NB015', 'CB017', TRUE),
(1, null, null, 1, 'NB016', 'CB018', TRUE),
(1, null, null, 1, 'NB017', 'CB019', TRUE),
(1, null, null, 1, 'NB018', 'CB020', TRUE),
(1, null, null, 1, 'NB019', 'CB021', TRUE),
(1, null, null, 1, 'NB020', 'CB022', TRUE),
(1, null, null, 1, 'NB021', 'CB023', TRUE),
(1, null, null, 1, 'NB022', 'CB024', TRUE),
(1, null, null, 1, 'NB023', 'CB025', TRUE),
(1, null, null, 1, 'NB024', 'CB026', TRUE),
(1, null, null, 1, 'NB025', 'CB027', TRUE),
(1, null, null, 1, 'NB026', 'CB028', TRUE),
(1, null, null, 1, 'NB027', 'CB029', TRUE),
(1, null, null, 1, 'NB028', 'CB030', TRUE),
(1, 1, 7, 1, 'NB029', 'CB031', TRUE),
(1, 1, 2, 1, 'NB030', 'CB032', TRUE),
(1, 2, 7, 2, 'NB031', 'CB033', TRUE),
(1, 2, 24, 1, 'NB032', 'CB034', TRUE);



-- CURSOS inserts

INSERT INTO Cursos (curso) VALUES
('Matemáticas'),
('Lengua'),
('Ciencias');


-- ESTADOS de DEVOLUCION inserts

INSERT INTO EstadosPrestamo (estadoPrestamo) VALUES
('Activo'),
('Finalizado'),
('Cancelado');


-- PRESTAMOS inserts

INSERT INTO Prestamos (idCurso, idDocente, idCarrito, idEstadoPrestamo, fechaPrestamo) VALUES
(1, 1, 1, 1, '2025-08-01 10:00:00'),
(2, 2, 2, 1, '2025-08-02 11:00:00');


-- PRESTAMOS DETALLES inserts

INSERT INTO PrestamoDetalle (idPrestamo, idElemento) VALUES
(1, 1),
(2, 3);


-- DEVOLUCIONES inserts

INSERT INTO Devoluciones (idPrestamo, idDocente, idUsuario, idEstadoPrestamo, fechaDevolucion, observaciones) VALUES
(1, 1, 1, 2, '2025-08-05 15:00:00', 'Sin daños'),
(2, 2, 2, 2, '2025-08-06 16:00:00', 'Con problemas en batería');


-- DEVOLUCION DETALLE inserts 


INSERT INTO DevolucionDetalle (idDevolucion, idElemento, idEstadoElemento, observaciones) VALUES
(1, 1, 1, null),
(2, 3, 1, "Devuelto con anomalias");


-- Elemento 1: Notebook (Prestado y luego Devuelto sin daños)


INSERT INTO HistorialElementos (idElemento, idCarrito, idUsuario, idEstadoElemento, fechaHora, observacion) VALUES
(1, 1, 1, 1, '2025-07-31 09:00:00', 'Ingreso al sistema - disponible'),
(1, 1, 1, 3, '2025-08-01 10:00:00', 'Prestado al docente María Fernández - curso Matemáticas'),
(1, 1, 1, 1, '2025-08-05 15:00:00', 'Devuelto sin daños');


-- Elemento 3: Tablet (Prestado y Devuelto con anomalías, ya estaba en mal estado)


INSERT INTO HistorialElementos (idElemento, idCarrito, idUsuario, idEstadoElemento, fechaHora, observacion) VALUES
(3, 2, 2, 2, '2025-07-31 09:30:00', 'Ingreso al sistema - en mantenimiento'),
(3, 2, 2, 3, '2025-08-02 11:00:00', 'Prestado al docente Carlos Sánchez - curso Lengua'),
(3, 2, 2, 1, '2025-08-06 16:00:00', 'Devuelto con problemas en batería');


-- Elemento 2: Proyector (Nunca prestado)


INSERT INTO HistorialElementos (idElemento, idCarrito, idUsuario, idEstadoElemento, fechaHora, observacion) VALUES
(2, NULL, 1, 1, '2025-07-31 09:15:00', 'Ingreso al sistema - disponible (sin asignación de carrito)');