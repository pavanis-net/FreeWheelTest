using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeWheelTest.Models
{
    public class ProgramViewModel
    {
        public int statinId { get; set; }

        public int programId { get; set; }
        
        public string programName { get; set; }

        public DateTime flightTime { get; set; }

        public string programNames { get; set; }
    }
}