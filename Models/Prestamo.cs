namespace Biblioteca.Models;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

    public Prestamo() : this(0, new Libro(), new Usuario(), DateTime.Today, DateTime.Today, null, EstadoPrestamo.Activo) { }

    public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo,
        DateTime fechaVencimiento, DateTime? fechaDevolucion = null,
        EstadoPrestamo estado = EstadoPrestamo.Activo)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaVencimiento;
        FechaDevolucion = fechaDevolucion;
        Estado = estado;
    }

    public bool EstaVencido() =>
        FechaDevolucion is null && Estado == EstadoPrestamo.Activo && DateTime.Today > FechaVencimiento.Date;

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;
        return Math.Max(0, (fechaFinal - FechaPrestamo).Days);
    }

    public string ResumenCorto() =>
        $"Préstamo {Id}: {Libro.Titulo} para {Usuario.Nombre} — {Estado}";

    public string DetalleCompleto() =>
        $"ID: {Id}\nLibro: {Libro.Titulo}\nUsuario: {Usuario.Nombre}\n" +
        $"Fecha de préstamo: {FechaPrestamo:yyyy-MM-dd}\nFecha de vencimiento: {FechaVencimiento:yyyy-MM-dd}\n" +
        $"Fecha de devolución: {(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("yyyy-MM-dd") : "Pendiente")}\n" +
        $"Estado: {Estado}\nVencido: {EstaVencido()}\nDías transcurridos: {DiasTranscurridos()}";

    public override string ToString() => ResumenCorto();
}
