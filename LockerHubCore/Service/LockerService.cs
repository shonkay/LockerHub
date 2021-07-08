﻿using LockerHubCore.Interface;
using LockerHubCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Service
{
    public class LockerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClient;

        public LockerService(IUnitOfWork unitOfWork, IConfiguration config, IHttpClientFactory httpClient)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _httpClient = httpClient;
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

        public async Task<Response> SortLockerByClosest(string State, string City)
        {
            var location = await GetMapLocation(_config.GetValue<string>("GoogleMapApi:CurrentAddress"));
            double.TryParse(location.Latitude, out double latitude);
            double.TryParse(location.Longitude, out double longitude);

            var coord = new GeoCoordinate(latitude, longitude);
            var entity = await _unitOfWork.Locker.GetLockerByState(State, City);

            var query = entity.ToLookup(x => new GeoCoordinate(x.Latitude, x.Longitude), x => x)
                .OrderBy(x => x.Key.GetDistanceTo(coord));
            var response = LoopResult(entity);

            return response;
        }



        private async Task<LocationModel> GetMapLocation(string address)
        {
            var client = _httpClient.CreateClient("Google Client");

            var queryString = _config.GetSection("GoogleMapApi").GetValue<string>("GetAddressLocation").ToString();
            queryString += $"?key={_config.GetSection("GoogleMapApi").GetValue<string>("ApiKey").ToString()}";
            queryString += $"&address={address}";

            var response = await client.GetAsync(queryString);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<GoogleLocationModel>(responseMessage);
                if(result.Status != "OK")
                {
                    throw new Exception(result.ErrorMessage);
                }
                var dataResults = result.Results.FirstOrDefault();
                var address_components = dataResults.Address_Components;
                string state = address_components.FirstOrDefault(x => x.Types.Contains("locality"))?.Long_Name;
                string country = address_components.FirstOrDefault(x => x.Types.Contains("country"))?.Long_Name;
                return new LocationModel
                {
                    Address = address,
                    State = state,
                    Country = country,
                    Latitude = dataResults.Geometry.Location.Lat,
                    Longitude = dataResults.Geometry.Location.Lng
                };
            }
            else
            {
                throw new Exception("Could Not Get Location");
            }
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
