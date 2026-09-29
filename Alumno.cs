public class Alumno : Persona, IExportable
{
    public int Legajo { get; private set; }
    public decimal Nota1 { get; private set; }
    public decimal Nota2 { get; private set; }

    public Alumno(string nombre, int legajo) : base(nombre, legajo)
    {
        Legajo = legajo;
    }

    public decimal Promedio() => (Nota1 + Nota2) / 2;

    public bool EstaAprobado() => Promedio() >= 6;

    public void SubirNota()
    {
        Nota1 = Math.Min(Nota1 + 1, 10);
        Nota2 = Math.Min(Nota2 + 1, 10);
    }

    public override string ToString()
    {
        return $"{Legajo} - {Nombre} (promedio: {Promedio()})";
    }

    public bool CargarNotas(decimal nota1, decimal nota2)
    {
        if (nota1 < 0 || nota1 > 10 || nota2 < 0 || nota2 > 10)
            return false;
        Nota1 = nota1;
        Nota2 = nota2;
        return true;
    }

    public override string Presentarse() => $"Hola, soy {Nombre}, alumno con legajo {Legajo}.";

    public string ExportarLinea() => $"ALUMNO;{Legajo};{Nombre};{Promedio()}";
}
