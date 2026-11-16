namespace Biblioteca.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Documento { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; } = true;

    public Usuario() : this(0, string.Empty, string.Empty, string.Empty, string.Empty) { }

    public Usuario(int id, string nombre, string documento, string correo, string telefono, bool activo = true)
    {
        Id = id;
        Nombre = nombre;
        Documento = documento;
        Correo = correo;
        Telefono = telefono;
        Activo = activo;
    }

    public string ResumenCorto() => $"{Nombre} — documento {Documento}";

    public string DetalleCompleto() =>
        $"ID: {Id}\nNombre: {Nombre}\nDocumento: {Documento}\nCorreo: {Correo}\nTeléfono: {Telefono}\nActivo: {Activo}";

    public override string ToString() => ResumenCorto();
}
