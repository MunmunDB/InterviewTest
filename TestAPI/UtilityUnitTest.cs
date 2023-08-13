using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResponseSystem.Business;

namespace TestAPI
{
    public class UtilityUnitTest
    {
        /*Set of inputs for test senerios */
        string InputMessagefr1 = "The alarm id from video server number 7 is 10.";
        string InputMessagefr2 = "Alarm id 10 has been received from video server number 7.";
        string InputMessageWrong = "Alarm id 10 and video server number 7.";
        string testfilepath = Path.Join(Directory.GetCurrentDirectory(), "\\TestResourceFile\\TestFormats.csv");

        Utility utilObj;

        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<Utility>>();
            utilObj = new Utility(logger.Object, testfilepath);
        }

       
        [Test]
        public void TestParseFormat_2()
        {
            var formatInfo = utilObj.GetFormats();
            Assert.That(formatInfo.Count, Is.GreaterThan(0));
            Assert.That(formatInfo.First().alamNoIndex, Is.GreaterThan(-1));
            Assert.That(formatInfo.First().serverNoIndex, Is.GreaterThan(-1));
        }
        [Test]
        public void TestParseFormat_Fails()
        {
            var formatInfo = utilObj.GetFormats();
            Assert.That(formatInfo.Count, Is.EqualTo(0));
            Assert.That(formatInfo.First().alamNoIndex, Is.EqualTo(-1));
            Assert.That(formatInfo.First().serverNoIndex, Is.EqualTo(-1));
        }
    }
}