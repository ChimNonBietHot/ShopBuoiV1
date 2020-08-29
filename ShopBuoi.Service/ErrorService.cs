using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Data.Repositories;
using ShopBuoi.Model.Models;

namespace ShopBuoi.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void save()
        {
            _unitOfWork.Commit();
        }
    }
}