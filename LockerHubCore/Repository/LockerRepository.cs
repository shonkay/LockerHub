using LockerHubCore.Context;
using LockerHubCore.Interface;
using LockerHubCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockerHubCore.Repository
{
    public class LockerRepository : GenericRepository<Locker>, ILocker
    {
        public LockerRepository(HubContext context) : base(context)
        {

        }
    }
}
