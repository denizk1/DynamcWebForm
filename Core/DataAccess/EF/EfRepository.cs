using Core.Models;
using Core.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EF
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
           where TEntity : class, new()
           where TContext : DbContext, new()
    {
        public BaseResponse<int> Add(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var add = context.Entry(entity);
                    add.State = EntityState.Added;
                    int result = context.SaveChanges();
                    return new BaseResponse<int>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<int>(false, 0, e.Message);
            }

        }

        public async Task<BaseResponse<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var add = context.Entry(entity);
                    add.State = EntityState.Added;
                    await context.SaveChangesAsync();

                    return new BaseResponse<TEntity>(true, entity, "");
                }

            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>(false, null, e.Message);
            }

        }

        public BaseResponse<int> Delete(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var delete = context.Entry(entity);
                    delete.State = EntityState.Deleted;
                    int result = context.SaveChanges();
                    return new BaseResponse<int>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<int>(false, 0, e.Message);
            }

        }

        public BaseResponse<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    var result = context.Set<TEntity>().FirstOrDefault(filter);

                    return new BaseResponse<TEntity>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>(false, null, e.Message);
            }

        }

        public BaseResponse<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    var result = filter == null ?
                        context.Set<TEntity>().ToList() :
                        context.Set<TEntity>().Where(filter).ToList();

                    return new BaseResponse<List<TEntity>>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<List<TEntity>>(false, null, e.Message);
            }

        }

        public async Task<BaseResponse<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    var result = filter == null ?
                       await context.Set<TEntity>().ToListAsync() :
                       await context.Set<TEntity>().Where(filter).ToListAsync();

                    return new BaseResponse<List<TEntity>>(true, result, "");
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<TEntity>>(false, null, e.Message);
            }

        }
        public async Task<BaseResponse<List<TEntity>>> GetAllAsyncWithInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                using (var context = new TContext())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();

                    foreach (Expression<Func<TEntity, object>> include in includes)
                    {
                        query = query.Include(include);
                    }

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    var result = await query.AsNoTracking().ToListAsync();


                    return new BaseResponse<List<TEntity>>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<List<TEntity>>(false, null, e.Message);
            }
        }

        public async Task<BaseResponse<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                using (var context = new TContext())
                {
                    //var result = await context.Set<TEntity>().SingleOrDefaultAsync(filter);

                    //if (result == null)
                    //{
                    //    return new BaseResponse<TEntity>(false, null, "Kayıt Bulunamadı");
                    //}

                    //return new BaseResponse<TEntity>(true, result, "");
                    IQueryable<TEntity> query = context.Set<TEntity>();

                    if (includes.Length > 0)
                    {
                        foreach (var item in includes)
                        {
                            query = query.Include(item);
                        }
                    }

                    var result = await query.FirstOrDefaultAsync(filter);

                    if (result == null)
                    {
                        return new BaseResponse<TEntity>(false, null, "Kayıt Bulunamadı");
                    }
                    return new BaseResponse<TEntity>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>(false, null, e.Message);
            }

        }

        public BaseResponse<int> Update(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var update = context.Entry(entity);
                    update.State = EntityState.Modified;
                    int result = context.SaveChanges();
                    return new BaseResponse<int>(true, result, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<int>(false, 0, e.Message);
            }

        }

        public async Task<BaseResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var update = context.Entry(entity);
                    update.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return new BaseResponse<TEntity>(true, entity, "");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>(false, null, e.Message);
            }

        }
    }
}
