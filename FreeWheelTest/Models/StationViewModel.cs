using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeWheelTest.Models
{
    public class StationViewModel
    {
        public int statinId { get; set; }
        public string stationName { get; set; }
    }

    public class FlightViewModel
    {
        public List<StationViewModel> stationVM{ get; set; }
        public List<ProgramViewModel> programVM { get; set; }
    }
}