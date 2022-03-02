using System;
using Redesign.Heater;
using Redesign.TempSensor;

namespace Redesign
{
    public class ECS
    {
        private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, ITempSensor tempSensor, IHeater heater)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            try
            {
                var t = _tempSensor.GetTemp();
                Console.WriteLine($"Temperature measured was {t}");
                if (t < _threshold)
                    _heater.TurnOn();
                else
                    _heater.TurnOff();
            }
            catch (ArgumentOutOfRangeException e)
            {
                _heater.TurnOff();
                Console.WriteLine("DET ER FOR KOLDT ELLER VARMT DET ER I HVERT FALD OUT OF RANGE");
                throw;
            }

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return (_tempSensor.RunSelfTest() & _heater.RunSelfTest());
        }

        public void dennefunction()
        {
            int a = 3;
        }
    }
}
