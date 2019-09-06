namespace OSM.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        //void Commit();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
    }
}
