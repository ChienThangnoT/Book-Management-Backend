using AutoMapper.Execution;
using BookManagement.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepo { get; }
        public IBookRepository BookRepo { get; }
        public IOrderDetailRepository OrderDetailRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public ICategoryRepository CategoryRepo { get; }
        public IDiscountRepository DiscountRepo { get; }
        public Task<int> SaveChangesAsync();
    }
}
