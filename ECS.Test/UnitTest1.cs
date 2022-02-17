using NUnit.Framework;
using Redesign;
using Redesign.Heater;
using Redesign.TempSensor;


namespace Test
{
    public class Tests
    {
        private ECS uut;
        private ITempSensor tempSensor;
        private IHeater heater;

        [SetUp]
        public void Setup()
        {
            tempSensor = new FakeTempSensor();
            heater = new FakeHeater();
            uut = new ECS(23, tempSensor, heater);
        }

        [Test]
        public void Regulate_GetTemp17Treshold23_ResHeaterTurnOnTrue()
        {
            //ACT
            uut.Regulate();
            //ASSERT
            Assert.That(uut., Is.EqualTo(true));
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
        public void Test1()
        {
            Assert.Pass();
        }



        // 
    }
}