```mermaid
erDiagram

    Docentes {
        smallint      idDocente   PK
        int           dni
        varchar(40)   nombre
        varchar(40)   apellido
        varchar(40)   email
    }

    Alumnos {
        smallint      idAlumno   PK
        int           dni
        varchar(40)   nombre
        varchar(40)   apellido
        varchar(40)   email
        varchar(40)   curso
    }

    PermisosPrestamo {
        smallint   idPermiso    PK
        smallint   idAlumno     FK
        smallint   idDocente    FK
        datetime   fechaPermiso
    }

    Tecnologia {
        tinyint       idTecnologia   PK
        varchar(40)   programa
    }

    EstadosNotebook {
        tinyint       idEstadoNotebook   PK
        varchar(40)   estadoNotebook
    }

    Notebooks {
        tinyint   idNotebook         PK
        tinyint   idTecnologia       FK
        tinyint   idEstadoNotebook   FK 
    }

    Carritos {
        tinyint   idCarrito   PK
        smallint  idDocente   FK
        tinyint   capacidad
    }

    CarritoNotebooks {
        tinyint   idCarrito    PK, FK
        tinyint   idNotebook   PK, FK
    }

    Prestamos {
        int           idPrestamo      PK
        smallint      idPermiso       FK
        smallint      idDocente       FK
        tinyint       idCarrito       FK
        datetime      fechaPrestamo
        datetime      fechaPactada
        varchar(40)   tipoPrestamo
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

    Docentes ||--o{ PermisosPrestamo : da
    Alumnos ||--o{ PermisosPrestamo : recibe
    PermisosPrestamo ||--o{ Prestamos : autoriza
    Docentes ||--o{ Prestamos : realiza_un
    Docentes ||--o| Carritos : lleva_un
    Carritos ||--o{ CarritoNotebooks : contiene
    Notebooks ||--o{ CarritoNotebooks : estan_en
    Tecnologia ||--o{ Notebooks : tiene
    EstadosNotebook ||--o{ Notebooks : esta
    Carritos ||--o{ Prestamos : esta_usado_en
    Prestamos ||--o{ PrestamoDetalle : contiene
    Notebooks ||--o{ PrestamoDetalle : esta_prestado
    EstadoPrestamo ||--o{ PrestamoDetalle : esta_en

´´´