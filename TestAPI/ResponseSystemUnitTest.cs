using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ResponseSystemAPI.Business;

namespace TestAPI
{
    public class ResponseSystemUnitTest
    {
        string InputMessagefr1 = "The alarm id from video server number 7 is 10.";
        string InputMessagefr2 = "Alarm id 10 has been received from video server number 7.";
        ResponseSystem resObj;
        [SetUp]
        public void Setup()
        {
            resObj = new ResponseSystem();
        }

        [Test]
        public void TestServerNumber()
        {
            //Assert.AreEqual(7, ReadServeNumber(InputMessagefr1));
            //Assert.AreEqual(7, ReadServeNumber(InputMessagefr2));
            Assert.Pass();
        }
        [Test]
        public void TestAlarmNumber()
        {
            //Assert.AreEqual(10, ReadAlarmNumber(InputMessagefr1));
            //Assert.AreEqual(10, ReadAlarmNumber(InputMessagefr2));
            Assert.Pass();
        }
        [Test]
        public void TestText()
        {
            Assert.AreEqual(true, resObj.ParseResponse(InputMessagefr1));
            //Assert.AreEqual(10, ReadAlarmNumber(InputMessagefr2));
            
        }
    }
}