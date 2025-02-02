//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================


namespace S10270400_PRG2Assignment
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
            return base.CalculateFees() + 500;
        }

        public override string ToString()
        {
            return base.ToString() + $"Req fee: {RequestFee}";
        }
    }   
}