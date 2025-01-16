//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

// Finished
namespace S10270400_PRG2Assignment
{
    class NORMFlight : Flight
    {
        public NORMFlight(string fn, string or, string des, DateTime et, string stat) : base(fn, or, des, et, stat)
        {

        }

        public override double CalculateFees()
        {
            // 50 discount
            double fees =- 50;
            return fees;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}