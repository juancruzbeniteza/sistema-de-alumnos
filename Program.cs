using System;
using System.Collections.Generic;
using System.Linq;

List<Alumno> alumnos = new List<Alumno>();
Alumno ana = new Alumno("Ana Pérez", 1234);
ana.CargarNotas(8, 6);
alumnos.Add(ana);
Alumno luis = new Alumno("Luis Gómez", 5678);
luis.CargarNotas(4, 6);
alumnos.Add(luis);

Profesor profesor = new Profesor("Marta Díaz", 246810, "Programación");
Preceptor preceptor = new Preceptor("Carlos Ruiz", 135791);
List<Materia> materias = new List<Materia>
{
    new Materia("PROG1", "Programación I", 128),
    new Materia("BD1", "Bases de Datos I", 96)
};

bool salir = false;
while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("1. Agregar alumno");
    Console.WriteLine("2. Listar alumnos");
    Console.WriteLine("3. Buscar por legajo");
    Console.WriteLine("4. Promedio general");
    Console.WriteLine("5. Cantidad de aprobados");
    Console.WriteLine("6. Presentaciones");
    Console.WriteLine("7. Exportar datos");
    Console.WriteLine("8. Salir");
    Console.Write("Opción: ");
    string? opcion = Console.ReadLine();

    if (opcion == null)
        break;

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Legajo: ");
            bool legajoValido = int.TryParse(Console.ReadLine(), out int legajo);
            Console.Write("Nota 1: ");
            bool nota1Valida = decimal.TryParse(Console.ReadLine(), out decimal nota1);
            Console.Write("Nota 2: ");
            bool nota2Valida = decimal.TryParse(Console.ReadLine(), out decimal nota2);

            if (string.IsNullOrWhiteSpace(nombre) || !legajoValido || legajo <= 0 ||
                !nota1Valida || !nota2Valida)
            {
                Console.WriteLine("Datos inválidos.");
                break;
            }

            if (alumnos.Any(alumno => alumno.Legajo == legajo))
            {
                Console.WriteLine("Ya existe un alumno con ese legajo.");
                break;
            }

            Alumno nuevo = new Alumno(nombre, legajo);
            if (!nuevo.CargarNotas(nota1, nota2))
            {
                Console.WriteLine("Las notas deben estar entre 0 y 10.");
                break;
            }

            alumnos.Add(nuevo);
            Console.WriteLine("Alumno agregado.");
            break;

        case "2":
            if (alumnos.Count == 0)
                Console.WriteLine("No hay alumnos cargados.");
            else
                foreach (Alumno alumno in alumnos)
                    Console.WriteLine(alumno);
            break;

        case "3":
            Console.Write("Legajo: ");
            if (!int.TryParse(Console.ReadLine(), out int legajoBuscado))
            {
                Console.WriteLine("Legajo inválido.");
                break;
            }

            Alumno? encontrado = alumnos.FirstOrDefault(alumno => alumno.Legajo == legajoBuscado);
            Console.WriteLine(encontrado == null ? "No existe ese alumno." : encontrado.ToString());
            break;

        case "4":
            if (alumnos.Count == 0)
                Console.WriteLine("No hay alumnos para calcular el promedio.");
            else
                Console.WriteLine($"Promedio general: {alumnos.Average(alumno => alumno.Promedio()):0.##}");
            break;

        case "5":
            Console.WriteLine($"Alumnos aprobados: {alumnos.Count(alumno => alumno.EstaAprobado())}");
            break;

        case "6":
            List<Persona> personas = new List<Persona>();
            personas.AddRange(alumnos);
            personas.Add(profesor);
            personas.Add(preceptor);
            foreach (Persona persona in personas)
                Console.WriteLine(persona.Presentarse());
            break;

        case "7":
            List<IExportable> exportables = new List<IExportable>();
            exportables.AddRange(alumnos);
            exportables.Add(profesor);
            exportables.AddRange(materias);
            foreach (IExportable exportable in exportables)
                Console.WriteLine(exportable.ExportarLinea());
            break;

        case "8":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}
