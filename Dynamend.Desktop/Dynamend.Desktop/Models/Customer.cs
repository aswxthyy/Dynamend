using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamend.Desktop.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string LicenseNumber { get; set; }
        public string VehicleModelName { get; set; }
    }
}
