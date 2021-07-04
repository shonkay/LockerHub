using LockerHubCore.Interface;
using LockerHubCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Service
{
    public class LockerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Locker>> GetAll() =>
            await _unitOfWork.Locker.GetAll();

        public async Task<Locker> GetById(Guid Id) =>
            await _unitOfWork.Locker.GetById(Id);
    }
}
