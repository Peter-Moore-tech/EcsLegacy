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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}