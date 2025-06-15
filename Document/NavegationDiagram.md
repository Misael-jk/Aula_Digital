```mermaid

graph TD
    Login[Login]
    Menu[Menú Principal]
    GestionDocentes[Gestión de Docentes]
    GestionAlumnos[Gestión de Alumnos]
    Prestamos[Gestión de Préstamos]
    DetallePrestamo[Detalle del Préstamo]
    Carritos[Gestión de Carritos]
    Notebooks[Gestión de Notebooks]

    Login --> Menu
    Menu --> GestionDocentes
    Menu --> GestionAlumnos
    Menu --> Prestamos
    Prestamos --> DetallePrestamo
    Menu --> Carritos
    Menu --> Notebooks

```