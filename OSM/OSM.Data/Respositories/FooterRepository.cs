using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Respositories
{
    public interface IFooterRepository : IRepositoryBase<Footer>
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
