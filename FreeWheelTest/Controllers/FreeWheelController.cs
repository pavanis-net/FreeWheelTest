using DataLayer;
using FreeWheelTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeWheelTest.Controllers
{
    public class FreeWheelController : Controller
    {
        // GET: FreeWheel

        public ActionResult DisplayPrograms()
        {
            string str= ProcessProgramName();
            return View((object)str);
        }

         

        public ActionResult Index()
        {
            FlightViewModel model = new FlightViewModel();
            model.stationVM = GetStationDetails();
            model.programVM = GetProgramDetails();
            return View(model);
        }

        public List<StationViewModel> GetStationDetails()
        {
            FreeWheelDBEntities context = new FreeWheelDBEntities();
            List<StationViewModel> result = new List<StationViewModel>();

            var obj = context.STATIONs.Select(u => u).ToList();
            if (obj!=null && obj.Count() >0)
            {
                foreach (var data in obj)
                {
                    StationViewModel model = new StationViewModel();
                    model.statinId = data.STATION_ID;
                    model.stationName = data.STATION_NAME;
                    result.Add(model);
                }
           
            }return result;
        }

        public List<ProgramViewModel> GetProgramDetails()
        {
            FreeWheelDBEntities context = new FreeWheelDBEntities();
            List<ProgramViewModel> result = new List<ProgramViewModel>();
            string  delimiter = ",";
            var obj = context.PROGRAMs.Select(u => u).ToList();
           
            if (obj != null && obj.Count() > 0)
            {
                foreach (var data in obj)
                {
                    ProgramViewModel model = new ProgramViewModel();
                    model.programId = data.PROGRAM_ID;
                    model.programName = data.PROGRAM_NAME;
                    model.flightTime = data.FLIGHT_DATE.Value;
                    model.statinId = data.STATION_ID.Value;
                    result.Add(model);
                }

            }
                      
   
            return result;
        }


        //Assignment 1
        public string ProcessProgramName()
        {
            FreeWheelDBEntities context = new FreeWheelDBEntities();
            List<ProgramViewModel> result = new List<ProgramViewModel>();
            string delimiter = "'";
            string resultStr = "";
                     
            var obj = context.PROGRAMs.Select(u => u).OrderBy(i => i.PROGRAM_NAME);

            string results =null;
            ProgramViewModel model = null;

            if (obj != null && obj.Count() > 0)
            {
                foreach (var data in obj)
                {
                    model = new ProgramViewModel();

                    model.programName = data.PROGRAM_NAME;


                    result.Add(model);
                }

            }
               

            foreach (ProgramViewModel data in result)
            {
                resultStr = resultStr + delimiter + data.programName+
                    ","+delimiter;
            }
            return results;


        }
        //Assignment 2
        public ProgramViewModel GetEaliestTrain(int stationID)
        {
            FreeWheelDBEntities context = new FreeWheelDBEntities();
            ProgramViewModel programQuery = ((from r in context.PROGRAMs
                                              where r.STATION_ID == stationID
                                              select new ProgramViewModel
                                              {
                                                  programId = r.PROGRAM_ID,
                                                  programName = r.PROGRAM_NAME,
                                                  statinId=r.STATION_ID.Value,
                                                  flightTime=r.FLIGHT_DATE.Value

                                              }
                                 ).OrderBy(t => t.programName)).OrderBy(t => t.flightTime).First();


            return programQuery;
        }
        
//Assignment 3
        public void PopulatMartketPop()
        {
            FreeWheelDBEntities context = new FreeWheelDBEntities();
            List<MARKET_POP> result = new List<MARKET_POP>();
            var pop = from m in context.MARKETs
                      from c in context.CELLS
                      select new 
                      {
                         MARKET_ID= m.MARKET_ID,
                         CELL_ID= c.CELL_ID
                      };



            if (pop != null && pop.Count() > 0)
            {
                foreach (var data in pop)
                {
                   MARKET_POP model = new MARKET_POP();
                    model.MARKET_ID = data.MARKET_ID;
                    model.CELL_ID = data.CELL_ID;
                    context.MARKET_POP.Add(model);
                    context.SaveChanges();
                }

            }

        }

    }
}