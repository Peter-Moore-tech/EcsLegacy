namespace Redesign.TempSensor
{
    public interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
}