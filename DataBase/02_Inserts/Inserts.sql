-- ROL insert
INSERT INTO Rol (rol) VALUES
('Administrador'),
('Usuario'),
('Invitado');

-- USUARIOS inserts 
INSERT INTO Usuarios (usuario, pass, nombre, apellido, idRol, email, FotoPerfil, habilitado) VALUES
('admin', 'hashed_password1', 'Juan', 'Perez', 1, 'juan.perez@mail.com', NULL, TRUE),
('user1', 'hashed_password2', 'Ana', 'Gomez', 2, 'ana.gomez@mail.com', NULL, TRUE),
('guest', 'hashed_password3', 'Luis', 'Ramirez', 3, 'luis.ramirez@mail.com', NULL, TRUE);

-- DOCENTES inserts 
INSERT INTO Docentes (dni, nombre, apellido, email, habilitado) VALUES
(30123456, 'Maria', 'Fernandez', 'maria.fernandez@mail.com', TRUE),
(30123457, 'Carlos', 'Sanchez', 'carlos.sanchez@mail.com', TRUE);

-- UBICACION inserts
INSERT INTO Ubicacion (ubicacion) VALUES
('Depósito A'),
('Depósito B');

-- TIPO ELEMENTOS inserts 
INSERT INTO TipoElemento (elemento) VALUES
('Notebook'),
('Proyector'),
('Tablet');

-- MODELOS inserts
INSERT INTO Modelo (idTipoElemento, modelo) VALUES
(1, 'Dell Latitude 3410'),
(1, 'HP ProBook 450'),
(2, 'Epson X200'),
(3, 'Samsung Tab A');

-- ESTADOS MANTENIMIENTO inserts
INSERT INTO EstadosMantenimiento (estadoMantenimiento) VALUES
('Disponible'),
('En mantenimiento'),
('Prestado');

-- CARRITOS inserts
INSERT INTO Carritos (numeroSerieCarrito, idEstadoMantenimiento, idUbicacion, idModelo, Habilitado) VALUES
('CARR-001', 1, 1, 1, TRUE),
('CARR-002', 1, 2, 1, TRUE);

-- ELEMENTOS inserts
INSERT INTO Elementos (idTipoElemento, idModelo, idUbicacion, idEstadoMantenimiento, numeroSerie, codigoBarra, patrimonio, habilitado)
VALUES
(1, 1, 1, 1, 'NB001', 'CB001', 'PAT001', TRUE),
(2, 3, 1, 1, 'PR001', 'CB002', 'PAT002', TRUE),
(3, 4, 2, 2, 'TB001', 'CB003', 'PAT003', FALSE),
(1, 1, 1, 1, 'NB002', 'CB004', 'PAT004', TRUE);

-- NOTEBOOKS (ligadas a Elementos tipo Notebook)
INSERT INTO Notebooks (idElemento, idCarrito, posicionCarrito) VALUES
(1, 1, 1),
(4, 2, 2);

-- CURSOS inserts
INSERT INTO Cursos (curso) VALUES
('Matemáticas'),
('Lengua'),
('Ciencias');

-- ESTADOS PRESTAMO inserts
INSERT INTO EstadosPrestamo (estadoPrestamo) VALUES
('Activo'),
('Finalizado'),
('Cancelado');

-- PRESTAMOS inserts (ahora requieren idUsuarioRecibio)
INSERT INTO Prestamos (idUsuarioRecibio, idCurso, idDocente, idCarrito, idEstadoPrestamo, fechaPrestamo) VALUES
(1, 1, 1, 1, 1, '2025-08-01 10:00:00'),
(2, 2, 2, 2, 1, '2025-08-02 11:00:00');

-- PRESTAMOS DETALLES inserts
INSERT INTO PrestamoDetalle (idPrestamo, idElemento) VALUES
(1, 1),
(2, 3);

-- DEVOLUCIONES inserts (ajustado a nueva estructura)
INSERT INTO Devoluciones (idPrestamo, idUsuarioDevolvio, fechaDevolucion, observaciones) VALUES
(1, 1, '2025-08-05 15:00:00', 'Sin daños'),
(2, 2, '2025-08-06 16:00:00', 'Con problemas en batería');

-- DEVOLUCION DETALLE inserts 
INSERT INTO DevolucionDetalle (idDevolucion, idElemento, idEstadoMantenimiento, observaciones) VALUES
(1, 1, 1, NULL),
(2, 3, 1, 'Devuelto con anomalías');

-- TIPO ACCION inserts
INSERT INTO TipoAccion (accion) VALUES
('Alta'),
('Modificación'),
('Baja'),
('Préstamo'),
('Devolución');

-- HISTORIAL CAMBIO + HISTORIAL ELEMENTOS
INSERT INTO HistorialCambio (idTipoAccion, idUsuario, fechaCambio, observacion) VALUES
(1, 1, '2025-07-31 09:00:00', 'Ingreso al sistema - disponible'),
(4, 1, '2025-08-01 10:00:00', 'Préstamo al docente María Fernández - curso Matemáticas'),
(5, 1, '2025-08-05 15:00:00', 'Devolución sin daños'),
(1, 2, '2025-07-31 09:30:00', 'Ingreso al sistema - en mantenimiento'),
(4, 2, '2025-08-02 11:00:00', 'Préstamo al docente Carlos Sánchez - curso Lengua'),
(5, 2, '2025-08-06 16:00:00', 'Devolución con problemas en batería');

-- Relacionamos cambios con elementos
INSERT INTO HistorialElemento (idHistorialCambio, idElemento) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 3),
(5, 3),
(6, 3);
