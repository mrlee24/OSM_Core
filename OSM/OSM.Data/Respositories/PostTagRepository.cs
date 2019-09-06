using OSM.Data.Infrastructure;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Respositories
{
    public interface IPostTagRepository : IRepositoryBase<PostTag>
    {
    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
