using RepositoryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Author> Authors { get; }
        public IBaseRepository<Book> Books{ get; }
        public IBookRepository Book {  get; }
        int Complete();
    }
}
