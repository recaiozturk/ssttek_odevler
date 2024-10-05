﻿using LibraryManagementSystem.WebApp.Books.Entities;
using LibraryManagementSystem.WebApp.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.WebApp.Books.Repository
{
    public class BookRepository(AppDbContext context) : GenericRepository<Book>(context), IBookRepository
    {
        public async Task<List<Book>> GetPaginationListAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;

            return await context.Books.Include(b => b.Author).Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<Book?> GetBookWithAuthorAsync(int id)
        {
            var bookWithAuthor = context.Books.Include(b => b.Author).FirstOrDefault(x => x.Id == id);

            return bookWithAuthor;
        }
    }
}
