```mermaid

flowchart TD
    Login[Login] --> Menu[Menu Principal]

    Menu --> Docentes[Docentes]
    Menu --> Elementos[Elementos]
    Menu --> Carritos[Carritos]
    Menu --> Prestamos[Prestamos]
    Menu --> Devoluciones[Devoluciones]
    Menu --> Categorias[Categorias]
    Menu --> Usuarios[Usuarios]
    Menu --> Mantenimiento[Mantenimiento]

    Elementos --> HistorialElemento[Historial Elemento]

    Prestamos --> DetallePrestamoDevolucion[Detalle Préstamo/Devolución]
    Devoluciones --> DetallePrestamoDevolucion

```