using OSM.Data.Infrastructure;
using OSM.Data.Respositories;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OSM.Service.Services
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
        PostCategory GetById(int id);

    }
    class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingle(id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
