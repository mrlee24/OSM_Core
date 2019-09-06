using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace OSM.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private AppsDbContext _context;
        public RepositoryBase(IDbFactory dbFactory)
        {
            _context = dbFactory.GetDataContext;
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected AppsDbContext DbContext
        { get { return _context ?? (_context = DbFactory.GetDataContext); } }

        public IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }
        public virtual void Add(T entity)
        {
            var newEntry = _context.Add(entity);
        }
        public virtual void Update(T entity)
        {
            try
            {
                var entry = _context.Entry(entity);
                _context.Set<T>().Attach(entity);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Delete(int id)
        {
            var entity = GetSingle(id);

            if (entity == null) return;

            Delete(entity);
        }
        public void DeleteMulti(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
        }
        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            throw new NotImplementedException();
        }
        public T GetSingle(int id)
        {
            // kiem tra ham EntityBase
            //  return _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return _context.Set<T>().Find(id);
        }
        //  200
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        //  200
        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }
        //200
        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _context.Set<T>
            ().Where<T>
            (filter).AsQueryable() : _context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) :
            _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }
        public int Count()
        {
            return _context.Set<T>().Count();
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }
        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count<T>(predicate) > 0;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
