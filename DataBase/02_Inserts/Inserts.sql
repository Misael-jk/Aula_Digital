use aula_digital;

-- ROL insert

INSERT INTO Rol (rol) VALUES
('Administrador'),
('Usuario'),
('Invitado');


-- USUARIOS inserts 

INSERT INTO Usuarios (usuario, pass, nombre, apellido, idRol, email) VALUES
('admin', 'hashed_password1', 'Juan', 'Pérez', 1, 'juan.perez@mail.com'),
('user1', 'hashed_password2', 'Ana', 'Gómez', 2, 'ana.gomez@mail.com'),
('guest', 'hashed_password3', 'Luis', 'Ramírez', 3, 'luis.ramirez@mail.com');


-- DOCENTES inserts 

INSERT INTO Docentes (dni, nombre, apellido, email) VALUES
(30123456, 'María', 'Fernández', 'maria.fernandez@mail.com'),
(30123457, 'Carlos', 'Sánchez', 'carlos.sanchez@mail.com');


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

INSERT INTO Elementos (idTipoElemento, idCarrito, idEstadoElemento, numeroSerie, codigoBarra, disponible) VALUES
(1, 1, 1, 'NB001', 'CB001', TRUE),
(2, NULL, 1, 'PR001', 'CB002', TRUE),
(3, 2, 2, 'TB001', 'CB003', FALSE);


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
(1, 1, 1, 'OKs'),
(2, 3, 1, 'OK');
