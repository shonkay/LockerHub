using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ILocker Locker { get; }
        Task<int> Complete();
        void Cancel();
    }
}
