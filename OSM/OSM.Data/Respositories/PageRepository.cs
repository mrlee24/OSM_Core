using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Respositories
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
