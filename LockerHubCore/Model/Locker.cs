using System;
using System.Collections.Generic;
using System.Text;

namespace LockerHubCore.Model
{
   public class Locker
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Size { get; set; }
        public double Width { get; set; }
        public double Breath { get; set; }
        public double Height { get; set; }
    }
}
