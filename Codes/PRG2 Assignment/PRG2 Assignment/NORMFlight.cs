//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

// Finished
namespace PRG2_Project
{
    class NORMFlight : Flight
    {
        public NORMFlight(string fn, string or, string des, DateTime et, string stat) : base(fn, or, des, et, stat)
        {

        }

        public override double CalculateFees()
        {
            double fees = 0;
            return fees;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}