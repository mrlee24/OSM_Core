
using OSM.Data.Infrastructure;
using OSM.Data.Respositories;
using OSM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Service
{
    public interface IErrorService
    {
        void Create(Error error);
        void Save();
    }

    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(ErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
