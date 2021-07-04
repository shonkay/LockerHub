using LockerHubCore.Context;
using LockerHubCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly HubContext _hubContext;

        public UnitOfWork(HubContext hubContext, ILocker locker)
        {
            _hubContext = hubContext;
            Locker = locker;
        }
        public ILocker Locker { get; private set; }
        public async Task<int> Complete() => await _hubContext.SaveChanges();
        public async void Cancel() => await _hubContext.DisposeAsync();
        public void Dispose() => _hubContext.Dispose();
    }
}
