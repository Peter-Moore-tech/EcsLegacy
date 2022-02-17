using NUnit.Framework;
using Redesign;
using Redesign.Heater;
using Redesign.TempSensor;


namespace Test
{
    public class Tests
    {
        private ECS uut;
        private FakeTempSensor tempSensor;
        private FakeHeater heater;

        [SetUp]
        public void Setup()
        {
            tempSensor = new FakeTempSensor();
            heater = new FakeHeater();
            uut = new ECS(23, tempSensor, heater);
        }

        [Test]
        public void Regulate_GetTemp17Treshold23_ResHeaterTurnOnIs1()
        {
            //ACT
            uut.Regulate();
            //ASSERT
            Assert.That(heater.HeaterStatus, Is.EqualTo(1));
        }


        [Test]
        public void Regulate_GetTemp17Treshold12_ResHeaterTurnOffIs0()
        {
            //ACT
            uut.SetThreshold(12);
            uut.Regulate();
            //ASSERT
            Assert.That(heater.HeaterStatus, Is.EqualTo(0));
        }

        //public void Regulate()
        //{
        //    var t = _tempSensor.GetTemp();
        //    Console.WriteLine($"Temperature measured was {t}");
        //    if (t < _threshold)
        //        _heater.TurnOn();
        //    else
        //        _heater.TurnOff();
        //}


        [Test]
        public void GetThreshold_Treshold23_Res23()
        {
            Assert.That(uut.GetThreshold(),Is.EqualTo(23));
        }

        [Test]
        public void SetThreshold_SetThresholdTo30_Res30()
        {
            //ACT
            uut.SetThreshold(30);
            //ASSERT
            Assert.That(uut.GetThreshold(), Is.EqualTo(30));
        }


        [Test]
        public void GetCurTemp_TempIs17_Result17()
        {
            Assert.That(uut.GetCurTemp(), Is.EqualTo(17));
        }

        [Test]
        public void RunSelfTest_GetTemp17Threshold23RegulateSetThreshold12Regulate_RunSelfTestTrue()
        {
            // Arrange
            // ACT
            uut.Regulate();
            uut.SetThreshold(12);
            uut.Regulate();

            Assert.That(uut.RunSelfTest(),Is.True);
        }

        [Test]
        public void RunSelfTest_GetTemp17Threshold23Regulate_RunSelfTestFalse()
        {
            // Arrange
            // ACT
            uut.Regulate();

            Assert.That(uut.RunSelfTest(), Is.False);
        }

    }
}