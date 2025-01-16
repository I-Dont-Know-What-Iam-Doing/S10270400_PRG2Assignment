//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

// Request fee unfinished
namespace S10270400_PRG2Assignment
{
    class DDJBFlight : Flight
    {
        private double requestFee;
        public double RequestFee { get; set; }

        public DDJBFlight(string fn, string or, string des, DateTime et, string stat, double rf) : base(fn, or, des, et, stat)
        {
            RequestFee = rf;
        }

        public override double CalculateFees()
        {
            double fee = 0;
            // 300 fee
            fee =+ 300;
            return fee;
        }

        public override string ToString()
        {
            return base.ToString() + $"Req fee: {RequestFee}";
        }
    }
}