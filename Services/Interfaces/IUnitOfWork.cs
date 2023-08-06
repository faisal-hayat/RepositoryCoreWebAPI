namespace DemoAPI.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();
    }
}
