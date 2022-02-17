namespace Redesign.Heater
{
    public class FakeHeater : IHeater
    {
        public bool RunSelfTest()
        {
            if( TurnOnRun & TurnOffRun)
                return true;
            return false;
        }

        public void TurnOff()
        {
           HeaterStatus=0;
            TurnOffRun=true;
        }

        public void TurnOn()
        {
           HeaterStatus=1;
            TurnOnRun=true;
        }
        public int HeaterStatus { get; set; } = 2;
        public bool TurnOnRun { get; set; }=false;
        public bool TurnOffRun { get; set; } =false;
    }
}
