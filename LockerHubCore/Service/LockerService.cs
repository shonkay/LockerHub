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

        public async Task<IEnumerable<Locker>> GetLockerByState(string State)
        {
            var entity = await _unitOfWork.Locker.GetLockerByState(State);
            return entity;
        }

        public async Task<IEnumerable<Locker>> GetLockerByCity(string City)
        {
            var entity = await _unitOfWork.Locker.GetLockerByCity(City);
            return entity;
        }

        public async Task<IEnumerable<Locker>> GetLockerInStateBySize(string State, string size)
        {
            var entity = await _unitOfWork.Locker.GetLockerInStateBySize(State, size);
            return entity;
        }

        public async Task<IEnumerable<Locker>> GetLockerInCityBySize(string City, string size)
        {
            var entity = await _unitOfWork.Locker.GetLockerInCityBySize(City, size);
            return entity;
        }
    }
}
