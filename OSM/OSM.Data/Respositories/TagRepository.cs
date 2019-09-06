using OSM.Data.Infrastructure;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Respositories
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
