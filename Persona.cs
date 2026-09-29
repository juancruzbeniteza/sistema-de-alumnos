public class Persona
{
    public string Nombre { get; set; }
    public int Documento { get; private set; }

    public Persona(string nombre, int documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    public virtual string Presentarse() => $"Hola, soy {Nombre}.";
}
