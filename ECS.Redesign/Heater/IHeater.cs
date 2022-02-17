namespace Redesign.Heater
{
    public interface IHeater
    {
        bool RunSelfTest();
        void TurnOff();
        void TurnOn();
    }
}