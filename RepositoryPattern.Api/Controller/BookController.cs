using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly IBaseRepository<Book> _baseRepository;

        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("")]
        public IActionResult CreateBook(Book book)
        {
            _unitOfWork.Books.CreateNewObject(book);
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_unitOfWork.Book.GetAllBooks());
        }

        [HttpGet("FindAllBooks")]
        public ActionResult<IEnumerable<Book>> FindAllBooks()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book") , new[] { "Author" }));
        }


        [HttpGet("FindOne/{title}")]
        public IActionResult FindBook(string title)
        {
            return Ok(_unitOfWork.Books.FindOne(b => b.Title.Contains(title), new[] { "Author" }));
        }

    }
}
