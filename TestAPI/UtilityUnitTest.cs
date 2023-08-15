using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResponseSystem.Business;

namespace TestAPI
{
    public class UtilityUnitTest
    {
        /*Set of inputs for test senerios */
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
       
    }
}