using BooksWebApp.Contract;
using BooksWebApp.Model;
using BooksWebApp.Repo;
using BooksWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepo _bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        /// <summary>
        /// Get All Books details
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public async Task<List<Books>> Get()
        {
            List<Books> books = new List<Books>();
            try
            {
                //Get All books
                books = await _bookRepo.Get();
            }
            catch (Exception ex)
            {
                books = null;
                throw ex;
            }
           
            return books;
        }

        /// <summary>
        /// Get All Books details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BookWIthPub/{id:guid}")]
        public async Task<List<Books>> GetBookWithPublisher(Guid Id) // Pass id to get specify publisher data "6E8A0D68-C43E-41CE-AAAA-0FCC6B3A94FE" -Book/BookWIthPub/6E8A0D68-C43E-41CE-AAAA-0FCC6B3A94FE
        {
            List<Books> books = new List<Books>();

            try
            {
                //Get specify books

                //SampleData
                //Books books1 = new Books();
                //books1.Publisher = "BookWIthPub";
                //books.Add(books1);

                books = await _bookRepo.GetBookWithPublisher(Id);
            }
            catch (Exception ex)
            {
                books = null;
                throw ex;
            }

            return books;
        }

    }
}
