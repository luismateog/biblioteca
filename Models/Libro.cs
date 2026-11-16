namespace Biblioteca.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnioPublicacion { get; set; }
    public string Categoria { get; set; }
    public bool Disponible { get; set; } = true;

    public Libro() : this(0, string.Empty, string.Empty, string.Empty, 0, string.Empty) { }

    public Libro(int id, string titulo, string autor, string isbn, int anioPublicacion, string categoria, bool disponible = true)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnioPublicacion = anioPublicacion;
        Categoria = categoria;
        Disponible = disponible;
    }

    public string ResumenCorto() => $"{Titulo} — {Autor} ({AnioPublicacion})";

    public string DetalleCompleto() =>
        $"ID: {Id}\nTítulo: {Titulo}\nAutor: {Autor}\nISBN: {ISBN}\nAño de publicación: {AnioPublicacion}\nCategoría: {Categoria}\nDisponible: {Disponible}";

    public override string ToString() => ResumenCorto();
}
