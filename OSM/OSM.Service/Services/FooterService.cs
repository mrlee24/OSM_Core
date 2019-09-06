using OSM.Data.Infrastructure;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Service.Services
{
    public interface IFooterService
    {
        void Add(Footer footer);
        void Update(Footer footer);
        void Delete(int id);
        IEnumerable<Footer> GetAll();
        IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow);
        Footer GetById(int id);
        IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    class FooterService : IFooterService
    {
        IFooterService _footerRepository;
        IUnitOfWork _unitOfWork;

        public FooterService(IFooterService footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Footer footer)
        {
            _footerRepository.Add(footer);
        }

        public void Delete(int id)
        {
            _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        }

        public IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Footer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Footer footer)
        {
            throw new NotImplementedException();
        }
    }
}
