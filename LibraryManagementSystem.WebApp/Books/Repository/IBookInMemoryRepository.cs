using LibraryManagementSystem.WebApp.Books.Entities;

namespace LibraryManagementSystem.WebApp.Books.Repository
{
    public interface IBookInMemoryRepository
    {

        List<Book> GetAll();
        List<Book> GetPaginationList(int pageNumber, int pageSize);
        Book GetById(int id);
        Book Add(Book book);
        void Update(Book book);
        public void Delete(int id);
    }
}
