﻿using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books/")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBoks(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            var books = _manager
        .BookService
        .GetOneBokById(id, false);

            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreatOneBook([FromBody] Book book)
        {

            if (book is null)
                return BadRequest(); //400

            _manager.BookService.CreateOneBook(book);

            return StatusCode(201, book);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
           [FromBody] Book book)
        {
            if (book is null)
                return BadRequest(); //400

            _manager.BookService.UpdateOneBook(id, book, true);

            return NoContent(); //204

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAllBooks([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id, false);

            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
           [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check entity
            var entity = _manager
                .BookService
                .GetOneBokById(id, true);

            bookPatch.ApplyTo(entity);
            _manager.BookService.UpdateOneBook(id, entity, true);

            return NoContent();//204
        }
    }

}
