using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.UseCase;

namespace CleanArchitecture.Application.AlumnosV2;


public class Create
{
    public class Request: IInputCase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Matricula { get; set; }
    }

    public class Response: IOutputCase
    {
        public int IdCreated { get; set; }
    }

    public class UseCase: IUseCase<Request, Response>
    {
        private readonly ApplicationContext _applicationContext;
        public UseCase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        
        public Response Execute(Request input)
        {
            var alumnoNuevo = Domain.Alumnos.Create(input.Nombre, input.Apellido, input.Matricula);

            _applicationContext.Alumnos.Add(alumnoNuevo);
            _applicationContext.SaveChanges();

            return new Response() { IdCreated = alumnoNuevo.Id };
        }
    }
}
