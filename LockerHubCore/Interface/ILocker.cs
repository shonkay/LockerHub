using LockerHubCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Interface
{
    public interface ILocker : IGeneric<Locker>
    {
        Task<IEnumerable<Locker>> GetLockerInStateBySize(string State, string Size);

        Task<IEnumerable<Locker>> GetLockerInCityBySize(string City, string Size);

        Task<IEnumerable<Locker>> GetLockerByCity(string City);

        Task<IEnumerable<Locker>> GetLockerByState(string State);
    }
}
