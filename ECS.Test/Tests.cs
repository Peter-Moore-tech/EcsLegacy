using System;
using NSubstitute;
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
            tempSensor = Substitute.For<ITempSensor>();
            heater = Substitute.For<IHeater>();
            uut = new ECS(23, tempSensor, heater);
        }


        [TestCase(22,1)]
        [TestCase(23,0)]
        [TestCase(24,0)]
        public void Regulate_GetTempTreshold23_HeaterStatus(int temp, int result)
        {
            //ACT
            tempSensor.GetTemp().Returns(temp);
            uut.Regulate();

            //ASSERT
            heater.Received(result).TurnOn();
        }


        [Test]
        public void Regulate_GetTemp25Threshold23_ResHeaterTurnedOffOnce()
        {
            //ACT
            tempSensor.GetTemp().Returns(25);
            uut.Regulate();
            //ASSERT
            heater.Received(1).TurnOff();

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
            // ACT
            tempSensor.GetTemp().Returns(17);

            Assert.That(uut.GetCurTemp(), Is.EqualTo(17));
        }

        [TestCase(true,true,true)]
        [TestCase(false,true,false)]
        [TestCase(true,false,false)]
        [TestCase(false,false,false)]

        public void RunSelfTest_HeaterSelfTestStatusAndTempSensorSelfTestStatus_RunSelfTestTrue(bool temp, bool heat, bool expectedresult)
        {
            // Arrange
            // ACT
            tempSensor.RunSelfTest().Returns(temp);
            heater.RunSelfTest().Returns(heat);

            Assert.That(uut.RunSelfTest(),Is.EqualTo(expectedresult));
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
        public void Regulate_GetTempThrowsException_HeaterTurnedOffAndExceptionThrown()
        {
            // Arrange
            // ACT
            tempSensor.When( x => x.GetTemp())
                .Do(x => { throw new ArgumentOutOfRangeException(); });
            
            Assert.Throws<ArgumentOutOfRangeException>(() => uut.Regulate());
            heater.Received(1).TurnOff();
        }

    }
}