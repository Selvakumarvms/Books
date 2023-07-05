using BooksWebApp.Contract;
using BooksWebApp.Model;
using BooksWebApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly IDapper _dapper;
        public BookRepo(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<Books>> Get()
        {
            List<Books> books = new List<Books>();
            try
            {
                books = await Task.FromResult(_dapper.Get<List<Books>>($"Select Id,Publisher,Title,AuthorFirstName,AuthorLastName from dbo.Books", null, commandType: CommandType.Text));
            }
            catch(Exception ex)
            {
                books = null;
                throw ex;
            }

            return books;
        }

        public async Task<List<Books>> GetBookWithPublisher(Guid Id)
        {
            List<Books> books = new List<Books>();
            try
            {
                books = await Task.FromResult(_dapper.Get<List<Books>>($"Select * from [Books] where Id = '{Id}'", null, commandType: CommandType.Text));
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
