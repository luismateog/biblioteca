# Sistema de gestión de biblioteca

## Sobre el proyecto

En esta actividad desarrollé un menú interactivo de consola en C# para simular la gestión de una biblioteca. Puedo navegar por las opciones de libros, usuarios, préstamos, búsquedas y reportes, y guardado y carga de datos. Las opciones muestran un mensaje que describe la acción seleccionada.

El alcance es únicamente el menú y sus mensajes: no se crean objetos de dominio, no se administran registros reales y no se guardan datos en archivos.

## Funcionalidades

- Menú principal con acceso a todos los módulos.
- Submenús para libros, usuarios, préstamos, reportes y persistencia simulada.
- Opciones para volver al menú anterior.
- Validación de opciones numéricas y respuestas S/N.
- Confirmación para reiniciar datos y para guardar antes de salir.
- Funciones estáticas para las acciones; cada función imprime su mensaje descriptivo.

## Requisitos

- .NET SDK 10 o compatible con el proyecto.
- Terminal y editor de C#.

## Cómo ejecutar

Desde la carpeta del proyecto:

```bash
dotnet run --project Biblioteca/Biblioteca.csproj
```

También se puede entrar a `Biblioteca` y ejecutar `dotnet run`.

## Estructura

- `Biblioteca/Program.cs`: menú, navegación, validación y funciones de mensajes.
- `Biblioteca/Biblioteca.csproj`: configuración de la aplicación de consola.

## Git Flow

El flujo propuesto para la actividad parte de `main`, crea `develop` y trabaja cada módulo en una rama `feature/` que luego se integra en `develop`. Al completar el incremento, se integra `develop` en `main`.

Ramas de módulo solicitadas:

- `feature/main-menu-navigation`
- `feature/books-menu`
- `feature/users-menu`
- `feature/loans-menu`
- `feature/search-reports-menu`
- `feature/persistence-menu`
- `feature/exit-flow`

`feature/project-bootstrap` se omite en esta entrega. La estructura inicial ya estaba incluida en `main` antes de iniciar el flujo Git Flow.

Los submenús de libros incluyen registrar, listar por estado, consultar detalle, actualizar por campo y eliminar con su regla sugerida.

Para crear e integrar una rama durante el trabajo:

```bash
git switch develop
git switch -c feature/nombre-del-modulo
git add .
git commit -m "feat: describe el módulo"
git switch develop
git merge --no-ff feature/nombre-del-modulo
```

Al terminar, se puede cerrar el incremento con `git switch main` y `git merge --no-ff develop`. Para compartir la evidencia en GitHub, GitLab o Bitbucket, configura el remoto y publica `main`, `develop` y las ramas `feature/*`.

## Alcance académico

Este ejercicio practica funciones estáticas, estructuras de control, lectura de entradas y navegación por menús. Las reglas de validación de libros, usuarios y préstamos aparecen como mensajes orientativos; no se ejecutan operaciones CRUD ni persistencia real.
