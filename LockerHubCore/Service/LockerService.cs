using LockerHubCore.Interface;
using LockerHubCore.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Service
{
    public class LockerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public LockerService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<IEnumerable<Locker>> GetAll() =>
            await _unitOfWork.Locker.GetAll();

        public async Task<Locker> GetById(Guid Id) =>
            await _unitOfWork.Locker.GetById(Id);

        public async Task<Response> GetLockerByState(string State, string City)
        {
            var entity = await _unitOfWork.Locker.GetLockerByState(State, City);
            var ResponseList = LoopResult(entity);

            return ResponseList;
        }

        public async Task<Response> SortLockerByPrice(string State, string City)
        {
            var entity = await _unitOfWork.Locker.SortLockerByPrice(State, City);
            var ResponseList = LoopResult(entity);

            return ResponseList;
        }

        public async Task<Response> GetLockerInStateBySize(string State, string size)
        {
            var entity = await _unitOfWork.Locker.GetLockerInStateBySize(State, size);
            var response = LoopResult(entity);

            return response;
        }

        public async Task<Response> GetLockerInCityBySize(string City, string size)
        {
            var entity = await _unitOfWork.Locker.GetLockerInCityBySize(City, size);
            var response = LoopResult(entity);

            return response;
        }


        private Response LoopResult(IEnumerable<Locker> lockers)
        {
            var ResponseList = new List<Response_Model>();
            var TotalLockers = 0;

            foreach (var model in lockers)
            {
                var response = new Response_Model
                {
                    Dimension = model.Size + " " + "H" + model.Height + "*" + "W" + model.Width + "*" + "D" + model.Breath + "mm",
                    Details = _config.GetValue<string>("Locker:viewDetails"),
                    Price = $"{model.Price}N For First Rent",
                    Availability = $"{model.NoAvailable} Available",
                };
                TotalLockers += model.NoAvailable;
                ResponseList.Add(response);
            }

            return new Response 
            { 
                ModelResponse = ResponseList,
                TotalLockerAvailable = TotalLockers
            };
        }
    }
}
