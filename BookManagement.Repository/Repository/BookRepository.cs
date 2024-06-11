using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
