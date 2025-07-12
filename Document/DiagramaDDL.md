### Diagrama de Base de datos

```mermaid
erDiagram

Encargados {
    tinyint      idEncargado   PK
    varchar(40)   usuario
    varchar(70)   password
    varchar(40)   nombre
    varchar(40)   apellido
    varchar(70)   email
}

Docentes {
    smallint      idDocente   PK
    int           dni
    varchar(40)   nombre
    varchar(40)   apellido
    varchar(70)   email
}

EstadosNotebook {
    tinyint       idEstadoNotebook   PK
    varchar(40)   estadoNotebook
}

Notebooks {
    tinyint   idNotebook         PK
    tinyint   idCarrito          FK
    tinyint   idEstadoNotebook   FK
    boolean   disponibleNotebook
}

Carritos {
    tinyint   idCarrito   PK
    tinyint   cantidad
    boolean   disponibleCarrito
}

Cursos {
    tinyint        idCurso PK
    varchar(40)    curso
}

Prestamos {
    int           idPrestamo      PK
    tinyint       idCurso         FK
    smallint      idDocente       FK
    tinyint       idCarrito       FK
    tinyint       idEncargado     FK
    datetime      fechaPrestamo
}

EstadosPrestamo {
    tinyint       idEstadoPrestamo   PK
    varchar(40)   estadoPrestamo
}

PrestamoDetalle {
    int         idPrestamo         PK, FK
    tinyint     idNotebook         PK, FK
    tinyint     idEstadoPrestamo   FK
}

Devoluciones {
    int            idDevolucion       PK
    int            idPrestamo         FK
    tinyint        idNotebook         FK
    smallint       idDocente          FK
    tinyint        idEstadoPrestamo   FK
    tinyint        idEncargado        FK
    datetime       fechaDevolucion
    varchar(200)   observaciones
}

Encargados ||--o{ Prestamos : realiza
Encargados ||--o{ Devoluciones : recibe

Docentes ||--o{ Prestamos : realiza
Docentes ||--o{ Devoluciones : devuelve

Cursos ||--o{ Prestamos : contiene

Carritos ||--o{ Notebooks : incluye
Carritos ||--o{ Prestamos : utilizado

Notebooks ||--o{ PrestamoDetalle : detalle
Notebooks ||--o{ Devoluciones : devuelta_en
EstadosNotebook ||--o{ Notebooks : tiene

Prestamos ||--o{ PrestamoDetalle : compone
Prestamos ||--o{ Devoluciones : relacionado_con

EstadosPrestamo ||--o{ PrestamoDetalle : indica
EstadosPrestamo ||--o{ Devoluciones : estado_devolucion

```