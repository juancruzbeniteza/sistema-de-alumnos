public class Materia : IExportable
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Horas { get; set; }

    public Materia(string codigo, string nombre, int horas)
    {
        Codigo = codigo;
        Nombre = nombre;
        Horas = horas;
    }

    public string ExportarLinea() => $"MATERIA;{Codigo};{Nombre};{Horas}";
}
