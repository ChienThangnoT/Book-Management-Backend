﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository.IRepository;
using System.Linq.Expressions;
using BookManagement.Service.Common;

namespace BookManagement.Repository.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        protected DbSet<TModel> _dbSet;
        //private readonly IClaimsService _claimsService;

        public GenericRepository(BookStoreContext context/*,  IClaimsService claimsService*/)
        {
            _dbSet = context.Set<TModel>();
            //_claimsService = claimsService;
        }

        public virtual async Task AddAsync(TModel model)
        {
            await _dbSet.AddAsync(model);
        }

        public virtual void AddAttach(TModel model)
        {
            _dbSet.Attach(model).State = EntityState.Added;
        }

        public virtual void AddEntry(TModel model)
        {
            _dbSet.Entry(model).State = EntityState.Added;
        }

        public virtual async Task AddRangeAsync(List<TModel> models)
        {
            await _dbSet.AddRangeAsync(models);
        }

        public virtual async Task<List<TModel>> GetAllAsync() => await _dbSet.ToListAsync();

        /// <summary>
        /// The function return list of Tmodel with an include method.
        /// Example for user we want to include the relation Role: 
        /// + GetAllAsync(user => user.Include(x => x.Role));
        /// </summary>
        /// <param name="include"> The linq expression for include relations we want. </param>
        /// <returns> Return the list of TModel include relations. </returns>
        public virtual async Task<List<TModel>> GetAllAsync(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null)
        {
            IQueryable<TModel> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public virtual async Task<TModel?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public void Update(TModel? model)
        {
            _dbSet.Update(model);
        }

        public void UpdateRange(List<TModel> models)
        {
            _dbSet.UpdateRange(models);
        }

        public void Remove(TModel model)
        {
            _dbSet.Remove(model);
        }

        // Implement to pagination method
        public async Task<Pagination<TModel>> ToPaginationAsync(int pageIndex = 0, int pageSize = 10)
        {
            // get total count of items in the db set
            var itemCount = await _dbSet.CountAsync();

            // Create Pagination instance
            // to set data related to paging
            // Calculate and replace pageIndex and pageSize
            // if they are invalid
            var result = new Pagination<TModel>()
            {
                PageSize = pageSize,
                TotalItemCount = itemCount,
                PageIndex = pageIndex,
            };

            // Take items according to the page size and page index
            // skip items in the previous pages
            // and take next items equal to page size
            var items = await _dbSet.Skip(result.PageIndex * result.PageSize)
                .Take(result.PageSize)
                .AsNoTracking()
                .ToListAsync();

            // Assign items to page
            result.Items = items;

            return result;
        }

        public async Task<Pagination<TModel>> ToListPaginationAsync(IQueryable<TModel> query, int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await query.CountAsync();
            var result = new Pagination<TModel>()
            {
                PageSize = pageSize,
                TotalItemCount = itemCount,
                PageIndex = pageIndex,
            };
            var items = await query.Skip(result.PageIndex * result.PageSize)
                                   .Take(result.PageSize)
                                   .AsNoTracking()
                                   .ToListAsync();

            result.Items = items;

            return result;
        }

        public async Task<Pagination<TModel>> ToPaginationIncludeAsync(int pageIndex = 0, int pageSize = 10, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null)
        {
            IQueryable<TModel> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            var itemCount = await query.CountAsync();

            var result = new Pagination<TModel>
            {
                PageSize = pageSize,
                TotalItemCount = itemCount,
                PageIndex = pageIndex
            };

            var items = await query
                .Skip(result.PageIndex * result.PageSize)
                .Take(result.PageSize)
                .AsNoTracking()
                .ToListAsync();

            result.Items = items;

            return result;
        }

        public async Task<Pagination<TModel>> ToPaginationAsync(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null, // Optional parameter for pagination (page number)
            int? pageSize = null)  // Optional parameter for pagination (number of records per page)
        {
            IQueryable<TModel> query = _dbSet;

            var itemCount = await CountAsync();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Implementing pagination
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                // Ensure the pageIndex and pageSize are valid
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            //return await query.ToListAsync();

            var result = new Pagination<TModel>()
            {
                PageSize = (int)pageSize,
                TotalItemCount = itemCount,
                PageIndex = (int)pageIndex,
            };

            var items = await query.Skip(result.PageIndex * result.PageSize)
                .Take(result.PageSize)
                .AsNoTracking()
                .ToListAsync();

            result.Items = items;

            return result;
        }

        public async Task<int> CountAsync(Expression<Func<TModel, bool>> filter = null)
        {
            IQueryable<TModel> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }
    }
}
