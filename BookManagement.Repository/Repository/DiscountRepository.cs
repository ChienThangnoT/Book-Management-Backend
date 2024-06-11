using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository.Repository
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
