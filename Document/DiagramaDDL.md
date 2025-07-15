### Diagrama de Base de datos

```mermaid
erDiagram
direction LR

Encargados {
    tinyint      idEncargado       PK
    varchar(40)  usuario
    varchar(70)  password
    varchar(40)  nombre
    varchar(40)  apellido
    varchar(70)  email
}

Docentes {
    smallint     idDocente         PK
    int          dni
    varchar(40)  nombre
    varchar(40)  apellido
    varchar(70)  email
}

TipoElemento {
    tinyint      idTipoElemento    PK
    varchar(40)  elemento
}

EstadosElemento {
    tinyint      idEstadoElemento  PK
    varchar(40)  estadoElemento
}

Elementos {
    tinyint      idElemento         PK
    tinyint      idTipoElemento     FK
    tinyint      idCarrito          FK
    tinyint      idEstadoElemento   FK
    boolean      disponible
}

Carritos {
    tinyint      idCarrito          PK
    tinyint      cantidad
    boolean      disponibleCarrito
}

Cursos {
    tinyint      idCurso           PK
    varchar(40)  curso
}

Prestamos {
    int          idPrestamo        PK
    tinyint      idCurso           FK
    smallint     idDocente         FK
    tinyint      idCarrito         FK
    tinyint      idEncargado       FK
    datetime     fechaPrestamo
}

EstadosPrestamo {
    tinyint      idEstadoPrestamo   PK
    varchar(40)  estadoPrestamo
}

PrestamoDetalle {
    int          idPrestamo         PK, FK
    tinyint      idElemento         PK, FK
    tinyint      idEstadoPrestamo   FK
}

Devoluciones {
    int          idDevolucion       PK
    int          idPrestamo         FK
    tinyint      idElemento         FK
    smallint     idDocente          FK
    tinyint      idEstadoPrestamo   FK
    tinyint      idEncargado        FK
    datetime     fechaDevolucion
    varchar(200) observaciones
}

Encargados ||--o{ Prestamos : realiza
Encargados ||--o{ Devoluciones : recibe

Docentes ||--o{ Prestamos : solicita
Docentes ||--o{ Devoluciones : devuelve

Cursos ||--o{ Prestamos : esta_en

TipoElemento ||--o{ Elementos : es_un
EstadosElemento ||--o{ Elementos : esta

Carritos ||--o{ Elementos : contiene
Carritos ||--o{ Prestamos : utilizado

Elementos ||--o{ PrestamoDetalle : prestado
Elementos ||--o{ Devoluciones : devuelto

Prestamos ||--o{ PrestamoDetalle : incluye
Prestamos ||--o{ Devoluciones : devuelve_el_prestamo

EstadosPrestamo ||--o{ PrestamoDetalle : esta
EstadosPrestamo ||--o{ Devoluciones : esta

```