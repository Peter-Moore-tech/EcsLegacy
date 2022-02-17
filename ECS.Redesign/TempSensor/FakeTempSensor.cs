namespace Redesign.TempSensor
{
    public class FakeTempSensor: ITempSensor
    {
        public int RandomNumber { get; set; } = 0;

        public int GetTemp()    // Always returns 17
        {
            RandomNumber = 17;
            return RandomNumber;
        }

        public bool RunSelfTest()
        {
            if (RandomNumber == 17)
                return true;
            return false;
        }
    }
}
