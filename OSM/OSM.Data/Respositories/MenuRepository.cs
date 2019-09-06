using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Respositories
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
