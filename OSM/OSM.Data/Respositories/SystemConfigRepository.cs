using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Respositories
{
    public interface ISystemConfigRepository : IRepositoryBase<SystemConfig>
    {
    }

    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
