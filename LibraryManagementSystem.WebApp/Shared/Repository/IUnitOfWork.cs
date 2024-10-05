namespace LibraryManagementSystem.WebApp.Shared.Repository
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
