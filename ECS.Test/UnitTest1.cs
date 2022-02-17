using NUnit.Framework;
using Redesign;
using Redesign.Heater;
using Redesign.TempSensor;


namespace Test
{
    public class Tests
    {
        private ECS uut;
        private ITempSensor ItempSensor;
        private IHeater IHeater;

        [SetUp]
        public void Setup()
        {
            uut = new ECS(23, ItempSensor, IHeater);
        }

        
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }



        // Regulate

        // SetThreshold(int thr)

        // GetThreshold()

        // GetCurTemp()

        // RunSelfTest()


        [Test]
        public void GetCurTemp_TempIs17_Result17()
        {
            Assert.That(uut.GetCurTemp(), Is.EqualTo(17));
        }

        [Test]
        public void RunSelfTest_SelfTestTrue_ResultTrue()
        {
            // Arrange
            ItempSensor.

            Assert.That(uut.RunSelfTest(),Is.EqualTo(true));
        }


    }
}