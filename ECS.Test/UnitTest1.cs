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
    }
}