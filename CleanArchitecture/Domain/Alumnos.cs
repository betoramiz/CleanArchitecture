namespace CleanArchitecture.Domain;

public class Alumnos
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Matricula { get; private set; }

    public static Alumnos Create(string nombre, string apellidos, string matricula)
    {
        return new Alumnos()
        {
            Nombre = nombre,
            Apellido = apellidos,
            Matricula = matricula
        };
    }
}