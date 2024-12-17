using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamend.Desktop.Models
{
    internal class Vehicle
    {
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public string LicenseNumber { get; set; }
        public string ModelName { get; set; }
    }
}
