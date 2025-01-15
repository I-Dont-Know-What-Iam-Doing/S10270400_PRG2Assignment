
// Request fee unfinished
namespace PRG2_Project
{
    class LWTTFlight : Flight
    {
        private double requestFee;
        public double RequestFee { get; set;}

        public LWTTFlight(string fn, string or, string des, DateTime et, string stat, double rf) : base(fn, or, des, et, stat)
        {
            RequestFee = rf;
        }

        public override double CalculateFees()
        {
            double fee = 0;
            return fee;
        }

        public override string ToString()
        {
            return base.ToString() + $"Req fee: {RequestFee}";
        }
    }   
}