using S10270400_PRG2Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    class Terminal
    {
        private string terminalName;
        public string TerminalName { get; set; }
        private Dictionary<string, Airline> airlines;
        public Dictionary<string,Airline> Airlines { get; set; }    

        private Dictionary<string, Flight> flights;
        public  Dictionary<string, Flight> Flights { get; set; }

        private Dictionary<string, BoardingGate> boardingGates;
        public Dictionary<string,BoardingGate> BoardingGates { get; set; }

        private Dictionary<string, double> gateFees;
        public Dictionary<string,double> GateFees { get; set; }


        public Terminal() { }

        public Terminal(string tn)
        {
            TerminalName = tn;
            Airlines = new Dictionary<string, Airline>();
            Flights = new Dictionary<string, Flight>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            GateFees = new Dictionary<string, double>();
        }

        //Incomplete
        public bool AddAirline(Airline airlines) 
        {
            return true;
        }

        public bool AddBoardingGate(BoardingGate boardingGates)
        {
            return true;
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            return null;
        }


    }
}
