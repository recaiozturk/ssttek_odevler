namespace LibraryManagementSystem.WebApp.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
    }
}
