using OSM.Data.Infrastructure;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Data.Respositories
{
    public interface IPostCategoryRepository : IRepositoryBase<PostCategory>
    {
    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
