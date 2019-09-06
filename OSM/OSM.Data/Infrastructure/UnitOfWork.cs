using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private AppsDbContext dbContext;
        //Get DbContext from IDbfactory
        public AppsDbContext DbContext
        { get { return dbContext ?? (dbContext = _dbFactory.GetDataContext); } }
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public void BeginTransaction()
        {
            _dbFactory.GetDataContext.Database.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            _dbFactory.GetDataContext.Database.RollbackTransaction();
        }
        public void CommitTransaction()
        {
            _dbFactory.GetDataContext.Database.CommitTransaction();
        }
        public void SaveChanges()
        {
            _dbFactory.GetDataContext.SaveChanges();
        }
    }
}