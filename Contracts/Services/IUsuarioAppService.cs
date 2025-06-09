namespace Raizes.Contracts.Services
{
    public interface IUsuarioAppService
    {
        Task Create();

        Task Read();

        Task Update();

        Task Delete();
    }
}
