public class Profesor : Persona, IExportable
{
    public string Materia { get; set; }

    public Profesor(string nombre, int documento, string materia) : base(nombre, documento)
    {
        Materia = materia;
    }

    public override string Presentarse() => $"Hola, soy {Nombre} y dicto {Materia}.";

    public string ExportarLinea() => $"PROFESOR;{Nombre};{Materia}";
}
