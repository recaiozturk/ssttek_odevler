namespace LibraryManagementSystem.Repository.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
