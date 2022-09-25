using Core.Models;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class, new()
    {
        BaseResponse<T> Get(Expression<Func<T, bool>> filter = null);
        BaseResponse<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        BaseResponse<int> Add(T entity);
        BaseResponse<int> Update(T entity);
        BaseResponse<int> Delete(T entity);
        Task<BaseResponse<T>> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);//yeni eklendi 06.04.2022 StatTark icludes
        Task<BaseResponse<List<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<BaseResponse<List<T>>> GetAllAsyncWithInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<T>> AddAsync(T entity);
        Task<BaseResponse<T>> UpdateAsync(T entity);
    }
}
