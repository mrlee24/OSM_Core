using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace OSM.Data.Infrastructure
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        IQueryable<T> All();
        void Add(T entity);
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        int Count();
        void Delete(int id);
        void Delete(T entity);
        void DeleteMulti(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(int id);
        void Update(T entity);
        void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams);
        bool Contains(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}