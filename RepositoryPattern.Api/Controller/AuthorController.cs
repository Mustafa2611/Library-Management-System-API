using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;
using RepositoryPattern.EF;

namespace RepositoryPattern.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _baseRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateAuthor(Author author) {
            _unitOfWork.Authors.CreateNewObject(author);
            _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetbyId(int id) {
            return Ok(_unitOfWork.Authors.Get(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }

    }
}
