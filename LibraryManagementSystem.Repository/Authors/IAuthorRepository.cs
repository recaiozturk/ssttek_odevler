using LibraryManagementSystem.Repository.Shared;

namespace LibraryManagementSystem.Repository.Authors
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetAuthorWithBooksAsync(int id);
    }
}
