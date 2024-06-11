using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
