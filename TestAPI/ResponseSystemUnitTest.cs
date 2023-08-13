using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResponseSystemAPI.Business;

namespace TestAPI
{
    public class ResponseSystemUnitTest
    {
        /*Set of inputs for test senerios */
        string InputMessagefr1 = "The alarm id from video server number 7 is 10.";
        string InputMessagefr2 = "Alarm id 10 has been received from video server number 7.";
        string InputMessageWrong = "Alarm id 10 and video server number 7.";

        ResponseSystem resObj;

        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<ResponseSystem>>();
            resObj = new ResponseSystem(logger.Object);
        }

        [Test]
        public void TestParseFormat_1()
        {
            Assert.That(resObj.ParseResponse(InputMessagefr1), Is.EqualTo(true));
            Assert.That(resObj.serverNo, Is.EqualTo(7));
            Assert.That(resObj.alarmNo, Is.EqualTo(10));
            
        }
        [Test]
        public void TestParseFormat_2()
        {
            Assert.That(resObj.ParseResponse(InputMessagefr2), Is.EqualTo(true));
            Assert.That(resObj.serverNo, Is.EqualTo(7));
            Assert.That(resObj.alarmNo, Is.EqualTo(10));

        }
        [Test]
        public void TestParseFormat_Wrong()
        {
            Assert.That(resObj.ParseResponse(InputMessageWrong), Is.EqualTo(true));
            Assert.That(resObj.serverNo, Is.EqualTo(0));
            Assert.That(resObj.alarmNo, Is.EqualTo(0));
        }
    }
}