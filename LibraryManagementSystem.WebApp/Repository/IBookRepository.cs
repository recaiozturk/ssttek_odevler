using LibraryManagementSystem.WebApp.Models;

namespace LibraryManagementSystem.WebApp.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        void Update(Book book);
        public void Delete(int id);
    }
}
