using Common.Utilities.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LinqKit;
using System.Reflection;
using System.Data;

namespace Common.Utilities.Implements.Repository
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        #region Private Fields

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWorkAsync _unitOfWork;
        #endregion Private Fields

        public Repository(DbContext context, IUnitOfWorkAsync unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            if (_context != null)
            {
                _dbSet = _context.Set<TEntity>();
            }
        }

        public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = ApplyDefaultFilters(_dbSet);
            return query.FirstOrDefault(predicate);
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = ApplyDefaultFilters(_dbSet);
            return query.FirstOrDefaultAsync(predicate);
        }

        public TEntity Find<TKey>(Expression<Func<TEntity, TKey>> sortExpression, bool isDesc, Expression<Func<TEntity, bool>> predicate) => isDesc ? _dbSet.OrderBy(sortExpression).FirstOrDefault(predicate) : _dbSet.OrderByDescending(sortExpression).FirstOrDefault(predicate);

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters) => _dbSet.FromSqlRaw(query, parameters).AsQueryable();

        public virtual IQueryable<TEntity> SelectQueryInterpolated(FormattableString query, params object[] parameters) => _dbSet.FromSqlRaw(query.ToString()).AsQueryable();

        public virtual int ExecuteSqlCommand(FormattableString query, params object[] parameters)
        {
            return _context.Database.ExecuteSqlInterpolated(query);
        }

        public IQueryable<I> ExecuteSqlCommand<I>(string query, params object[] parameters) where I : class
        {
            return _context.Set<I>().FromSqlRaw(query, parameters).AsQueryable();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            var entityDb = await _dbSet.AddAsync(entity);
            _unitOfWork.SyncObjectState(entity);
            return entityDb.Entity;
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _dbSet.Add(entity);
            _unitOfWork.SyncObjectState(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.SyncObjectState(entity);
            return Task.FromResult(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.SyncObjectState(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            _context.RemoveRange(_dbSet.Where(predicate));
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _unitOfWork.SyncObjectState(entity);
        }

        public virtual IQueryable<TEntity> GetAll(bool withoutDefaultFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            var query2 = ApplyDefaultFilters(_dbSet);
            return query2;
        }

        public virtual DbSet<TEntity> Get() => _dbSet;

        public IQueryFluent<TEntity> Query() => new QueryFluent<TEntity>(this);

        public virtual IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject) => new QueryFluent<TEntity>(this, queryObject);

        public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query) => new QueryFluent<TEntity>(this, query);

        public IQueryable<TEntity> Queryable() => _dbSet;

        public IRepository<T> GetRepository<T>() where T : class => _unitOfWork.Repository<T>();

        public virtual async Task<TEntity> FindAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public virtual async Task<bool> DeleteAsync(params object[] keyValues) => await DeleteAsync(CancellationToken.None, keyValues);

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(cancellationToken, keyValues);

            if (entity == null)
            {
                return false;
            }

            _context.Entry(entity).State = EntityState.Deleted;
            //_context.Set<TEntity>().Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        internal IQueryable<TEntity> Select(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }

        internal async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            return await Select(predicate, orderBy, includes, page, pageSize).ToListAsync();
        }

        public virtual IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> FilterAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            return await Select(predicate, orderBy, includes, page, pageSize).ToListAsync();
        }

        public Task<int> Commit()
        {
            return _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<TEntity> ApplyDefaultFilters(IQueryable<TEntity> query)
        {
            return query;
        }

        public async Task<List<TOutput>> RunProcedure<TOutput>(string name, object parameters = null) where TOutput : new()
        {
            DbConnection connection = _context.Database.GetDbConnection();
            await using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $"{name}";
                command.CommandType = CommandType.StoredProcedure;

                PropertyInfo[] sqlParams = parameters?.GetType().GetProperties(
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Public |
                    BindingFlags.Instance
                ).Where(p => !p.GetGetMethod().IsVirtual).ToArray();

                //if (sqlParams.Any()) foreach (PropertyInfo param in sqlParams)
                //{
                //    object paramValue = param.GetValue(parameters, null);
                //    {
                //        DbParameter parameter = command.CreateParameter();
                //        parameter.ParameterName = $"{param.Name}";
                //        parameter.Value = paramValue;
                //        command.Parameters.Add(parameter);
                //    }
                //}

                if (connection.State == ConnectionState.Closed) await connection.OpenAsync();
                await using (DbDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    List<TOutput> response = new List<TOutput>();
                    while (await dataReader.ReadAsync())
                    {
                        TOutput result = new TOutput();
                        Type resultType = result.GetType();

                        int fieldCount = dataReader.FieldCount;
                        for (int i = 0; i < fieldCount; i++)
                        {
                            var propertyName = dataReader.GetName(i);

                            PropertyInfo property = resultType.GetProperty(propertyName);
                            object value = dataReader.GetValue(i);

                            if (property != null && property.PropertyType.IsEnum)
                            {
                                property.SetValue(result, Convert.ChangeType(Enum.ToObject(property.PropertyType, value), property.PropertyType), null);
                            }
                            else if (property != null) property.SetValue(result, Convert.ChangeType(value, property.PropertyType), null);
                        }

                        response.Add(result);
                    }

                    await connection.CloseAsync();
                    return response;
                }
            }
        }

        public int RunProcedure(string name, object parameters = null)
        {
            try
            {
                DbConnection connection = _context.Database.GetDbConnection();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"Sp_{name}";
                    command.CommandType = CommandType.StoredProcedure;

                    PropertyInfo[] sqlParams = parameters.GetType().GetProperties(
                        BindingFlags.DeclaredOnly |
                        BindingFlags.Public |
                        BindingFlags.Instance
                    ).Where(p => !p.GetGetMethod().IsVirtual).ToArray();

                    if (sqlParams.Any()) foreach (PropertyInfo param in sqlParams)
                        {
                            object paramValue = param?.GetValue(parameters, null);
                            {
                                DbParameter parameter = command.CreateParameter();
                                if (param != null) parameter.ParameterName = $"{param.Name}";
                                parameter.Value = paramValue;
                                command.Parameters.Add(parameter);
                            }
                        }

                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int response = command.ExecuteNonQuery();

                    connection.Close();
                    return response;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

    }
}
