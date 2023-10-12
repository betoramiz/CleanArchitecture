using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.UseCase;

namespace CleanArchitecture.Application.AlumnosV2;


public class ObtenerPorNombreUseCase
{
    public class Request : IInputCase
    {
        public string Nombre { get; set; }
    }

    public class Response : IOutputCase
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
    }

    public class UseCase: IUseCase<Request, Response>
    {
        private readonly ApplicationContext _context;
        public UseCase(ApplicationContext context) => _context = context;

        public Response Execute(Request input)
        {
            var alumnos = _context
                .Alumnos
                .Where(alumno => alumno.Nombre == input.Nombre)
                .Select(alumno => new Response()
                {
                    Id = alumno.Id,
                    Matricula = alumno.Matricula
                })
                .FirstOrDefault();

            return alumnos ?? new Response();
        }
    }
}
