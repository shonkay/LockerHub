using LockerHubCore.Context;
using LockerHubCore.Interface;
using LockerHubCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Repository
{
    public class LockerRepository : GenericRepository<Locker>, ILocker
    {
        public LockerRepository(HubContext context) : base(context)
        {

        }

       public async Task<IEnumerable<Locker>> GetLockerInStateBySize(string State, string Size)
        {
            var query = await Find(x => x.State == State && x.Size == Size);
            return query;
        }

        public async Task<IEnumerable<Locker>> GetLockerInCityBySize(string City, string Size)
        {
            var query = await Find(x => x.City == City && x.Size == Size);
            return query;
        }

        public async Task<IEnumerable<Locker>> GetLockerByCity(string City)
        {
            var query = await Find(x => x.City == City);
            return query;
        }

        public async Task<IEnumerable<Locker>> GetLockerByState(string State)
        {
            var query = await Find(x => x.State == State);
            return query;
        }
    }
}
