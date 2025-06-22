```mermaid
erDiagram

    Docentes {
        smallint      idDocente   PK
        int           dni
        varchar(40)   nombre
        varchar(40)   apellido
        varchar(40)   email
    }

    EstadosNotebook {
        tinyint       idEstadoNotebook   PK
        varchar(40)   estadoNotebook
    }

    Notebooks {
        tinyint   idNotebook         PK
        tinyint   idEstadoNotebook   FK
        boolean disponibleNotebook

    }

    Carritos {
        tinyint   idCarrito   PK
        smallint  idDocente   FK
        boolean   disponibleCarrito
    }

    CarritoNotebooks {
        tinyint   idCarrito    PK, FK
        tinyint   idNotebook   PK, FK
    }

    Prestamos {
        int           idPrestamo      PK
        smallint      idDocente       FK
        tinyint       idCarrito       FK
        datetime      fechaPrestamo
        datetime      fechaPactada
    }

    EstadoPrestamo {
        tinyint       idEstadoPrestamo   PK
        varchar(40)   estadoPrestamo
    }

    PrestamoDetalle {
        int         idPrestamo         PK, FK
        tinyint     idNotebook         PK, FK
        tinyint     idEstadoPrestamo   FK
        datetime    fechaDevolucion
    }

    Docentes ||--o{ Prestamos : realiza_un
    Docentes ||--o| Carritos : lleva_un
    Carritos ||--o{ CarritoNotebooks : contiene
    Notebooks ||--o{ CarritoNotebooks : estan_en
    EstadosNotebook ||--o{ Notebooks : esta
    Carritos ||--o{ Prestamos : esta_usado_en
    Prestamos ||--o{ PrestamoDetalle : contiene
    Notebooks ||--o{ PrestamoDetalle : esta_prestado
    EstadoPrestamo ||--o{ PrestamoDetalle : esta_en

´´´
