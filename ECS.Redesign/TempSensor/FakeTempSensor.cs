namespace ECS.Redesign.TempSensor
{
    internal class FakeTempSensor: ITempSensor
    {
        public int _randomNumber { get; set; } = 0;

        public int GetTemp()    // Always returns 17
        {
            _randomNumber = 17;
            return _randomNumber;
        }

        public bool RunSelfTest()
        {
            if (_randomNumber == 17)
                return true;
            return false;
        }
    }
}
