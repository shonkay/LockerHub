using LockerHubCore.Service;
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

        [HttpGet("[action]/{parameter}")]
        public async Task<IActionResult> SearchLocker(string parameter)
        {
            try
            {
                var result = await _locker.GetLockerByState(parameter);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet("[action]/{parameter}")]
        public async Task<IActionResult> SortLockersByPrice(string parameter)
        {
            try
            {
                var result = await _locker.SortLockerByPrice(parameter);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]/{parameter}")]
        public async Task<IActionResult> SortLockersByClosest(string parameter)
        {
            try
            {
                var result = await _locker.SortLockerByClosest(parameter);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("[action]/{parameter}/{Size}")]
        public async Task<IActionResult> GetLockersInStateBySize(string parameter, string Size)
        {
            try
            {
                var result = await _locker.SortLockerBySize(parameter, Size);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
