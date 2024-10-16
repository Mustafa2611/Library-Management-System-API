using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;
using RepositoryPattern.EF.Configration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EF.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Book CreateNewObject(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindAll(Expression<Func<Book, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Book FindOne(Expression<Func<Book, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Set<Book>().Include(b => b.Author).ToList();

        }
    }
}
