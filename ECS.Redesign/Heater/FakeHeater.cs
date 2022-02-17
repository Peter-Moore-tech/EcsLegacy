namespace Redesign.Heater
{
    internal class FakeHeater : IHeater
    {
        public bool RunSelfTest()
        {
            if (turnOffWasCalled && turnOnWasCalled)
                return true;
            return false;
        }

        public void TurnOff()
        {
            turnOffWasCalled = true;
        }

        public void TurnOn()
        {
            turnOnWasCalled = true;
        }

        public bool turnOffWasCalled { get; set; }
        public bool turnOnWasCalled { get; set; }
    }
}
