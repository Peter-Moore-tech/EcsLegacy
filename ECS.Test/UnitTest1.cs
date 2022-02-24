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


        [Test]
        public void GetThreshold_Threshold23_Res23()
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

        [Test]
        public void Regulate_MockTurnedOn_Result1()
        {
            // Arrange
            // Act
            uut.Regulate();    // 17 is below threshold of 23 chosen in setup

            Assert.That(heater.HeaterStatus, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_MockTurnedOff_Result0()
        {
            // Arrange
            // Act
            uut.SetThreshold(12);   
            uut.Regulate(); // 17 is above threshold of 12

            Assert.That(heater.HeaterStatus, Is.EqualTo(0));
        }
    }
}