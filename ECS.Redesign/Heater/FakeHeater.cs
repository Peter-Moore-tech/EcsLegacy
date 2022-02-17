namespace Redesign.Heater
{
    public class FakeHeater : IHeater
    {
        public bool RunSelfTest()
        {
            return SelfTestResult;
        }

        public void TurnOff()
        {
           HeaterStatus=0;
            SelfTestResult=false;
        }

        public void TurnOn()
        {
           HeaterStatus++;
            SelfTestResult=true;
        }
        public int HeaterStatus { get; set; } = 0;
        public bool SelfTestResult { get; set; }
    }
}
