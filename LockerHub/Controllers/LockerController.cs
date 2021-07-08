﻿using LockerHubCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockerHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockerController : ControllerBase
    {
        private readonly LockerService _locker;

        public LockerController(LockerService locker)
        {
            _locker = locker;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLockers()
        {
            try
            {
                var result = await _locker.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllLockerById(Guid Id)
        {
            try
            {
                var result = await _locker.GetById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLockersByStateOrCity(string State, string City)
        {
            try
            {
                var result = await _locker.GetLockerByState(State, City);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> SortLockersByPrice(string State, string City)
        {
            try
            {
                var result = await _locker.SortLockerByPrice(State, City);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SortLockersByClosest(string State, string City)
        {
            try
            {
                var result = await _locker.SortLockerByClosest(State, City);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]/{State}/{Size}")]
        public async Task<IActionResult> GetLockersInStateBySize(string State, string Size)
        {
            try
            {
                var result = await _locker.GetLockerInStateBySize(State, Size);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]/{City}/{Size}")]
        public async Task<IActionResult> GetLockersInCityBySize(string City, string Size)
        {
            try
            {
                var result = await _locker.GetLockerInStateBySize(City, Size);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
