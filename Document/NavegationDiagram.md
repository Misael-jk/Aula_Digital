```mermaid

graph TD
    Login(Login)
    Menu(Menu Principal)
    GestionDocentes(Gestion de Docentes)
    GestionAlumnos(Gestion de Alumnos)
    Prestamos(Gestion de Prestamos)
    DetallePrestamo(Detalle del Prestamo)
    Carritos(Gestion de Carritos)
    Notebooks(Gestion de Notebooks)

    Login --> Menu
    Menu --> GestionDocentes
    Menu --> GestionAlumnos
    Menu --> Prestamos
    Prestamos --> DetallePrestamo
    Menu --> Carritos
    Menu --> Notebooks


```