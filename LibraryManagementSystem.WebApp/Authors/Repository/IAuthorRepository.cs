using LibraryManagementSystem.WebApp.Authors.Entities;
using LibraryManagementSystem.WebApp.Shared.Repository;

namespace LibraryManagementSystem.WebApp.Authors.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetAuthorWithBooksAsync(int id);
    }
}
