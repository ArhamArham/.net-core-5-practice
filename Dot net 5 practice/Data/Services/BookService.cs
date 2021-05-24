using System;
using System.Collections.Generic;
using System.Linq;
using Dot_net_5_practice.Data.Models;
using Dot_net_5_practice.Data.ViewModels;

namespace Dot_net_5_practice.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> Index() => _context.Books.ToList();

        public Book Show(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book Update(int id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void Delete(int id)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}