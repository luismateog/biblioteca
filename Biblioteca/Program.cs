using System;

internal static class Program
{
    private static void Main()
    {
        ShowMainMenu();
    }

    private static void ShowMainMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE BIBLIOTECA ===");
            Console.WriteLine("1. Libros\n2. Usuarios\n3. Préstamos\n4. Búsquedas y reportes\n5. Guardar / Cargar datos\n6. Salir");
            switch (ReadOption("Seleccione una opción", 1, 6))
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowPersistenceMenu(); break;
                case 6: salir = ConfirmExitAndSave(); break;
            }
        }
        Console.WriteLine("Gracias por utilizar el sistema. Hasta pronto.");
    }

    private static int ReadOption(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write($"{prompt} ({min}-{max}): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input?.Trim(), out int option) && option >= min && option <= max) return option;
            Console.WriteLine("Entrada no válida. Intente nuevamente.");
        }
    }

    private static bool Confirm(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (S/N): ");
            string answer = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
            if (answer == "S") return true;
            if (answer == "N") return false;
            Console.WriteLine("Respuesta no válida. Escriba S o N.");
        }
    }

    private static void WaitForUser() { Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey(true); }

    private static void ShowBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear(); Console.WriteLine("=== LIBROS ===\n1. Registrar libro\n2. Listar libros\n3. Ver detalle (ID/ISBN)\n4. Actualizar libro\n5. Eliminar libro\n0. Volver");
            switch (ReadOption("Seleccione una opción", 0, 5))
            {
                case 1: RegisterBook(); break;
                case 2: ListBooksMenu(); break;
                case 3: ViewBookDetail(); break;
                case 4: UpdateBookMenu(); break;
                case 5: DeleteBook(); break;
                case 0: volver = true; continue;
            }
            WaitForUser();
        }
    }

    private static void ListBooksMenu()
    {
        Console.Clear(); Console.WriteLine("=== LISTAR LIBROS ===\n1. Listar todos\n2. Listar disponibles\n3. Listar prestados\n0. Volver");
        switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: ListBooksAll(); break; case 2: ListBooksAvailable(); break; case 3: ListBooksBorrowed(); break; }
    }

    private static void UpdateBookMenu()
    {
        Console.Clear(); Console.WriteLine("=== ACTUALIZAR LIBRO ===\n1. Editar título\n2. Editar autor\n3. Editar año / categoría\n0. Volver");
        switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: EditBookTitle(); break; case 2: EditBookAuthor(); break; case 3: EditBookYearCategory(); break; }
    }

    private static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear(); Console.WriteLine("=== USUARIOS ===\n1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle (ID/documento)\n4. Actualizar usuario\n5. Eliminar usuario\n0. Volver");
            switch (ReadOption("Seleccione una opción", 0, 5))
            {
                case 1: RegisterUser(); break; case 2: ListUsers(); break; case 3: ViewUserDetail(); break; case 4: UpdateUserMenu(); break; case 5: DeleteUser(); break; case 0: volver = true; continue;
            }
            WaitForUser();
        }
    }

    private static void UpdateUserMenu()
    {
        Console.Clear(); Console.WriteLine("=== ACTUALIZAR USUARIO ===\n1. Editar nombre\n2. Editar contacto\n3. Activar / desactivar\n0. Volver");
        switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: EditUserName(); break; case 2: EditUserContact(); break; case 3: ToggleUserActiveStatus(); break; }
    }

    private static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear(); Console.WriteLine("=== PRÉSTAMOS ===\n1. Crear préstamo\n2. Listar préstamos\n3. Ver detalle (ID)\n4. Registrar devolución\n5. Eliminar préstamo\n0. Volver");
            switch (ReadOption("Seleccione una opción", 0, 5))
            {
                case 1: CreateLoan(); break; case 2: ListLoansMenu(); break; case 3: ViewLoanDetail(); break; case 4: RegisterReturn(); break; case 5: DeleteLoan(); break; case 0: volver = true; continue;
            }
            WaitForUser();
        }
    }

    private static void ListLoansMenu()
    {
        Console.Clear(); Console.WriteLine("=== LISTAR PRÉSTAMOS ===\n1. Todos\n2. Activos\n3. Cerrados (devueltos)\n0. Volver");
        switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: ListLoansAll(); break; case 2: ListLoansActive(); break; case 3: ListLoansClosed(); break; }
        WaitForUser();
    }

    private static void ShowSearchReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear(); Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===\n1. Buscar libro\n2. Buscar usuario\n3. Reportes\n0. Volver");
            switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: SearchBook(); break; case 2: SearchUser(); break; case 3: ReportsMenu(); break; case 0: volver = true; continue; }
            WaitForUser();
        }
    }

    private static void ReportsMenu()
    {
        Console.Clear(); Console.WriteLine("=== REPORTES ===\n1. Préstamos por usuario\n2. Préstamos por libro\n3. Préstamos vencidos\n4. Resumen general\n0. Volver");
        switch (ReadOption("Seleccione una opción", 0, 4)) { case 1: ReportByUser(); break; case 2: ReportByBook(); break; case 3: ReportOverdue(); break; case 4: ReportSummary(); break; }
        WaitForUser();
    }

    private static void ShowPersistenceMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear(); Console.WriteLine("=== GUARDAR / CARGAR DATOS ===\n1. Guardar datos\n2. Cargar datos\n3. Reiniciar datos\n0. Volver");
            switch (ReadOption("Seleccione una opción", 0, 3)) { case 1: SaveData(); break; case 2: LoadData(); break; case 3: ResetData(); break; case 0: volver = true; continue; }
            WaitForUser();
        }
    }

    private static bool ConfirmExitAndSave()
    {
        if (Confirm("¿Guardar antes de salir?")) SaveData();
        return Confirm("¿Confirma que desea salir?");
    }

    private static void RegisterBook() => Console.WriteLine("Acción seleccionada: registrar un libro.");
    private static void ListBooksAll() => Console.WriteLine("Acción seleccionada: listar todos los libros.");
    private static void ListBooksAvailable() => Console.WriteLine("Acción seleccionada: listar libros disponibles.");
    private static void ListBooksBorrowed() => Console.WriteLine("Acción seleccionada: listar libros prestados.");
    private static void ViewBookDetail() => Console.WriteLine("Acción seleccionada: consultar detalle de un libro por ID o ISBN.");
    private static void EditBookTitle() => Console.WriteLine("Acción seleccionada: editar el título del libro.");
    private static void EditBookAuthor() => Console.WriteLine("Acción seleccionada: editar el autor del libro.");
    private static void EditBookYearCategory() => Console.WriteLine("Acción seleccionada: editar el año y la categoría del libro.");
    private static void DeleteBook() => Console.WriteLine("Acción seleccionada: eliminar libro. Validar no permitir si está prestado.");
    private static void RegisterUser() => Console.WriteLine("Acción seleccionada: registrar un usuario.");
    private static void ListUsers() => Console.WriteLine("Acción seleccionada: listar usuarios.");
    private static void ViewUserDetail() => Console.WriteLine("Acción seleccionada: consultar detalle de usuario por ID o documento.");
    private static void EditUserName() => Console.WriteLine("Acción seleccionada: editar el nombre del usuario.");
    private static void EditUserContact() => Console.WriteLine("Acción seleccionada: editar el contacto del usuario.");
    private static void ToggleUserActiveStatus() => Console.WriteLine("Acción seleccionada: activar o desactivar usuario.");
    private static void DeleteUser() => Console.WriteLine("Acción seleccionada: eliminar usuario. Validar no permitir si tiene préstamos activos.");
    private static void CreateLoan() => Console.WriteLine("Acción seleccionada: crear préstamo. Validar que el usuario exista y esté activo, que el libro exista y esté disponible, y opcionalmente el máximo de préstamos activos.");
    private static void ListLoansAll() => Console.WriteLine("Acción seleccionada: listar todos los préstamos.");
    private static void ListLoansActive() => Console.WriteLine("Acción seleccionada: listar préstamos activos.");
    private static void ListLoansClosed() => Console.WriteLine("Acción seleccionada: listar préstamos cerrados o devueltos.");
    private static void ViewLoanDetail() => Console.WriteLine("Acción seleccionada: consultar detalle de préstamo por ID.");
    private static void RegisterReturn() => Console.WriteLine("Acción seleccionada: registrar devolución, marcar el préstamo como devuelto y el libro como disponible.");
    private static void DeleteLoan() => Console.WriteLine("Acción seleccionada: eliminar préstamo. Se recomienda permitirlo solo si está cerrado o fue creado por error; si está activo, devolver el libro automáticamente.");
    private static void SearchBook() => Console.WriteLine("Acción seleccionada: buscar libro por título, autor, ID/ISBN o categoría.");
    private static void SearchUser() => Console.WriteLine("Acción seleccionada: buscar usuario por nombre o ID/documento.");
    private static void ReportByUser() => Console.WriteLine("Acción seleccionada: generar reporte de préstamos por usuario.");
    private static void ReportByBook() => Console.WriteLine("Acción seleccionada: generar reporte de préstamos por libro.");
    private static void ReportOverdue() => Console.WriteLine("Acción seleccionada: generar reporte de préstamos vencidos.");
    private static void ReportSummary() => Console.WriteLine("Acción seleccionada: mostrar resumen de libros totales, disponibles y prestados.");
    private static void SaveData() => Console.WriteLine("Acción seleccionada: guardar datos (simulación; no se escribe en archivos).");
    private static void LoadData() => Console.WriteLine("Acción seleccionada: cargar datos (simulación; no se leen archivos).");
    private static void ResetData()
    {
        if (Confirm("¿Confirma que desea reiniciar los datos?")) Console.WriteLine("Acción seleccionada: reiniciar datos (simulación).");
        else Console.WriteLine("Reinicio cancelado.");
    }
}
