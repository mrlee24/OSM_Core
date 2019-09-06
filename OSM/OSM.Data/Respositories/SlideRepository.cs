using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Respositories
{
    public interface ISlideRepository : IRepositoryBase<Slide>
    {
    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
