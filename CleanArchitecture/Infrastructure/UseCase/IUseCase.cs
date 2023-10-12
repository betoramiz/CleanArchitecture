namespace CleanArchitecture.Infrastructure.UseCase;

public interface IUseCase<IInputCase, IOutputCase>
{
    public IOutputCase Execute(IInputCase input);
}