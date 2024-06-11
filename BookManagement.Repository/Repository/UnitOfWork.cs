using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IBookRepository _bookRepository;

        public UnitOfWork(BookStoreContext bookStoreContext,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            IDiscountRepository discountRepository,
            IBookRepository bookRepository)
        {
            _bookStoreContext = bookStoreContext;
            _orderDetailRepository = orderDetailRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _discountRepository = discountRepository;
            _bookRepository = bookRepository;
        }

        public IUserRepository UserRepo => _userRepository;

        public IBookRepository BookRepo => _bookRepository;

        public IOrderDetailRepository OrderDetailRepo => _orderDetailRepository;

        public IOrderRepository OrderRepo => _orderRepository;

        public ICategoryRepository CategoryRepo => _categoryRepository;

        public IDiscountRepository DiscountRepo => _discountRepository;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _bookStoreContext.SaveChangesAsync();
        }
    }
}
