//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

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
            // 500 fee
            fee =+ 500;

            if (Status == "")
            {
                
            }

            return fee;
        }

        public override string ToString()
        {
            return base.ToString() + $"Req fee: {RequestFee}";
        }
    }   
}