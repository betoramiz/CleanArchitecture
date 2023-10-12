using Clean.Domain;
using MediatR;
using ErrorOr;

namespace Clean.Application.Course;

public class Create
{
    public record Command(int Id) : IRequest<ErrorOr<Response>>;

    public record Response(int Id);

    public class CommandHandler : IRequestHandler<Command, ErrorOr<Response>>
    {
        private readonly CleanArchContext _context;
        public CommandHandler(CleanArchContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}