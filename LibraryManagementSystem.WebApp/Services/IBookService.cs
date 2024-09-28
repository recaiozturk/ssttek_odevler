﻿using LibraryManagementSystem.WebApp.Models.ViewModels;

namespace LibraryManagementSystem.WebApp.Services
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();
        BookListModel PrepareListPage(int pageNumber, int pageSize);
        BookViewModel? GetById(int id);
        BookViewModel Add(CreateBookViewModel bookModel);
        void Update(UpdateBookViewModel bookModel);
        void Delete(int id);
    }
}
